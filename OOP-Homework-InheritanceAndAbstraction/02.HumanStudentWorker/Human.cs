using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (isValidName(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("The name could not be empty!");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (isValidName(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("The name could not be empty!");
                }
            }
        }

        public bool isValidName(string value)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(value))
            {
                isValid = false;
            }
            return isValid;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
