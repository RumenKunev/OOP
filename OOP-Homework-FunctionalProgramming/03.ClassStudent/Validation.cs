using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ClassStudent
{
    public static class Validation
    {
        public static bool IsValidNumber(int number)
        {
            bool result = true;
            if (number <= 0)
            {
                result = false;
            }
            return result;
        }

        public static bool IsValidStringInput(string str)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(str))
            {
                result = false;
            }
            return result;
        }
    }
}
