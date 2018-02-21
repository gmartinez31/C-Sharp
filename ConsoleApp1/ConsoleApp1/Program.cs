using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine(name + ", how many hours of sleep did you get?");
            int hoursSlept = int.Parse(Console.ReadLine());

            if (hoursSlept < 8)
            {
                Console.WriteLine("Get more sleep!");
            }
            else
            {
                Console.WriteLine("You good bruh.");
            }
         }
    }
}
