using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weeklySalary, int workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkingHoursPerDay = workingHoursPerDay;
        }

        public decimal WeeklySalary { get; set; }
        public int WorkingHoursPerDay { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public decimal MoneyPerHour()
        {
            decimal result = 0;
            result = this.WeeklySalary / 5 / this.WorkingHoursPerDay;
            return result;
        }
    }

}
