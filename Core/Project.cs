using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using Webyneter.ComponentsAnalysis.Core.Analysis;
using Webyneter.ComponentsAnalysis.Core.Analysis.KPCA;
using Webyneter.ComponentsAnalysis.Core.Analysis.PCA;
using Webyneter.ComponentsAnalysis.Core.Miscellaneous;
using Webyneter.ComponentsAnalysis.Core.UniversalSpaceProjection;


namespace Webyneter.ComponentsAnalysis.Core
{
    [Serializable]
    public sealed class Project : IDisposable
    {
        public class ProjectOpenedEventArgs : EventArgs
        {
            public _SerializableSettings Settings { get; private set; }
            public ProjectOpenedEventArgs(_SerializableSettings settings) { Settings = settings; }
        }

        public class AnalysisPerformedEventArgs : EventArgs
        {
            public IAnalysisResult Result { get; private set; }
            public AnalysisPerformedEventArgs(IAnalysisResult result) { Result = result; }
        }

        public class USPPerformedEventArgs : EventArgs
        {
            public double[,] Result { get; private set; }
            public USPPerformedEventArgs(double[,] result) { Result = result; }
        }

        public static event EventHandler<ProjectOpenedEventArgs> ProjectOpened = delegate { };
        public static event EventHandler ProjectChanged = delegate { };
        public static event EventHandler ProjectSaved = delegate { };
        public static event EventHandler ProjectClosed = delegate { };

        public static event EventHandler AnalysisInputDataImported = delegate { };
        public static event EventHandler USPUniversalInputDataImported = delegate { };
        public static event EventHandler USPSampleInputDataImported = delegate { };

        public static event EventHandler AnalysisInputDataRemoved = delegate { };
        public static event EventHandler USPUniversalInputDataRemoved = delegate { };
        public static event EventHandler USPSampleInputDataRemoved = delegate { }; 

        public static event EventHandler<AnalysisPerformedEventArgs> PCAPerformed = delegate { };
        public static event EventHandler<AnalysisPerformedEventArgs> KPCAPerformed = delegate { };
        public static event EventHandler<USPPerformedEventArgs> USPPerformed = delegate { };
        
        public static IEnumerable<KeyValuePair<string, SupportedInputFileFormat>> SupportedInputExtensionFormatMap => extensionFormatMap.AsEnumerable();
        public static string ProjectFileExtension => projectFileExtension;

        private const string projectFileExtension = ".caproject";
        private static readonly Dictionary<string, SupportedInputFileFormat> extensionFormatMap =
            new Dictionary<string, SupportedInputFileFormat>
        {
            { ".xls", SupportedInputFileFormat.Excel2003 },
            { ".xlsx", SupportedInputFileFormat.Excel2007 },
            { ".xml", SupportedInputFileFormat.XML }
        };
        private static Project openedProject;

        public static Project Load(string projectFilePath)
        {
            if (!CheckIfValidProjectFile(projectFilePath))
            {
                throw new ArgumentException(Lib.InvalidProjectFile + "!", projectFilePath);
            }
            var fs = new FileStream(projectFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            var proj = (Project) new BinaryFormatter().Deserialize(fs);
            proj.fileStream = fs;
            return proj;
        }

        public static bool TryGetSupportedInputFileFormat(string extension, out SupportedInputFileFormat? result)
        {
            SupportedInputFileFormat supportedInputFileFormat;
            if (extensionFormatMap.TryGetValue(extension, out supportedInputFileFormat))
            {
                result = supportedInputFileFormat;
                return true;
            }
            result = null;
            return false;
        }

        public static bool TryGetOpenedProject(out Project result)
        {
            if (openedProject != null)
            {
                result = openedProject;
                return true;
            }
            result = null;
            return false;
        }

        private static bool CheckIfValidProjectFile(string filePath)
        {
            if (Path.GetExtension(filePath).Equals(projectFileExtension))
            {
                return true;
            }
            return false;
        }

        public string Name => Path.GetFileNameWithoutExtension(projectFilePath);
        public string FilePath => projectFilePath;
        public DataTable AnalysisInputData { get; private set; }
        public DataTable USPUniversalInputData { get; private set; }
        public DataTable USPSampleInputData { get; private set; }

        public bool IsOpened
        {
            get
            {
                Project proj;
                if (TryGetOpenedProject(out proj) 
                    && ReferenceEquals(proj, this))
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsSaved
        {
            get { return isSaved; }
            private set
            {
                isSaved = value;
                if (value)
                {
                    ProjectSaved(this, new EventArgs());
                }
                else
                {
                    ProjectChanged(this, new EventArgs());
                }
            }
        }
        public IEnumerable<KeyValuePair<AnalysisAlgorithm, IAnalysisResult>> AnalysisResults => analysisResults.AsEnumerable();

        private readonly string projectFilePath;
        [NonSerialized]
        private FileStream fileStream;
        private readonly Dictionary<AnalysisAlgorithm, IAnalysisResult> analysisResults;
        private _SerializableSettings lastSavedApplicationSettings;
        private bool isSaved;
        private bool disposed;

        public Project(string projectFilePath)
        {
            if (!CheckIfValidProjectFile(projectFilePath))
            {
                throw new ArgumentException(Lib.InvalidProjectFile + "!", projectFilePath);
            }
            this.projectFilePath = projectFilePath;
            fileStream = new FileStream(projectFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            analysisResults = new Dictionary<AnalysisAlgorithm, IAnalysisResult>
            {
                { AnalysisAlgorithm.PCA, null },
                { AnalysisAlgorithm.KPCA, null }
            };
            isSaved = true;
        }

        public void ImportInputData(DataTable analysisInputData, DataTable uspUnivInputData, 
            DataTable uspSampleInputData)
        {
            if (analysisInputData != null)
            {
                RemoveInputData(true, false, false);
                AnalysisInputData = analysisInputData;
                IsSaved = false;
                AnalysisInputDataImported(this, new EventArgs());
            }
            if (uspUnivInputData != null)
            {
                RemoveInputData(false, true, false);
                USPUniversalInputData = uspUnivInputData;
                IsSaved = false;
                USPUniversalInputDataImported(this, new EventArgs());
            }
            if (uspSampleInputData != null)
            {
                RemoveInputData(false, false, true);
                USPSampleInputData = uspSampleInputData;
                IsSaved = false;
                USPSampleInputDataImported(this, new EventArgs());
            }
        }

        public void RemoveInputData(bool analysis, bool uspUniv, bool uspSample)
        {
            if (analysis && AnalysisInputData != null)
            {
                AnalysisInputData.Dispose();
                AnalysisInputData = null;
                foreach (AnalysisAlgorithm alg in Enum.GetValues(typeof(AnalysisAlgorithm)))
                {
                    analysisResults[alg] = null;
                }
                IsSaved = false;
                AnalysisInputDataRemoved(this, new EventArgs());
            }
            if (uspUniv && USPUniversalInputData != null)
            {
                USPUniversalInputData.Dispose();
                USPUniversalInputData = null;
                // ...
                IsSaved = false;
                USPUniversalInputDataRemoved(this, new EventArgs());
            }
            if (uspSample && USPSampleInputData != null)
            {
                USPSampleInputData.Dispose();
                USPSampleInputData = null;
                // ...
                IsSaved = false;
                USPSampleInputDataRemoved(this, new EventArgs());
            }
        }

        public void PerformAnalysis(IAnalysisOptions options)
        {
            IsSaved = false;
            switch (options.Algorithm)
            {
                case AnalysisAlgorithm.PCA:
                    var pcaResult = new PCAnalyzer((PCAOptions) options).Analyze();
                    analysisResults[AnalysisAlgorithm.PCA] = pcaResult;
                    PCAPerformed(this, new AnalysisPerformedEventArgs(pcaResult));
                    break;
                case AnalysisAlgorithm.KPCA:
                    var kpcaResult = new KPCAnalyzer((KPCAOptions) options).Analyze();
                    analysisResults[AnalysisAlgorithm.KPCA] = kpcaResult;
                    KPCAPerformed(this, new AnalysisPerformedEventArgs(kpcaResult));
                    break;
            }
        }

        public void PerformUSP(double constant)
        {
            var pcs = ((PCAResult)analysisResults[AnalysisAlgorithm.PCA]).PrincipalComponents;
            double[,] entryPcs = Projector.Project(pcs, USPSampleInputData, constant);
            //DataTable result = Projector.ProjectionToDataTable(entryPcs);
            //var result = new double[entryPcs.GetLength(0), twoDim ? 2 : 3];
            //for (int i = 0; i < result.GetLength(0); i++)
            //{
            //    for (int j = 0; j < result.GetLength(1); j++)
            //    {
            //        result[i, j] = entryPcs[i, j];
            //    }
            //}
            IsSaved = false;
            USPPerformed(this, new USPPerformedEventArgs(entryPcs));
        }
        
        public void Open()
        {
            if (openedProject != null)
            {
                openedProject.Close();
            }
            openedProject = this;
            ProjectOpened(this, new ProjectOpenedEventArgs(lastSavedApplicationSettings));
            if (AnalysisInputData != null)
            {
                AnalysisInputDataImported(this, new EventArgs());
            }
            if (USPUniversalInputData != null)
            {
                USPUniversalInputDataImported(this, new EventArgs());
            }
            if (USPSampleInputData != null)
            {
                USPSampleInputDataImported(this, new EventArgs());
            }
            if (analysisResults[AnalysisAlgorithm.PCA] != null)
            {
                PCAPerformed(this, new AnalysisPerformedEventArgs(analysisResults[AnalysisAlgorithm.PCA]));
            }
            if (analysisResults[AnalysisAlgorithm.KPCA] != null)
            {
                KPCAPerformed(this, new AnalysisPerformedEventArgs(analysisResults[AnalysisAlgorithm.KPCA]));
            }
            if (IsSaved)
            {
                ProjectSaved(this, new EventArgs());
            }
        }

        public void Save(ApplicationSettingsBase applicationSettings)
        {
            IsSaved = true;
            fileStream.Seek(0, SeekOrigin.Begin);
            new BinaryFormatter().Serialize(fileStream, this);
        }
        
        public void Close()
        {
            openedProject = null;
            ProjectClosed(this, new EventArgs());
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (AnalysisInputData != null)
                    {
                        AnalysisInputData.Dispose();
                    }
                    if (USPUniversalInputData != null)
                    {
                        USPUniversalInputData.Dispose();
                    }
                    if (USPSampleInputData != null)
                    {
                        USPSampleInputData.Dispose();
                    }
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
                disposed = true;
            }
        }
    }
}