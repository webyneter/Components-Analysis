using System.Data;

namespace Avtonomov.CraniometryDataAnalysis.Lib.FileWrappers
{
    public interface IFileWrapper
    {
        string FilePath { get; }
        DataTable Data { get; }
    }
}