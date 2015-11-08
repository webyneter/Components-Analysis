using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using Accord.IO;

namespace Avtonomov.CraniometryDataAnalysis.Lib.FileWrappers
{
    public sealed class ExcelFileWrapper : IFileWrapper
    {
        public string FilePath
        {
            get { return filePath; }
        }
        public DataTable Data
        {
            get { return excelReader.GetWorksheet(CurrentWorksheet); }
            set
            {

            }
        }
        public string CurrentWorksheet { get; private set; }

        private readonly string filePath;
        private readonly ExcelReader excelReader;
        private readonly string[] worksheetNamesCached;

        public ExcelFileWrapper(string filePath, bool hasHeaders = true,
            bool hasMixedData = false)
        {
            string ext = Path.GetExtension(filePath);
            if (!ext.Equals(".xls", StringComparison.OrdinalIgnoreCase)
                && !ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(Lib.ExcelFileExpected, "filePath");
            }
            this.filePath = filePath;
            excelReader = new ExcelReader(filePath, hasHeaders, hasMixedData);
            worksheetNamesCached = excelReader.GetWorksheetList();
        }

        public void SelectCurrentWorksheet(string name)
        {
            if (!worksheetNamesCached.Contains(name))
            {
                throw new ArgumentOutOfRangeException(Lib.ExcelWorksheetDoesNotExist, "name");
            }
            CurrentWorksheet = name;
        }

        public IEnumerable<string> GetWorksheetNames() { return worksheetNamesCached.AsEnumerable(); }

    }
}
