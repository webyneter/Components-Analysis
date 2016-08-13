using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Kernels;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.KPCA
{
    internal class KPCAnalyzer : IAnalyzer<KPCAOptions, KPCAResult>
    {
        public KPCAOptions Options => options;

        private readonly KPCAOptions options;

        public KPCAnalyzer(KPCAOptions options) { this.options = options; }

        public KPCAResult Analyze()
        {
            string[] columnNames;
            double[,] inputDataMatrix = options.InputData.ToMatrix(out columnNames);
            var da = new DescriptiveAnalysis(inputDataMatrix, columnNames);
            da.Compute();
            IKernel kernel = null;
            switch (options.KpcaKernel)
            {
                case KPCAKernelKind.Gaussian:
                    kernel = new Gaussian(options.Sigma.Value);
                    break;
                case KPCAKernelKind.Polynomial:
                    kernel = new Polynomial(options.Degree.Value, options.Constant.Value);
                    break;
            }
            double[,] inputs = inputDataMatrix.GetColumns(0, 1);
            var kpca = new KernelPrincipalComponentAnalysis(inputs, kernel, options.Method);
            kpca.Center = options.Center;
            kpca.Compute();
            double[,] result;
            if (kpca.Components.Count >= 2)
            {
                result = kpca.Transform(inputs, 2);
            }
            else
            {
                result = kpca.Transform(inputs, 1);
                result = result.InsertColumn(Matrix.Vector(result.GetLength(0), 0.0));
            }
            //double[,] points = result.InsertColumn(inputDataMatrix.GetColumn(2));

            return new KPCAResult(options.InputData,
                da.DeviationScores,
                da.StandardScores,
                columnNames,
                options.Method,
                da.Measures,
                inputDataMatrix,
                kpca.ComponentMatrix,
                kpca.Components);
        }
    }
}