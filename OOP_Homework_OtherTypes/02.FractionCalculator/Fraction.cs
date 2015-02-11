using System;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            { this.numerator = value; }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                try
                {
                    if (value == 0)
                    {
                        throw new ArgumentException();
                    }
                    this.denominator = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("The denominator could not be null");
                }
            }
        }

        public static Fraction operator +(Fraction firstFraction, Fraction secondFraction)
        {

            long resultNumerator = (firstFraction.Numerator * secondFraction.Denominator) + (firstFraction.Denominator * secondFraction.Numerator);
            long resultDenominator = (firstFraction.Denominator * secondFraction.Denominator);
            Fraction result = new Fraction(resultNumerator, resultDenominator);
            return result;
        }

        public static Fraction operator -(Fraction firstFraction, Fraction secondFraction)
        {

            long resultNumerator = (firstFraction.Numerator * secondFraction.Denominator) - (firstFraction.Denominator * secondFraction.Numerator);
            long resultDenominator = (firstFraction.Denominator * secondFraction.Denominator);
            Fraction result = new Fraction(resultNumerator, resultDenominator);
            return result;
        }

        public override string ToString()
        {
            decimal output;
            output = (decimal)this.Numerator / (decimal)this.Denominator;
            return output.ToString();
        }
    }
}
