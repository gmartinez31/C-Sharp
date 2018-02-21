﻿using System;
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

            try
            {
                Console.WriteLine("Enter your name: ");
                book.Name = Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            book.AddGrade(95);
            book.AddGrade(34);
            book.AddGrade(98.3f);


            GradeStatistics stats = book.ComputeStatistics();
            
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
            //WriteResult(stats.Description, stats.LetterGrade);
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
