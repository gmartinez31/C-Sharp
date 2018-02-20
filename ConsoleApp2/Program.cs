using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using ConsoleApp2;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, World!");

            Gradebook book = new Gradebook();

            book.NameChanged = new NameChangedDelegate(OnNameChanged);

            book.Name = "Goose's Gradebook";
            book.AddGrade(95);
            book.AddGrade(34);
            book.AddGrade(98.3f);


            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", (int)stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine("{0}: {1}", description, result);
            //or
            // cw($"{description}: {result}");
        }
    }
}
