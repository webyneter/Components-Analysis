using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.PCA
{
    public struct PCAOptions : IAnalysisOptions
    {
        public DataTable InputData { get { return inputData; } }
        public AnalysisAlgorithm Algorithm { get { return AnalysisAlgorithm.PCA; } }
        public AnalysisMethod Method { get { return method; } }

        private readonly DataTable inputData;
        private readonly AnalysisMethod method;

        public PCAOptions(DataTable inputData, AnalysisMethod method)
        {
            this.inputData = inputData;
            this.method = method;
        }
    }
}