using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        static int[] numbers;
        static int size, value;
        static void Main(string[] args)
        {
            int index;
            do
            {
                do
                {
                    Console.Write("\nEnter the number you are looking for in random array (from 1 to 200): ");
                    do
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                        if (value < 1 || value > 200)
                            Console.Write("Incorrect! Try again: ");
                    } while (value < 1 || value > 200);
                    Console.WriteLine();
                } while (value < 1 || value > 200);

                Task task_1 = new Task(() => Generate());
                Task task_2 = task_1.ContinueWith(DeleteDouble);
                Task task_3 = task_2.ContinueWith(Sort);
                Task task_4 = task_3.ContinueWith(BinSearch);

                task_1.Start();
                task_4.Wait();

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());
            } while (index == 1);
        }

        static void Generate()
        {
            size = 100;
            Random rand = new Random();
            numbers = new int[size];
            Console.WriteLine("Primary array: ");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = rand.Next(1, 201);
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine(); Console.WriteLine();
        }

        static void DeleteDouble(Task task)
        {
            numbers = numbers.Distinct().ToArray();
            Console.WriteLine("Edited array: ");
            foreach (var num in numbers)
                Console.Write(num + " ");
            Console.WriteLine(); Console.WriteLine();
        }

        static void Sort(Task task)
        {
            Array.Sort(numbers);
            Console.WriteLine("Sorted array: ");
            foreach (var num in numbers)
                Console.Write(num + " ");
            Console.WriteLine(); Console.WriteLine();
        }

        static void BinSearch(Task task)
        {
            int index = Array.BinarySearch(numbers, value);
            if (index < 0)
                Console.WriteLine("Array doesn't contain such value."); 
            else
                Console.WriteLine("Index value '" + value + "' in array: " + (index + 1));
        }
    }
}
