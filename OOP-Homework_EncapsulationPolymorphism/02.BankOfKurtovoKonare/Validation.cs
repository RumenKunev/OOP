using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare
{
    public class Validation
    {
        public static bool isValidNumber(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("The number could not be negatige!");
            }
            else
            {
                return true;
            }
        }
    }
}
