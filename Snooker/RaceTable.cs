using System;
using System.Collections.Generic;
using System.Linq;

namespace Snooker
{
    public class RaceTable
    {
        public readonly List<RaceRecord> Records;
        public static int ColumnCount = 4;
        public string[] Headers = new string[ColumnCount];
        public static char SplitBy = ';';

        public RaceTable(string[] columnNames, List<RaceRecord> records)
        {
            int colc = columnNames.Length;
            if (colc != ColumnCount)
            {
                throw new ExamException(
                    String.Format("Nem megfelelő oszlopszám!" +
                        "Várt: {0}, kapott: {1}", colc, ColumnCount));
            }
            Headers = columnNames;
            Records = records;
        }

        public double AvgPrize()
        {
            return Records.Average(r => r.GetPrize());
        }

        public RaceRecord GetBestChinese()
        {
            return Records
                .Where(r => r.GetNation() == RaceRecord.China)
                .OrderByDescending(r => r.GetPrize())
                .First();
        }

        public bool HasNorway()
        {
            return Records.FirstOrDefault(r => r.IsNorwegian()) != null;
        }

        public Dictionary<string, int> AtLeast4Person()
        {
            var res = Records
                .GroupBy(r => r.GetNation())
                .Where(r => r.Count() > 4)
                .ToDictionary(r => r.Key, r => r.Count());
            return res;
        }
    }

}
