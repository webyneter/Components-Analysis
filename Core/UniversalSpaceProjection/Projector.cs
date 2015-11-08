using System.Data;

using Accord.Math;
using Accord.Statistics.Analysis;


namespace Webyneter.ComponentsAnalysis.Core.UniversalSpaceProjection
{
    public static class Projector
    {
        public static double[,] Project(PrincipalComponentCollection pcs, DataTable sampleData, double constant)
        {
            var rowPc = new double[sampleData.Rows.Count, pcs.Count];
            double[] sampleEntry;
            double[] pc;
            double pcNew;
            for (int rowInd = 0; rowInd < sampleData.Rows.Count; rowInd++)
            {
                sampleEntry = sampleData.Rows[rowInd].ItemArray.Convert(item => (double) item);
                for (int pcInd = 0; pcInd < pcs.Count; pcInd++)
                {
                    pc = pcs[pcInd].Eigenvector;
                    pcNew = constant;
                    for (int coordInd = 0; coordInd < pc.Length; coordInd++)
                    {
                        pcNew += sampleEntry[coordInd] * pc[coordInd];
                    }
                    rowPc[rowInd, pcInd] = pcNew;
                }
            }
            return rowPc;
        }

        public static DataTable ProjectionToDataTable(double[,] projection)
        {
            var result = new DataTable();
            int entriesCount = projection.GetLength(0);
            int pcsCount = projection.GetLength(1);
            //result.Columns.Add("Вхождение");
            for (int i = 0; i < pcsCount; i++)
            {
                result.Columns.Add("ГК " + i);
            }
            DataRow row;
            for (int i = 0; i < entriesCount; i++)
            {
                row = result.NewRow();
                for (int j = 0; j < pcsCount; j++)
                {
                    row[j] = projection[i, j];
                }
                result.Rows.Add(row);
            }
            return result;
        }
    }
}