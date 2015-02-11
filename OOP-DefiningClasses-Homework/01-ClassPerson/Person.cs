using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ClassPerson
{
    public class Person
    {
        private string name;
        private int age;
        private string email;

        public Person()
        {

        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
          
        }

        public Person(string name, int age, string email)
            :this(name, age)
        {
            this.Email = email;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    this.name = value;
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
                if ((this.age < 1) && (this.age > 100))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.age = value;
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
                if ((value != null) && !value.Contains('@'))
                {
                    throw new ArgumentException("Not a valid e-mail address!");
                }
                else
                {
                    this.email = value;
                }

            }

        }

        public override string ToString()
        {
            return string.Format("name: {0}, age: {1}", this.Name, this.Age) + (this.Email == null ? "" : ", email:" + this.Email);


        }
    }
    public class Programm
    {
        static void Main()
        {
            Person somePerson = new Person("Rumen", 22);
            Console.WriteLine(somePerson);
            Person NEWP = new Person();
        }
    }
}
