using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.KPCA
{
    public struct KPCAOptions : IAnalysisOptions
    {
        public DataTable InputData => inputData;
        public AnalysisAlgorithm Algorithm => AnalysisAlgorithm.KPCA;
        public AnalysisMethod Method => method;
        public bool Center => center;
        public KPCAKernelKind KpcaKernel => kpcaKernel;
        public double? Sigma => sigma;
        public int? Degree => degree;
        public double? Constant => constant;

        private readonly DataTable inputData;
        private readonly AnalysisMethod method;
        private readonly bool center;
        private readonly KPCAKernelKind kpcaKernel;
        private readonly double? sigma;
        private readonly int? degree;
        private readonly double? constant;

        public KPCAOptions(DataTable inputData, AnalysisMethod method, bool center, KPCAKernelKind kpcaKernel, double? sigma, 
            int? degree, double? constant)
        {
            this.inputData = inputData;
            this.method = method;
            this.center = center;
            this.kpcaKernel = kpcaKernel;
            this.sigma = sigma;
            this.degree = degree;
            this.constant = constant;
        }
    }
}