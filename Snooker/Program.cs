/*****************************************************************************
 * Ferge Benjámin János <benjamin.ferge@protonmail.com>
 * 2020.07.07.
 * Programozás és adatbázis modulzáró vizsga
 ****************************************************************************/
using System;
using System.IO;

namespace Snooker
{
    class Program
    {
        static void Main(string[] args)
        {
            string expected = "snooker.txt";
            string path = (args.Length > 0) ? args[0] : expected;
            if (!File.Exists(path))
            {
                throw new ExamException(
                    String.Format("A keresett fájl nem található: {0}\n" +
                    	"Kérem adja meg a fájl elérési útvonalát " +
                    	"első argumentumként, vagy legyen elérhető a " +
                    	"\"{1}\" fájlnév.", path, expected));
            }
            var exam = new Exam(path);
            exam.ShowAllResults();
        }
    }
}