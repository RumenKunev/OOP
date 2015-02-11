using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Customer
{
    class Program
    {
        static void Main()
        {
            Customer firstCustomer = new Customer(
                "Rumen",
                "Petrov",
                "Ivanov",
                3344334455,
                "Sofia, bul.Bulgaria",
                "02/9876543",
                "rumen@microsoft.com",
                new List<Payment>()
                {
                    new Payment("Hard Drive", 100.50),
                    new Payment("Motherboard", 300.00)
                },
                CustomerType.Regular);

            Customer secondCustomer = new Customer(
               "Petar",
               "Petrov",
               "Vasilev",
               1111111111,
               "Plovdiv, bul.Bulgaria",
               "02/9844543",
               "vasilev@soft.bg",
               new List<Payment>()
                {
                    new Payment("Laptop", 2000),
                    new Payment("Screen", 500.40)
                },
               CustomerType.Diamond);

            Customer thirdCustomer = (Customer)secondCustomer.Clone();
            thirdCustomer.Payments.Add(new Payment("mouse", 5.60));
            thirdCustomer.FirstName = "Rumen";
            thirdCustomer.ID = 9999999999;
    
            foreach (var item in secondCustomer.Payments)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 20));

            foreach (var item in thirdCustomer.Payments)
            {
                Console.WriteLine(item.ToString());
            }

            Customer[] customers = new Customer[]
            {
                firstCustomer,
                secondCustomer,
                thirdCustomer
            };
            Array.Sort(customers);

            var sortedCustomers = customers.Select(c => new {Name = c.FirstName, ID = c.ID });
            foreach (var cust in sortedCustomers)
            {
                Console.WriteLine(cust);
            }
        }



    }
}
