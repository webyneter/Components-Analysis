using System;
using System.Data;
using System.IO;

namespace Avtonomov.CraniometryDataAnalysis.Lib.FileWrappers
{
    public sealed class XmlFileWrapper : IFileWrapper
    {
        public string FilePath
        {
            get { return filePath; }
        }
        public DataTable Data
        {
            get { return data; }
        }

        private readonly string filePath;
        private readonly DataTable data;

        public XmlFileWrapper(string filePath)
        {
            if (!Path.GetExtension(filePath).Equals(".xml", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(Lib.XmlFileExpected, "filePath");
            }
            this.filePath = filePath;
            data = new DataTable();
            data.ReadXml(filePath);
        }
    }
}