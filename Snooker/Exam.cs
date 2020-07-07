using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snooker
{
    public class Exam
    {
        private RaceTable _table;

        public static void PrintTask(int n)
        {
            Console.Write("{0}. feladat: ", n);
        }

        public Exam(string path)
        {
            var records = new List<RaceRecord>();
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            bool first = true;
            var headers = new string[RaceTable.ColumnCount];
            using (StreamReader sr = File.OpenText(path))
            {
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    if (first)
                    {
                        first = false;
                        headers = line.Split(RaceTable.SplitBy);
                    }
                    else
                    {
                        records.Add(RaceRecord.Create(line));
                    }
                }
            }
            _table = new RaceTable(headers, records);
        }

        private void Task3()
        {
            PrintTask(3);
            Console.WriteLine("A világranglistán {0} versenyző szerepel",
                _table.Records.Count);
        }

        private void Task4()
        {
            PrintTask(4);
            Console.WriteLine(
                "A versenyzők átlagosan {0:0.00} fontot kerestek",
                    _table.AvgPrize());
        }

        private void Task5()
        {
            PrintTask(5);
            var bestChinese = _table.GetBestChinese();
            Console.WriteLine("A legjobban kereső kínai versenyző:\n{0}", bestChinese);
        }

        private void Task6()
        {
            PrintTask(6);
            Console.WriteLine("A feladat között {0} norvég versenyző",
                (_table.HasNorway() ? "van" : "nincs"));
        }

        private void Task7()
        {
            PrintTask(7);
            var result = _table.AtLeast4Person();
            Console.WriteLine("Statisztika");
            foreach (var r in result)
            {
                Console.WriteLine("\t{0} - {1} fő", r.Key, r.Value);
            }
        }

        public void ShowAllResults()
        {
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
        }
    }
}
