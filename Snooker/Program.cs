/*****************************************************************************
 * Ferge Benjámin János <benjamin.ferge@protonmail.com>
 * 2020.07.07.
 * Programozás és adatbázis modulzáró vizsga
 ****************************************************************************/
using System;

namespace Snooker
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "snooker.txt";

            try {
                var exam = new Exam(path);
                exam.ShowAllResults();
            } catch (ExamException ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}