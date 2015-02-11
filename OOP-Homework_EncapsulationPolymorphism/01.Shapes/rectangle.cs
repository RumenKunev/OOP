using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double result;
            result = this.Width * this.Height;
            return result;
        }

        public override double CalculatePerimeter()
        {
            double result;
            result = (2 * this.Width) + (2 * this.Height);
            return result;
        }
    }
}
