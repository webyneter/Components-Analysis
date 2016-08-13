using System;
using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.PCA
{
    [Serializable]
    public struct PCAResult : IAnalysisResult
    {
        public DataTable InputData => inputData;
        public double[,] InputDataDeviationScores => inputDataDeviationScores;
        public double[,] InputDataStandardScores => inputDataStandardScores;
        public string[] ColumnNames => columnNames;
        public AnalysisMethod Method => method;
        public DescriptiveMeasureCollection Measures => measures;
        public double[,] CorrelationMatrix => correlationMatrix;
        public double[,] CovarianceMatrix => covarianceMatrix;
        public double[,] ComponentMatrix => componentMatrix;
        public PrincipalComponentCollection PrincipalComponents => principalComponents;

        private readonly DataTable inputData;
        private readonly double[,] inputDataDeviationScores;
        private readonly double[,] inputDataStandardScores;
        private readonly string[] columnNames;
        private readonly AnalysisMethod method;
        private readonly DescriptiveMeasureCollection measures;
        private readonly double[,] correlationMatrix;
        private readonly double[,] covarianceMatrix;
        private readonly double[,] componentMatrix;
        private readonly PrincipalComponentCollection principalComponents;

        public PCAResult(DataTable inputData, double[,] inputDataDeviationScores, double[,] inputDataStandardScores, 
            string[] columnNames, AnalysisMethod method, DescriptiveMeasureCollection measures, 
            double[,] correlationMatrix, double[,] covarianceMatrix, double[,] componentMatrix, 
            PrincipalComponentCollection principalComponents)
        {
            this.inputData = inputData;
            this.inputDataDeviationScores = inputDataDeviationScores;
            this.inputDataStandardScores = inputDataStandardScores;
            this.columnNames = columnNames;
            this.method = method;
            this.measures = measures;
            this.correlationMatrix = correlationMatrix;
            this.covarianceMatrix = covarianceMatrix;
            this.componentMatrix = componentMatrix;
            this.principalComponents = principalComponents;
        }
    }
}