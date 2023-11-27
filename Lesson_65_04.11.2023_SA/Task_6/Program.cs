using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Task_6
{
    class Program
    {
        static Dictionary<int, int> numbers;    // таблиця чисел: key - порядковий номер числа, value - саме число
        static void Main(string[] args)
        {
            int count, index;
            string path = "numbers.txt";
            Random rand = new Random();

            do
            {
                numbers = new Dictionary<int, int>();
                Console.Write("\nEnter a count of numbers (preferably > 10): "); // запит кількості чисел у вибірці
                do
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    if (count < 10)
                        Console.Write("Incorrect! Try again: ");
                } while (count < 10);
                Console.WriteLine();

                StreamWriter stream_w = new StreamWriter(path);     // запис у файл випадково згенерованих чисел
                for (int j = 0; j < count; j++)
                {
                    stream_w.WriteLine(rand.Next(1, 101));
                }
                stream_w.Close();


                StreamReader stream_r = new StreamReader(path);     // зчитування з файлу чисел і запис їх у об'єкт dictionary
                int i = 0;
                while (!stream_r.EndOfStream)
                {
                    i++;
                    numbers.Add(i, Int32.Parse(stream_r.ReadLine()));
                }
                stream_r.Close();

                Dictionary<int, int> sequences = (from number in numbers.AsParallel()       // підрахунок послідовності зростаючих чисел для кожного числа з колекції dictionary
                                       select Length_sequences(number)).ToDictionary(_ => _.Key, _ => _.Value);

                //foreach(var s in sequences)
                //    Console.WriteLine(s);
                Thread.Sleep(1000);
                Console.WriteLine("Max length increasing sequence: " + sequences.Values.Max()); // вивід в консоль кількості чисел в максимальній послідовності

                int count_max = sequences.Values.Count(max => max == sequences.Values.Max());   // підрахунок кількості таких максимальних зростаючих послідовностей
                Console.WriteLine("Count max sequence(s): " + count_max);

                for (int m = 1; m <= sequences.Count; m++)            // вивід в консоль всіх таких максимальних зростаючих послідовностей        
                {
                    if (sequences[m] == sequences.Values.Max())
                    {
                        Console.Write("Sequence: ");
                        for (int n = 0; n < sequences.Values.Max(); n++)
                        {
                            Console.Write(numbers[m + n] + " ");
                        }
                        Console.WriteLine();
                    }
                }


                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());
            } while (index == 1);
        }

        static KeyValuePair<int, int> Length_sequences(KeyValuePair<int, int> number) // метод - підрахунок довжини послідовності зростаючих чисел
        {
            int count = 1;
            for(int i = number.Key; i <= numbers.Count - 1; i++)
            {
                if (numbers[i + 1] > numbers[i])
                {
                    count++;
                }
                else break;
            }
            return (new KeyValuePair<int, int> (number.Key, count));
        }
    }
}
