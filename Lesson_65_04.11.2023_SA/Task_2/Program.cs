using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "text.txt"; 
            int index;

            StreamReader file = new StreamReader(path);
            string text = file.ReadToEnd();
            file.Close();

            do
            {
                Task[] tasks = new Task[5]
                {
                    new Task(() => CountSentences(text)),
                    new Task(() => CountSymbols(text)),
                    new Task(() => CountWords(text)),
                    new Task(() => CountQuestions(text)),
                    new Task(() => CountExclamators(text))
                };

                Console.WriteLine("\ncount sentences - 1\ncount symbols - 2\ncount words - 3");
                Console.WriteLine("count question sentences - 4\ncount exclamatory sentences - 5");
                Console.Write("\n\nEnter how many tasks you need to do (from 1 to 5): ");

                int count_task;   // кількість обраних завдань
                do
                {
                    count_task = Convert.ToInt32(Console.ReadLine());
                    if (count_task < 1 || count_task > 5)
                        Console.Write("Incorrect! Try again: ");
                } while (count_task < 1 || count_task > 5);
                Console.WriteLine();

                int[] numbers_tasks = new int[count_task];
                for(int i = 1; i <= count_task; i++)            // введення номерів обраних tasks
                {
                    int number;   // номер обраного завдання
                    bool control; // контрольна змінна                                    
                    do
                    {
                        control = false;
                        Console.Write("Enter task number (" + i + "): ");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number < 1 || number > 5)
                        {
                            Console.WriteLine("Incorrect! Try again.");
                            control = true;
                        }
                        else if (numbers_tasks.Contains(number))
                        {
                            Console.WriteLine("Such task is already selected! Try again.");
                            control = true;
                        }
                    } while (control);
                    numbers_tasks[i - 1] = number;
                }
                Console.WriteLine();

                foreach (var num_task in numbers_tasks) // запуск tasks
                {
                    tasks[num_task - 1].Start();
                    //tasks[num_task - 1].Wait();
                }

                Task.WaitAll();
                Console.ReadKey(); 

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);
        }

        static void CountSentences(string text)
        {
            string[] sentences = text.Split(new char[] { '.', '!', '?' });
            Console.WriteLine("Task 1: counting sentences...");
            Thread.Sleep(1500); // Task.Delay(1500);        // Task.Delay не працює
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
