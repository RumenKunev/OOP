using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, enter a positive integer?");
                string input = Console.ReadLine();
                int number = int.Parse(input);

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("The number should be positive integer!");
            }
            catch(FormatException)
            {
                Console.WriteLine("The number should be positive integer!");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }


        }
    }
}
