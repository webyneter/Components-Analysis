using System;
using System.Data;
using System.IO;
using System.Text;


namespace Webyneter.ComponentsAnalysis.Core.Miscellaneous
{
    public class ExcelProvider
    {
        public static void Export(DataTable dt, string fileName)
        {
            if (!Path.GetExtension(fileName).Equals(".xls", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Not an Excel file!", fileName);
            }
            string stOutput = "";
            string sHeaders = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                sHeaders = sHeaders + dt.Rows[0][j] + "\t";
            }
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    stLine = stLine + dt.Rows[i][j] + "\t";   
                }
                stOutput += stLine + "\r\n";
            }
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var bw = new BinaryWriter(fs))
            {
                byte[] output = Encoding.GetEncoding(1254).GetBytes(stOutput);
                bw.Write(output, 0, output.Length);
                bw.Flush();
            }
        }
    }
}