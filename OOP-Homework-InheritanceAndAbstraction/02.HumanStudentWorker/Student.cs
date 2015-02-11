using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FaultyNumber = facultyNumber;
        }

        public string FaultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (isValidName(value))
                {
                    this.facultyNumber = value;
                }
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
