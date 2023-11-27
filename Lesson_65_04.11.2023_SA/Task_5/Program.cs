using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int count, index;
            string path = "numbers.txt";
            Random rand = new Random();

            do
            {
                Console.Write("\nEnter a count of numbers to calculate the factorial (preferably > 10): "); // ввести кількість чисел, для яких рахується факторіал
                do
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    if (count < 10)
                        Console.Write("Incorrect! Try again: ");
                } while (count < 10);
                Console.WriteLine();
                
                StreamWriter stream_w = new StreamWriter(path); // запис цих випадково згенерованих чисел у файл
                for (int i = 0; i < count; i++)
                {
                    stream_w.WriteLine(rand.Next(1, 21));
                }
                stream_w.Close();

                List<int> numbers = new List<int>();
                StreamReader stream_r = new StreamReader(path);
                while (!stream_r.EndOfStream)                   // формування з файлу списку чисел
                {
                    numbers.Add(Int32.Parse(stream_r.ReadLine()));
                }

                stream_r.Close();

                ParallelLoopResult result = Parallel.ForEach(numbers, Factorial);   // розрахунок факторіалу для кожного числа (паралельні tasks)

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());
            } while (index == 1);
        }

        static void Factorial(int number) // метод - розрахунок факторіалу для числа
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial = factorial * i;

            Console.WriteLine(number + "! = " + factorial);
        }
    }
}
