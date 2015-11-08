namespace Webyneter.ComponentsAnalysis.Core.Analysis
{
    internal interface IAnalyzer<out TOptions, out TResult> 
        where TOptions : IAnalysisOptions
        where TResult : IAnalysisResult
    {
        TOptions Options { get; }
        TResult Analyze();
    }
}