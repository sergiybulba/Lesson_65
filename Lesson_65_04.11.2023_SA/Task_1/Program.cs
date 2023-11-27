using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "text.txt";
            StreamReader file = new StreamReader(path);
            string text = file.ReadToEnd();
            file.Close();

            Task task_1 = Task.Run(() => CountSentences(text));
            Task task_2 = Task.Run(() => CountSymbols(text));
            Task task_3 = Task.Run(() => CountWords(text));
            Task task_4 = Task.Run(() => CountQuestions(text));
            Task task_5 = Task.Run(() => CountExclamators(text));

            task_1.Wait();
            task_2.Wait();
            task_3.Wait();
            task_4.Wait();
            task_5.Wait();
            Console.ReadKey();
        }

        static void CountSentences(string text)
        {
            string[] sentences = text.Split(new char[] { '.', '!', '?' });
            Console.WriteLine("Task 1: counting sentences...");
            Thread.Sleep(1500); // Task.Delay(1500);        // Task.Delay  не працює
            Console.WriteLine();
            Console.WriteLine("Task 1: count sentences: " + sentences.Length);
        }

        static void CountSymbols(string text)
        {
            Console.WriteLine("Task 2: counting symbols...");
            Thread.Sleep(1500); // Task.Delay(1500);
            Console.WriteLine("Task 2: count symbols: " + text.Length);
        }

        static void CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', ',', '.', '(', ')', '!', '?' });
            Console.WriteLine("Task 3: counting words...");
            Thread.Sleep(1500); // Task.Delay(1500);
            Console.WriteLine("Task 3: count words: " + words.Length);
        }

        static void CountQuestions(string text)
        {
            int count = text.Count(x => x == '?');
            Console.WriteLine("Task 4: counting question sentences ...");
            Thread.Sleep(1500); // Task.Delay(1500);
            Console.WriteLine("Task 4: count question sentences: " + count);
        }

        static void CountExclamators(string text)
        {
            int count = text.Count(x => x == '!');
            Console.WriteLine("Task 5: counting exclamatory sentences ...");
            Thread.Sleep(1500); // Task.Delay(1500);
            Console.WriteLine("Task 5: count exclamatory sentences: " + count);
        }
    }
}
