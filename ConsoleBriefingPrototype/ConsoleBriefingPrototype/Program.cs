using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBriefingPrototype
{
    class Program
    {
        private static string feeling;
        private static string[] questions = { "What are you excited about? ", "What are you grateful for? ", "What are you looking forward to? ", "What was good yesterday? ", "What was bad? ", "What is your goal for the day? " };
        private static string[] answers = new string[6];
        private static DateTime d; 
        static void Main(string[] args)
        {
            Console.WriteLine("How are you feeling today? [from 1 - 10]: ");
            feeling = getNumAsString();
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                answers[i] = getStringAsString();
            }

            d = DateTime.Today;
            if (!System.IO.Directory.Exists("c:\\briefings"))
            {
                System.IO.Directory.CreateDirectory("c:\\briefings");
            }
            string path = "c:\\briefings\\"+d.ToString("d-M-yyyy")+"_briefing.txt";
            string briefing = "============================\r\nI'm feeling " + feeling + " out of 10\r\ni'm excited about " + answers[0] + "\r\ni'm grateful for " + answers[1] + "\r\ni'm looking forward to " + answers[2] + "\r\nsomething good yesterday was " + answers[3] + "\r\nsomething bad was " + answers[4] + "\r\nmy goal for the day is " + answers[5] + "\r\n============================";
            System.IO.File.WriteAllText(path, briefing);
            Console.WriteLine(path);
            Console.WriteLine("============================\n");
            Console.WriteLine("I'm feeling " + feeling + " out of 10\n");
            Console.WriteLine("i'm excited about " + answers[0] + "\n");
            Console.WriteLine("i'm grateful for " + answers[1] + "\n");
            Console.WriteLine("i'm looking forward to " + answers[2] + "\n");
            Console.WriteLine("something good yesterday was " + answers[3] + "\n");
            Console.WriteLine("something bad was " + answers[4] + "\n");
            Console.WriteLine("my goal for the day is " + answers[5] + "\n");
            Console.WriteLine("============================");
            Console.ReadLine();
        }

        static string getNumAsString()
        {
            bool fl = false;
            string str = Console.ReadLine();
            int num = int.Parse(str);
            while (!fl)
            {
                if (num < 0 || num > 10)
                {
                    fl = false;
                }
                else
                {
                    fl = true;
                }
            }
            return str;
        }

        static string getStringAsString()
        {
            return Console.ReadLine();
        }
    }
}
