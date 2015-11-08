using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis.KPCA
{
    public struct KPCAOptions : IAnalysisOptions
    {
        public DataTable InputData { get { return inputData; } }
        public AnalysisAlgorithm Algorithm { get { return AnalysisAlgorithm.KPCA; } }
        public AnalysisMethod Method { get { return method; } }
        public bool Center { get { return center; } }
        public KPCAKernelKind KpcaKernel { get { return kpcaKernel; } }
        public double? Sigma { get { return sigma; } }
        public int? Degree { get { return degree; } }
        public double? Constant { get { return constant; } }
        
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