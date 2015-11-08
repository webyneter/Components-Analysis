using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis
{
    public interface IAnalysisOptions
    {
        DataTable InputData { get; }
        AnalysisAlgorithm Algorithm { get; }
        AnalysisMethod Method { get; }
    }
}