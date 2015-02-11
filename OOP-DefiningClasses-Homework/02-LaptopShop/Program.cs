using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LaptopShop
{
    public class Battery
    {
        private string batteryType;
        private float batteryLife;
      
        public Battery(string batType, float batLife)
        {
            this.BatteryType = batType;
            this.BatteryLife = batLife;
        }

        public string BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Battery type can not be empty!");
                }
                this.batteryType = value;
            }
        }

        public float BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("The number could not be negative!");
                }
                this.batteryLife = value;
            }
        }
        public override string ToString()
        {
            string result = string.Format("{0} {1}", this.BatteryType, this.BatteryLife);
            return result;
        }
    }

    public class Laptop
    {
        private string model;
        private string manifacturer;
        private string processor;
        private int ram;
        private string card;
        private string hdd;
        private float screen;
        private Battery battery;
        private decimal price;

        public Laptop(string model, decimal price, string manifacturer = null, string processor = null, int ram = 0, string card = null, string hdd = null, float screen = 0, Battery battery = null)
        {
            this.Model = model;
            this.Manifacrurer = manifacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.Card = card;
            this.Hdd = hdd;
            this.Screen = screen;
            this.battery = battery;
            this.Price = price;
        }


        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.model = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.price = value;
            }
        }
        public string Manifacrurer
        {
            get
            {
                return this.manifacturer;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.manifacturer = value;
            }
        }
        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.processor = value;
            }
        }
        public int Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Number can not be negative!");
                }
                this.ram = value;
            }
        }
        public string Card
        {
            get
            {
                return this.card;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.card = value;
            }
        }
        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Field can not be empty!");
                }
                this.hdd = value;
            }
        }
        public float Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Numer can not be negative!");
                }
                this.screen = value;
            }
        }


        public override string ToString()
        {

            string output = "Model: " + this.Model + "\nPrice: " + this.Price + " lv.\n";
            if (this.Manifacrurer != null) { output += "manufacturer: " + this.Manifacrurer + "\n"; }
            if (this.Processor != null) { output += "processor: " + this.Processor + "\n"; }
            if (this.Ram != 0) { output += "RAM: " + this.Ram + " GB\n"; }
            if (this.Card != null) { output += "GPU: " + this.Card + "\n"; }
            if (this.Hdd != null) { output += "HDD: " + this.Hdd + "\n"; }
            if (this.Screen != 0) { output += "screen: " + this.Screen + "\"\n"; }
            if (battery != null) { output += "battery: " + this.battery.ToString(); }
            return output;
        }


    }



    class Program
    {
        static void Main(string[] args)
        {
            Laptop firstLaptop = new Laptop("HP 250 G2", 699.00m);
            Console.WriteLine(firstLaptop);
            Battery battery = new Battery("Li-Ion", 4.5f);
           
            Laptop secondLaptop = new Laptop("Lenovo Yoga", 2259.00m, battery: battery);
            Console.WriteLine(secondLaptop);
        }
    }

}
