using System.Data;


namespace Webyneter.ComponentsAnalysis.Miscellaneous.ExtensionMethods
{
    public static class DataTableExtensionMethods
    {
        public static void ReplaceAllOccurrences(this DataTable dt, object ofWhat, object withWhat)
        {
            for (int r = 0; r < dt.Rows.Count; ++r)
            {
                for (int c = 0; c < dt.Columns.Count; ++c)
                {
                    if (dt.Rows[r][c].Equals(ofWhat))
                    {
                        dt.Rows[r][c] = withWhat;
                    }
                }
            }
            dt.AcceptChanges();
        }

        public static DataTable ExtractColumns(this DataTable dt, params int[] indices)
        {
            var result = new DataTable();
            int rowsCount = dt.Rows.Count;
            int colsToExtractCount = indices.Length;
            for (int colInd = 0; colInd < colsToExtractCount; colInd++)
            {
                result.Columns.Add(dt.Columns[indices[colInd]].ColumnName);
            }
            DataRow row;
            for (int rowInd = 0; rowInd < rowsCount; rowInd++)
            {
                row = result.NewRow();
                for (int i = 0; i < colsToExtractCount; i++)
                {
                    row[i] = dt.Rows[rowInd][indices[i]];
                }
                result.Rows.Add(row);
            }
            result.AcceptChanges();
            return result;
        }
    }
}