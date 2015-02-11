using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(CustomerType customerType, decimal balance, decimal monthlyInterestRate)
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
                if (months <= 6)
                {
                    result = 0;
                }
                else
                {
                    result = base.CalculateInterestAmount(months - 6);
                }
            }
            else
            {
                if (months <= 12)
                {
                    result = base.CalculateInterestAmount(months) / 2;
                }
                else
                {
                    result = base.CalculateInterestAmount(months) / 2 + base.CalculateInterestAmount(months - 12);
                }
            }
            return result;
        }
    }
}
