using System;

namespace _01.InterestCalculator
{
    class InterestcalculatorTest
    {
        public static decimal GetSimpleInterest(decimal amount, double interest, int years)
        {
            decimal result = 0;
            result = amount * (decimal)(1 + interest / 100 * years);
            return result;
        }

        public static decimal GetCompoundInterest(decimal amount, double interest, int years)
        {
            decimal result = 0;
            result = amount * (decimal)Math.Pow((1 + interest / 100 / 12), (years * 12));
            return result;
        }

        static void Main()
        {
            InterestCalculator compoundInterest = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);
            Console.WriteLine(compoundInterest.ToString());

            InterestCalculator simpleInterest = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);
            Console.WriteLine(simpleInterest.ToString());
        }
    }
}
