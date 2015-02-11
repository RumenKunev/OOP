using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace _03_PCCatalog
{
    public class Component
    {
        private string name;
        private string details;
        private float price;

        public Component(string name, string details, float price)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }
        public Component(string name, float price) :
            this(name, null, price)
        {
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != null && value == "")
                {
                    throw new ArgumentNullException("The name could not be empty");
                }
                this.name = value;
            }
        }
        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (value != null && value == "")
                {
                    throw new ArgumentException("The value cannot be empty");
                }
                this.details = value;
            }
        }
        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price could not be negative number");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = this.Name;
            if (this.Details != null)
            {
                output += string.Format(", Details: {0}", this.Details);
            }
            output += string.Format(", {0:C}}", this.Price);
            return output;
        }
    }
    public class Computer
    {
        private string name;
        private List<Component> components;


        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
        }
        public Computer(string name)
            : this(name, null)
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public List<Component> Components
        {
            get
            {
                return this.components;
            }
            set 
            {
                if (value != null)
                {
                    this.components = value;
                }
                else
                {
                    this.components = new List<Component>();
                }
            }
        }
        public float Price
        {
            get
            {
                float sum = 0;
                if (components != null)
                {
                    foreach (Component component in components)
                    {
                        sum += component.Price;
                    }
                }
                return sum;
            }

        }

        public override string ToString()
        {
            string output = string.Format("Computer name: {0}\n", this.Name);
            if (components != null)
            {
                foreach (Component component in components)
                {
                    output += string.Format("{0} -> price: {1:C}\n", component.Name, component.Price);

                }
                output += string.Format("Total price: {0:C}", this.Price);
            }
            return output;
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

                Component processor = new Component("Processor", "Intel Core", 123.22f);
                Component graficCard = new Component("Graphic Card", 154.00f);
                Component HDD = new Component("Hard Drive", "128GB SSD", 335.00f);
                Component RAM = new Component("RAM", "8 BG", 154.00f);
                Component screen = new Component("IPS Sensor Display", "15\"", 210.00f);

                Computer firstItem = new Computer("Lenovo", new List<Component> { processor, HDD, RAM });
                Computer secondItem = new Computer("HP");

                Computer thirdItem = new Computer("Asus");
                thirdItem.Components.Add(processor);
                


                List<Computer> computers = new List<Computer> { firstItem, secondItem, thirdItem };

                computers = computers.OrderBy(computer => computer.Price).ToList();

                foreach (var computer in computers)
                {
                    Console.WriteLine(computer + "\n");
                }

            }
        }
    }
}
