using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        public Customer()
        {

        }
        public Customer(string firstName, string middleName, string lastName, long id, string address,
            string phone, string email, List<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;

        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Payment> Payments { get; set; }
        public CustomerType CustomerType { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;
            }
            if (
                !Object.Equals(this.FirstName, customer.FirstName) &&
                !Object.Equals(this.MiddleName, customer.MiddleName) &&
                !Object.Equals(this.LastName, customer.LastName) &&
                this.ID != customer.ID &&
                !Object.Equals(this.Address, customer.Address) &&
                !Object.Equals(this.Phone, customer.Phone) &&
                !Object.Equals(this.Email, customer.Email)          
                )
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            return Customer.Equals(firstCustomer, secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return !Customer.Equals(firstCustomer, secondCustomer);
        }

        public object Clone()
        {
            Customer clonedCustomer = new Customer();
            clonedCustomer.FirstName = (string)this.FirstName.Clone();
            clonedCustomer.MiddleName = (string)this.MiddleName.Clone();
            clonedCustomer.LastName = (string)this.LastName.Clone();
            clonedCustomer.ID = this.ID;
            clonedCustomer.Address = (string)this.Address.Clone();
            clonedCustomer.Phone = (string)this.Phone.Clone();
            clonedCustomer.Email = (string)this.Email.Clone();
            clonedCustomer.Payments = new List<Payment>();

            foreach (var payment  in this.Payments)
	            {
		             clonedCustomer.Payments.Add((Payment)payment.Clone());
	            }

            clonedCustomer.CustomerType = this.CustomerType;

            return clonedCustomer;
        }


        public int CompareTo(Customer other)
        {
            int result = this.FirstName.CompareTo(other.FirstName);
            if(this.FirstName.CompareTo(other.FirstName) == 0)
            {
                result = this.MiddleName.CompareTo(other.MiddleName);
                if (this.MiddleName.CompareTo(other.MiddleName) == 0)
                {
                    result = this.LastName.CompareTo(other.LastName);
                    if (this.LastName.CompareTo(other.LastName) == 0)
                    {
                        return this.ID.CompareTo(other.ID);
                    }
                }
            }
            return result;
        }
        
    }
}
