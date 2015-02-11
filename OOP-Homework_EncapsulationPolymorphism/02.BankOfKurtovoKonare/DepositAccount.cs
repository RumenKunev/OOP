using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(CustomerType customerType, decimal balance, decimal monthlyInterestRate)
            : base(customerType, balance, monthlyInterestRate)
        {
        }
                      
        public void DepositAmount(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrowAmount(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(months);
            }
        }
    }
}
