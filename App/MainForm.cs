using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

using Accord.Controls;
using Accord.Statistics.Analysis;

using JoeWoodburyUtilities;

using Webyneter.ComponentsAnalysis.App.Properties;
using Webyneter.ComponentsAnalysis.Core;
using Webyneter.ComponentsAnalysis.Core.Analysis;
using Webyneter.ComponentsAnalysis.Core.Analysis.KPCA;
using Webyneter.ComponentsAnalysis.Core.Analysis.PCA;

using ZedGraph;

using Chart = AForge.Controls.Chart;

namespace Webyneter.ComponentsAnalysis.App
{
    public partial class MainForm : Form
    {
        private enum State : byte
        {
            FormInvisible,
            FormVisible,
            ProjectLoaded,
            AnalysisInputDataImported,
            AnalysisInputDataRemoved,
            USPSampleInputDataImported,
            USPSampleInputDataRemoved,
            PCAPerformed,
            KPCAPerformed,
            USPPerformed,
            ProjectSaved,
            ProjectChanged,
            ProjectClosed,
        }

        private readonly ResourceManager resourceManager;
        private readonly MruStripMenu recentsMenu;

        public MainForm()
        {
            try
            {
                InitializeComponent();

                TryAttachContextMenuToAccordViewWithGraph(cvPCA_ProportionsVisualization);
                TryAttachContextMenuToAccordViewWithGraph(cvPCA_DistributionVisualization);
                TryAttachContextMenuToAccordViewWithGraph(spvKPCA);
                TryAttachContextMenuToAccordViewWithGraph(cvKPCA_ProportionsVisualization);
                TryAttachContextMenuToAccordViewWithGraph(cvKPCA_DistributionVisualization);

                 resourceManager = new ResourceManager(typeof(MainForm));

                recentsMenu = new MruStripMenu(recentsToolStripMenuItem, OpenRecentProject,
                    Path.Combine(Settings.Default.RecentProjectsRegistryKey, Settings.Default.RecentProjectsDirName),
                    Settings.Default.RecentProjectsMemorised);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private bool TryAttachContextMenuToAccordViewWithGraph<TAccordView>(TAccordView view)
            where TAccordView : UserControl
        {
            var viewType = typeof(TAccordView);
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            var graphMemberType = typeof(ZedGraphControl);
            var graphMemberName = "Graph";
            
            var assumedGraphField = viewType.GetField(graphMemberName, bindingFlags);
            var assumedGraphProperty = viewType.GetProperty(graphMemberName, bindingFlags);

            if ((assumedGraphField == null || assumedGraphField.FieldType != graphMemberType)
                && (assumedGraphProperty == null || assumedGraphProperty.PropertyType != graphMemberType))
            {
                return false;
            }

            view.ContextMenuStrip = cmsAccordViewWithGraph;
            return true;
        }

        private void CatchException<TException>(TException exception, bool log = false) where TException : Exception
        {
            MessageBox.Show(exception.Message);
            if (log)
            {
                throw new NotImplementedException();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Project.ProjectOpened += (s, ea) =>
                {
                    var proj = (Project) s;
                    Text = GenerateFormTitle(proj);
                    recentsMenu.AddFile(proj.FilePath);
                    //foreach (ApplicationSettingsBase settings in ea.Settings)
                    //{
                    //    settings.CloneUserScopedSettingsTo(Settings.Default);
                    //}
                    SetState(State.ProjectLoaded);
                };
                Project.ProjectChanged += (s, ea) =>
                {
                    Text = GenerateFormTitle(((Project) s));
                    SetState(State.ProjectChanged);
                };
                Project.ProjectSaved += (s, ea) =>
                {
                    Text = GenerateFormTitle(((Project) s));
                    SetState(State.ProjectSaved);
                };
                Project.AnalysisInputDataImported += (s, ea) =>
                {
                    dgvInputDataOriginal.DataSource = ((Project) s).AnalysisInputData;
                    AdjustDataGridViews(DataGridViewSelectionMode.FullColumnSelect,
                        dgvInputDataOriginal);
                    SetState(State.AnalysisInputDataImported);
                };
                Project.AnalysisInputDataRemoved += (s, ea) =>
                {
                    PopulateInputDataTab(null);
                    PopulatePCATab(null);
                    PopulateKPCATab(null);
                    SetState(State.AnalysisInputDataRemoved);
                };

                Project.USPSampleInputDataImported += (s, ea) =>
                {
                    SetState(State.USPSampleInputDataImported);
                };
                Project.USPSampleInputDataRemoved += (s, ea) =>
                {
                    SetState(State.USPSampleInputDataRemoved);
                };

                Project.PCAPerformed += (s, ea) =>
                {
                    PopulateInputDataTab(ea.Result);
                    PopulatePCATab((PCAResult) ea.Result);
                    AdjustDataGridViews(DataGridViewSelectionMode.FullRowSelect,
                        dgvPCA_PrincipleComponents,
                        dgvPCA_Eigenvectors,
                        dgvKPCA_PrincipleComponents,
                        dgvKPCA_Eigenvectors);
                    AdjustDataGridViews(null,
                        dgvPCA_Correlation,
                        dgvPCA_Covariance);
                    SetState(State.PCAPerformed);
                };
                Project.KPCAPerformed += (s, ea) =>
                {
                    PopulateInputDataTab(ea.Result);
                    PopulateKPCATab((KPCAResult) ea.Result);
                    AdjustDataGridViews(DataGridViewSelectionMode.FullRowSelect,
                        dgvPCA_PrincipleComponents,
                        dgvPCA_Eigenvectors,
                        dgvKPCA_PrincipleComponents,
                        dgvKPCA_Eigenvectors);
                    AdjustDataGridViews(null,
                        dgvPCA_Correlation,
                        dgvPCA_Covariance);
                    SetState(State.KPCAPerformed);
                };
                Project.USPPerformed += (s, ea) =>
                {
                    float minX = float.MaxValue;
                    float maxX = float.MinValue;
                    for (int i = 0; i < ea.Result.GetLength(0); i++)
                    {
                        for (int j = 0; j < ea.Result.GetLength(1); j++)
                        {
                            if (ea.Result[i, j] < minX)
                            {
                                minX = (float)ea.Result[i, j];
                            }
                            else if (ea.Result[i, j] > maxX)
                            {
                                maxX = (float) ea.Result[i, j];
                            }
                        }
                    }
                    chartUSP2D.RangeX = new AForge.Range(minX, maxX);
                    // update the chart
                    chartUSP2D.UpdateDataSeries("USP", ExtractColumns(ea.Result, new []
                    {
                        0, 1
                    }));

                    SetState(State.USPPerformed);
                };
                Project.ProjectClosed += (s, ea) =>
                {
                    Text = resourceManager.GetString("MainFormTitle");
                    PopulateInputDataTab(null);
                    PopulatePCATab(null);
                    PopulateKPCATab(null);
                    SetState(State.ProjectClosed);
                };

                Icon = Properties.Resources.main_form_icon;

                Text = resourceManager.GetString("MainFormTitle");

                recentsMenu.RemoveAll();
                recentsMenu.SetFiles(recentsMenu.GetFiles());

                ofdProject.InitialDirectory = Settings.Default.ProjectFilesDir;
                ofdProject.Filter = string.Format("{0}|*.*|{1}|*{2}", resourceManager.GetString("AllFiles"),
                    resourceManager.GetString("ProjectFiles"), Project.ProjectFileExtension);
                ofdProject.FilterIndex = 1;

                //tcMain.TabPages.Remove(tpUSP);
                //tcUSP.TabPages.Remove(tpUSP3D);
                
                    chartUSP2D.AddDataSeries("USP", Color.Red, Chart.SeriesType.Dots, 3);
                
                SetState(State.FormInvisible);
                SetState(State.FormVisible);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private string GenerateFormTitle(Project proj)
        {
            return string.Format("{0}{1} - {2}", proj.Name, proj.IsSaved ? "" : "*", 
                resourceManager.GetString("MainFormTitle"));
        }

        private double[,] ExtractColumns(double[,] array, params int[] indices)
        {
            var result = new double[array.GetLength(0), indices.Length];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < indices.Length; j++)
                {
                    result[i, j] = array[i, indices[j]];
                }
            }
            return result;
        }

        private void AdjustDataGridViews(DataGridViewSelectionMode? selectionMode, params DataGridView[] dgvs)
        {
            foreach (var dgv in dgvs)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (selectionMode.HasValue)
                {
                    dgv.SelectionMode = selectionMode.Value;
                }
            }
        }

        private void SetState(State state)
        {
            Action<bool> setFormVisible = isVisible =>
            {
                createToolStripMenuItem.Enabled =
                    openToolStripMenuItem.Enabled =
                    recentsToolStripMenuItem.Enabled =
                    settingsToolStripMenuItem.Enabled =
                    exitToolStripMenuItem.Enabled =
                    analysisImportToolStripMenuItem.Enabled = isVisible;
            };
            Action<bool> setProjectLoaded = isLoaded =>
            {
                closeToolStripMenuItem.Enabled =
                    analysisToolStripMenuItem.Enabled = 
                    analysisInputToolStripMenuItem.Enabled = isLoaded;
            };
            Action<bool> setAnalysisInputDataImported = isImported =>
            {
                analysisRemoveToolStripMenuItem.Enabled =
                    analysisToolStripMenuItem.Enabled =
                    performPCAToolStripMenuItem.Enabled =
                    performKPCAToolStripMenuItem.Enabled = isImported;
                tcMain.Visible =
                    tcAnalysis.Visible =
                    tcAnalysisInputDataSubs.Visible = isImported;
            };
            Action<bool> setUSPSampleInputDataImported = isImported =>
            {
                uspProjectToolStripMenuItem.Enabled = isImported;
                //analysisRemoveToolStripMenuItem.Enabled =
                //        analysisToolStripMenuItem.Enabled =
                //        performPCAToolStripMenuItem.Enabled =
                //        performKPCAToolStripMenuItem.Enabled = isImported;
                //tcMain.Visible =
                //    tcAnalysis.Visible =
                //    tcAnalysisInputDataSubs.Visible = isImported;
            };
            Action<bool> setProjectSaved = isSaved =>
            {
                saveToolStripMenuItem.Enabled = !isSaved;
            };
            Action<bool> setPCAPerformed = performed =>
            {
                tcPCA.Visible = performed;
                analysisOutputToolStripMenuItem.Enabled =
                    dgvInputDataCentered.Visible =
                    dgvInputDataStandartized.Visible = 
                    dgvMeasures.Visible =
                    dhvFrequencies.Visible = performed;
                uspToolStripMenuItem.Enabled = performed;
            };
            Action<bool> setKPCAPerformed = performed =>
            {
                tcKPCA.Visible = performed;
                analysisOutputToolStripMenuItem.Enabled =
                    dgvInputDataCentered.Visible =
                    dgvInputDataStandartized.Visible =
                    dgvMeasures.Visible =
                    dhvFrequencies.Visible = performed;
            };
            Action<bool> setUspPerformed = performed =>
            {
            };

            switch (state)
            {
                case State.FormInvisible:
                    setFormVisible(false);
                    setProjectLoaded(false);
                    setAnalysisInputDataImported(false);
                    setProjectSaved(true);
                    setPCAPerformed(false);
                    setKPCAPerformed(false);
                    setUspPerformed(false);
                    break;
                case State.FormVisible:
                    setFormVisible(true);
                    break;
                case State.ProjectLoaded:
                    setProjectLoaded(true);
                    break;
                case State.AnalysisInputDataImported:
                    setAnalysisInputDataImported(true);
                    break;
                case State.AnalysisInputDataRemoved:
                    setAnalysisInputDataImported(false);
                    setPCAPerformed(false);
                    setKPCAPerformed(false);
                    break;
                case State.USPSampleInputDataImported:
                    setUSPSampleInputDataImported(true);
                    break;
                case State.USPSampleInputDataRemoved:
                    setUSPSampleInputDataImported(false);
                    break;
                case State.PCAPerformed:
                    setPCAPerformed(true);
                    break;
                case State.KPCAPerformed:
                    setKPCAPerformed(true);
                    break;
                case State.USPPerformed:
                    setUspPerformed(true);
                    break;
                case State.ProjectSaved:
                    setProjectSaved(true);
                    break;
                case State.ProjectChanged:
                    setProjectSaved(false);
                    break;
                case State.ProjectClosed:
                    SetState(State.FormInvisible);
                    SetState(State.FormVisible);
                    break;
            }
        }

        private void PopulateInputDataTab(IAnalysisResult result)
        {
            dgvInputDataOriginal.SelectionMode =
                dgvInputDataCentered.SelectionMode =
                dgvInputDataStandartized.SelectionMode =
                dgvMeasures.SelectionMode = default(DataGridViewSelectionMode);
            if (result != null)
            {
                dgvInputDataOriginal.DataSource = result.InputData;
                dgvInputDataCentered.DataSource = new ArrayDataView(result.InputDataDeviationScores,
                    result.ColumnNames);
                dgvInputDataStandartized.DataSource = new ArrayDataView(result.InputDataStandardScores, 
                    result.ColumnNames);
                dgvMeasures.DataSource = result.Measures;
            }
            else
            {
                dgvInputDataOriginal.DataSource = null;
                dgvInputDataCentered.DataSource = null;
                dgvInputDataStandartized.DataSource = null;
                dgvMeasures.DataSource = null;
            }
        }

        private void PopulatePCATab(PCAResult? result)
        {
            dgvPCA_PrincipleComponents.SelectionMode =
                dgvPCA_Eigenvectors.SelectionMode =
                dgvPCA_Correlation.SelectionMode =
                dgvPCA_Covariance.SelectionMode = default(DataGridViewSelectionMode);
            if (result != null)
            {
                var r = result.Value;
                cvPCA_ProportionsVisualization.DataSource = r.PrincipalComponents;
                cvPCA_DistributionVisualization.DataSource = r.PrincipalComponents;
                dgvPCA_PrincipleComponents.DataSource = r.PrincipalComponents;
                dgvPCA_Eigenvectors.DataSource = new ArrayDataView(r.ComponentMatrix);
                dgvPCA_Correlation.DataSource = new ArrayDataView(r.CorrelationMatrix, r.ColumnNames);
                dgvPCA_Covariance.DataSource = new ArrayDataView(r.CovarianceMatrix, r.ColumnNames);
            }
            else
            {
                //cvPCA_ProportionsVisualization.DataSource = null;
                //cvPCA_DistributionVisualization.DataSource = null;
                dgvPCA_PrincipleComponents.DataSource = null;
                dgvPCA_Eigenvectors.DataSource = null;
                dgvPCA_Correlation.DataSource = null;
                dgvPCA_Covariance.DataSource = null;
            }
        }
        
        private void PopulateKPCATab(KPCAResult? result)
        {
            dgvKPCA_PrincipleComponents.SelectionMode =
                dgvKPCA_Eigenvectors.SelectionMode = default(DataGridViewSelectionMode);
            if (result != null)
            {
                var r = result.Value;
                spvKPCA.DataSource = r.ScatterPlotValues;
                dgvKPCA_PrincipleComponents.DataSource = r.PrincipalComponents;
                cvKPCA_ProportionsVisualization.DataSource = r.PrincipalComponents;
                cvKPCA_DistributionVisualization.DataSource = r.PrincipalComponents;
                dgvPCA_Eigenvectors.DataSource = new ArrayDataView(r.ComponentMatrix);
            }
            else
            {
                spvKPCA.DataSource = null;
                //cvKPCA_ProportionsVisualization.DataSource = null;
                //cvKPCA_DistributionVisualization.DataSource = null;
                dgvKPCA_PrincipleComponents.DataSource = null;
                dgvKPCA_Eigenvectors.DataSource = null;
            }
        }

        private bool TryCloseProject(Project proj)
        {
            if (!proj.IsSaved)
            {
                switch (new AskSaveProjectChangesForm().ShowDialog())
                {
                    case DialogResult.Yes:
                        proj.Save(Settings.Default);
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            proj.Close();
            return true;
        }

        private void OpenRecentProject(int number, string filename)
        {
            if (File.Exists(filename))
            {
                recentsMenu.SetFirstFile(number);
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("ProjectFileNotExists"));
                recentsMenu.RemoveFile(number);
            }
        }

        private void WithOpenedProject(Action<Project> callback)
        {
            Project project;
            if (Project.TryGetOpenedProject(out project))
            {
                callback(project);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool doReturn = false;
                WithOpenedProject(
                    p =>
                    {
                        if (!TryCloseProject(p))
                        {
                            doReturn = true;
                        }
                    });
                if (doReturn)
                {
                    return;
                }
                Close();
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var settingsForm = new SettingsForm();
                WithOpenedProject(p => settingsForm.ImportedInputData = p.AnalysisInputData);
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithOpenedProject(p => TryCloseProject(p));
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool doReturn = false;
                WithOpenedProject(
                    p =>
                    {
                        if (!TryCloseProject(p))
                        {
                            doReturn = true;
                        }
                    });
                if (doReturn)
                {
                    return;
                }
                var cpForm = new CreateProjectForm();
                if (cpForm.ShowDialog() == DialogResult.OK)
                {
                    new Project(cpForm.ProjectFilePath).Open();
                }
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdProject.ShowDialog() == DialogResult.OK)
                {
                    bool doReturn = false;
                    WithOpenedProject(
                        p =>
                        {
                            if (!TryCloseProject(p))
                            {
                                doReturn = true;
                            }
                        });
                    if (doReturn)
                    {
                        return;
                    }
                    Project.Load(ofdProject.FileName).Open();
                }
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new AboutForm().Show();
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void ImportInputData(bool analysis, bool uspUniv, bool uspSample)
        {
            WithOpenedProject(
                p =>
                {
                    if (analysis)
                    {
                        if (p.AnalysisInputData != null)
                        {
                            switch (new AskRemoveInputDataForm().ShowDialog())
                            {
                                case DialogResult.Yes:
                                    p.RemoveInputData(true, false, false);
                                    break;
                                case DialogResult.No:
                                case DialogResult.Cancel:
                                    return;
                            }
                        }
                        var iidForm = new ImportInputDataForm();
                        if (iidForm.ShowDialog() == DialogResult.OK)
                        {
                            p.ImportInputData(iidForm.ExcelData ?? iidForm.ExcelData ?? iidForm.XmlData, null, null);
                        }
                    }
                    else if (uspUniv)
                    {
                        if (p.USPUniversalInputData != null)
                        {
                            switch (new AskRemoveInputDataForm().ShowDialog())
                            {
                                case DialogResult.Yes:
                                    p.RemoveInputData(false, true, false);
                                    break;
                                case DialogResult.No:
                                case DialogResult.Cancel:
                                    return;
                            }
                        }
                        var iidForm = new ImportInputDataForm();
                        if (iidForm.ShowDialog() == DialogResult.OK)
                        {
                            p.ImportInputData(null, iidForm.ExcelData ?? iidForm.ExcelData ?? iidForm.XmlData, null);
                        }
                    } 
                    else if (uspSample)
                    {
                        if (p.USPSampleInputData != null)
                        {
                            switch (new AskRemoveInputDataForm().ShowDialog())
                            {
                                case DialogResult.Yes:
                                    p.RemoveInputData(false, false, true);
                                    break;
                                case DialogResult.No:
                                case DialogResult.Cancel:
                                    return;
                            }
                        }
                        var iidForm = new ImportInputDataForm();
                        if (iidForm.ShowDialog() == DialogResult.OK)
                        {
                            p.ImportInputData(null, null, iidForm.ExcelData ?? iidForm.ExcelData ?? iidForm.XmlData);
                        }
                    }
                });
        }

        private void analysisImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImportInputData(true, false, false);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void uspUnivImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImportInputData(false, true, false);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void uspSampleImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImportInputData(false, false, true);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithOpenedProject(p => p.Save(Settings.Default));
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void RemoveInputData(bool analysis, bool uspUniv, bool uspSample)
        {
            WithOpenedProject(
                p =>
                {
                    if (new AskRemoveInputDataForm().ShowDialog() == DialogResult.Yes)
                    {
                        p.RemoveInputData(analysis, uspUniv, uspSample);
                    }
                });
        }

        private void analysisRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveInputData(true, false, false);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void uspUnivRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveInputData(false, true, false);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void uspSampleRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveInputData(false, false, true);
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void performPCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithOpenedProject(p => p.PerformAnalysis(new PCAOptions(p.AnalysisInputData, 
                    Settings.Default.PCAMethod)));
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void performKPCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithOpenedProject(p => p.PerformAnalysis(new KPCAOptions(p.AnalysisInputData, 
                    Settings.Default.KPCAMethod, Settings.Default.KPCACenterInFeatureSpace, 
                    Settings.Default.KPCAKernelKind, Settings.Default.KPCASigma, Settings.Default.KPCADegree, 
                    Settings.Default.KPCAConstant)));
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void dgvMeasures_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMeasures.CurrentRow != null)
                {
                    dhvFrequencies.DataSource = ((DescriptiveMeasures) dgvMeasures.CurrentRow.DataBoundItem).Samples;
                }
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }

        private void uspProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithOpenedProject(p => p.PerformUSP(0));
            }
            catch (Exception ex)
            {
                CatchException(ex);
            }
        }
    }
}