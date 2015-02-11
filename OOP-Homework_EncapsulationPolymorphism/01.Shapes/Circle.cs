using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }
        
        public double CalculateArea()
        {
            double result;
            result = Math.PI * this.Radius * this.Radius;
            return result;
        }

        public double CalculatePerimeter()
        {
            double result;
            result = 2 * Math.PI * this.Radius * this.Radius;
            return result;
        }
    }
}
