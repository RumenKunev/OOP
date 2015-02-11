using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Customer
{
    public class Payment : ICloneable
    {
        public Payment(string productName, double price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public Payment()
        {
        }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public override bool Equals(object inputParam)
        {
            Payment payment = inputParam as Payment;
            if (payment == null)
            {
                return false;
            }
            if (!Object.Equals(this.ProductName, payment.ProductName))
            {
                return false;
            }
            if (this.Price != payment.Price)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Payment firstPayment, Payment secondPayment)
        {
            return Payment.Equals(firstPayment, secondPayment);
        }

        public static bool operator !=(Payment firstPayment, Payment secondPayment)
        {
            return !Payment.Equals(firstPayment, secondPayment);
        }
        public override int GetHashCode()
        {
            return ProductName.GetHashCode() ^ Price.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("Product Name: {0} -> Price: {1}", this.ProductName, this.Price);
        }

        public object Clone()
        {
            Payment cloned = new Payment();

            cloned.ProductName = (string)this.ProductName.Clone();
            cloned.Price = this.Price;
            return cloned;
        }
    }
}
