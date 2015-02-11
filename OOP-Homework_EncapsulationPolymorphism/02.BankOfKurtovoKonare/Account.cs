using System;

namespace _02.BankOfKurtovoKonare
{
    public abstract class Account
    {
        private CustomerType customerType;
        private decimal balance;
        private decimal monthlyInterestRate;

        public Account(CustomerType customerType, decimal balance, decimal monthlyInterestRate)
        {
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public CustomerType CustomerType
        {
            get { return this.customerType; }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (Validation.isValidNumber(value))
                {
                    this.balance = value;
                }
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return this.monthlyInterestRate;
            }
            set
            {
                if (Validation.isValidNumber(value))
                {
                    this.monthlyInterestRate = value;
                }
            }
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            decimal result = this.Balance * ((1 + this.MonthlyInterestRate * months)) / 100;
            return result;
        }
    }
}
