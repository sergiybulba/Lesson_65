using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static long factorial;

        static void Main(string[] args)
        {
            int index, value;
            do
            {
                Console.Write("\nEnter a number to calculate the factorial (from 1 to 20): ");
                do
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    if (value < 1 || value > 20)
                        Console.Write("Incorrect! Try again: ");
                } while (value < 1 || value > 20);
                Console.WriteLine();

                Factorial(value);
                Parallel.Invoke(CountDigits, SumDigits);

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());
            } while (index == 1);


        }

        static void Factorial(int number)
        {
            factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial = factorial * i;

            Console.WriteLine(number + "! = " + factorial); Console.WriteLine();
        }

        static void CountDigits()
        {
            Console.WriteLine("Count digits = " + factorial.ToString().Length); Console.WriteLine();
        }

        static void SumDigits()
        {
            int sum = 0;
            char[] digits = factorial.ToString().ToCharArray();
            foreach (var digit in digits)
                sum = sum + Int32.Parse(digit.ToString());
            Console.WriteLine("Sum digits = " + sum); Console.WriteLine();
        }

    }
}
