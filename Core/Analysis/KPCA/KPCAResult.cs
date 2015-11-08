using System;
using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.KPCA
{
    [Serializable]
    public struct KPCAResult : IAnalysisResult
    {
        public DataTable InputData { get { return inputData; } }
        public double[,] InputDataDeviationScores { get { return inputDataDeviationScores; } }
        public double[,] InputDataStandardScores { get { return inputDataStandardScores; } }
        public string[] ColumnNames { get { return columnNames; } }
        public AnalysisMethod Method { get { return method; } }
        public DescriptiveMeasureCollection Measures { get { return measures; } }
        public double[,] ScatterPlotValues { get { return scatterPlotValues; } }
        public double[,] ComponentMatrix { get { return componentMatrix; } }
        public PrincipalComponentCollection PrincipalComponents { get { return principalComponents; } }

        private readonly DataTable inputData;
        private readonly double[,] inputDataDeviationScores;
        private readonly double[,] inputDataStandardScores;
        private readonly string[] columnNames;
        private readonly AnalysisMethod method;
        private readonly DescriptiveMeasureCollection measures;
        private readonly double[,] scatterPlotValues;
        private readonly double[,] componentMatrix;
        private readonly PrincipalComponentCollection principalComponents;

        public KPCAResult(DataTable inputData, double[,] inputDataDeviationScores, double[,] inputDataStandardScores, 
            string[] columnNames, AnalysisMethod method, DescriptiveMeasureCollection measures, 
            double[,] scatterPlotValues, double[,] componentMatrix, PrincipalComponentCollection principalComponents)
        {
            this.inputData = inputData;
            this.inputDataDeviationScores = inputDataDeviationScores;
            this.inputDataStandardScores = inputDataStandardScores;
            this.columnNames = columnNames;
            this.method = method;
            this.measures = measures;
            this.scatterPlotValues = scatterPlotValues;
            this.componentMatrix = componentMatrix;
            this.principalComponents = principalComponents;
        }
    }
}