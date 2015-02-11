namespace _01.InterestCalculator
{
    using System;

    public class InterestCalculator
    {
        public InterestCalculator(decimal amount, double interest, int years, Func<decimal, double, int, decimal> calculation)
        {
            this.Amount = amount;
            this.Interest = interest;
            this.Tenor = years;
            this.Calculation = calculation;
        }

        public decimal Amount { get; set; }
        public double Interest { get; set; }
        public int Tenor { get; set; }
        public Func<decimal, double, int, decimal> Calculation { get; set; }

        public override string ToString()
        {
            string result = String.Format("{0:F4}", this.Calculation(this.Amount, this.Interest, this.Tenor));
            return result;
        }

    }
    
}
