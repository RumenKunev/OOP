using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace _03.ClassStudent
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private string phone;
        private string email;
        private IList<double> marks;
        private int groupNumber;
        private string groupName;

        public Student(string firstName, string lastName, int age, int facultyNumber, 
            string phone, string email, IList<double> marks, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (Validation.IsValidStringInput(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("Not a valid name!");
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
                if (Validation.IsValidStringInput(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Not a valid name!");
                }
            }
        }

        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (Validation.IsValidNumber(value))
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentNullException("Not a valid number!");
                }
            }
        }

        public int FacultyNumber {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (Validation.IsValidNumber(value))
                {
                    this.facultyNumber = value;
                }
                else
                {
                    throw new ArgumentNullException("Not a valid number!");
                }
            }
        }

        public string Phone 
        {
            get
            {
                return this.phone;
            }
            set
            {
                if (Validation.IsValidStringInput(value))
                {
                    this.phone = value;
                }
                else
                {
                    throw new ArgumentNullException("Not a valid phone!");
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (Validation.IsValidStringInput(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentNullException("Not a valid e-mail!");
                }
            }
        }

        public IList<double> Marks 
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (Validation.IsValidNumber(value))
                {
                    this.groupNumber = value;
                }
                else
                {
                    throw new ArgumentNullException("Not a valid number!");
                }
            }
        }

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.groupName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Student: {0} {1}\n", this.FirstName, this.LastName));
            result.Append(string.Format("Age: {0}\n", this.Age));
            result.Append(string.Format("FacultyNumber: {0}\n", this.FacultyNumber));
            result.Append(string.Format("Phone: {0}\n", this.Phone));
            result.Append(string.Format("E-mail: {0}\n", this.Email));
            result.Append("Marks: ");

            foreach (var mark in this.Marks)
            {
                result.Append(mark);
                if (this.Marks.IndexOf(mark) != this.Marks.Count - 1)
                {
                    result.Append(", ");
                }
            }

            result.Append("\n");
            result.Append(string.Format("GroupNumber: {0}\n", this.GroupNumber));
            result.Append(string.Format("GroupName: {0}\n", this.GroupName));

            return result.ToString();
        }
    }
}
