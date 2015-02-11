using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EnterNumbers
{
    class Program
    {
        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);
            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException("The range is [" + start + "..." + end + "]");
            }
            return number;
        }
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            List<int> validNumbers = new List<int>();

            while (validNumbers.Count < 10)
            {
                try
                {
                    Console.WriteLine("Please enter an integer: ");
                    int number = ReadNumber(start, end);
                    if (number > start)
                    {
                        validNumbers.Add(number);
                        start = number;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number should be smaller than " + end);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("The number should be greater than " + start + "\nPlease enter another number");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number!\nPlease enter a number:");
                }
                
            }
            foreach (var number in validNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
