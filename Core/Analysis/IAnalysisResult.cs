using System.Data;

using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.Analysis
{
    public interface IAnalysisResult
    {
        DataTable InputData { get; }
        double[,] InputDataDeviationScores { get; }
        double[,] InputDataStandardScores { get; }
        string[] ColumnNames { get; }
        DescriptiveMeasureCollection Measures { get; }
    }
}