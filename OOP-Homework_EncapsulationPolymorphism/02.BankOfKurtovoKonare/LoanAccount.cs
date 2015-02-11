using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(CustomerType customerType, decimal balance, decimal monthlyInterestRate)
            : base(customerType, balance, monthlyInterestRate)
        {
        }

        public void DepositAmount(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            decimal result;
            if (this.CustomerType.GetType().Name == "Person")
            {
                if (months <= 3)
                {
                    result = 0;
                }
                else
                {
                    result = base.CalculateInterestAmount(months - 3);
                }
            }
            else
            {
                if (months <= 2)
                {
                    result = 0;
                }
                else
                {
                    result = base.CalculateInterestAmount(months - 2);
                }
            }
            return result;
        }
    }
}
