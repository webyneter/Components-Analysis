using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.PCA
{
    public struct PCAOptions : IAnalysisOptions
    {
        public DataTable InputData => inputData;
        public AnalysisAlgorithm Algorithm => AnalysisAlgorithm.PCA;
        public AnalysisMethod Method => method;

        private readonly DataTable inputData;
        private readonly AnalysisMethod method;

        public PCAOptions(DataTable inputData, AnalysisMethod method)
        {
            this.inputData = inputData;
            this.method = method;
        }
    }
}