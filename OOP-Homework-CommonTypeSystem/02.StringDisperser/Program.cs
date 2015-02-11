using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringDisperser
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDisperser firstDisperser = new StringDisperser(new string[] { "Rumen", "Gosho", "Maria" });
            StringDisperser secondDisperser = new StringDisperser(new string[] { "Rumen", "Gosho", "Maria" });

            
            Console.WriteLine(firstDisperser.Equals(secondDisperser));
            Console.WriteLine(firstDisperser == secondDisperser);
            
        }
    }
}
