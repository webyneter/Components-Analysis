using Accord.Math;
using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.PCA
{
    internal class PCAnalyzer : IAnalyzer<PCAOptions, PCAResult>
    {
        public PCAOptions Options => options;

        private readonly PCAOptions options;

        public PCAnalyzer(PCAOptions options) { this.options = options; }

        public PCAResult Analyze()
        {
            string[] columnNames;
            double[,] inputMatrix = options.InputData.ToMatrix(out columnNames);
            var da = new DescriptiveAnalysis(inputMatrix, columnNames);
            da.Compute();
            var pca = new PrincipalComponentAnalysis(da.Source, options.Method);
            pca.Compute();
            return new PCAResult(options.InputData,
                da.DeviationScores,
                da.StandardScores,
                columnNames,
                options.Method,
                da.Measures,
                da.CorrelationMatrix,
                da.CovarianceMatrix,
                pca.ComponentMatrix,
                pca.Components);
        }
    }
}