using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using ConsoleApp2;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SayHello();
            GradeTracker book = CreateGradeBook();
            GetBookName(book);
            AddGrades(book);
            OutputToNewFile(book);
            WriteResults(book);
        }

        private static GradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
            //WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void AddGrades(GradeTracker book)
        {
            book.AddGrade(95);
            book.AddGrade(34);
            book.AddGrade(98.3f);
        }

        private static void OutputToNewFile(GradeTracker book)
        {
            StreamWriter outputFile = File.CreateText("grades.txt");
            book.WriteGrades(outputFile);
            outputFile.Close();

            // or
            //using(StreamWriter outputFile = File.CreateText("grades.txt"){
            //    book.WriteGrades(outputFile);
            //}
        }

        private static void SayHello()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, World!");
        }

        private static void GetBookName(GradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter your name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }
    }
}
