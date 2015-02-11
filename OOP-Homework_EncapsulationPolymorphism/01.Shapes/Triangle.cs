using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Triangle : BasicShape
    {
        private double thirdSide;

        public Triangle(double width, double height, double thirdSide)
            : base(width, height)
        {
            this.ThirdSide = thirdSide;
        }

        public double ThirdSide
        {
            get
            {
                return this.thirdSide;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Not a valid width");
                }
                this.thirdSide = value;
            }
        }
      
        public override double CalculateArea()
        {
            var p = (this.Height + this.Width + this.thirdSide) / 2;
            var area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.ThirdSide));
            return area;
        }

        public override double CalculatePerimeter()
        {
            var perimeter = this.Height + this.Width + this.thirdSide;
            return perimeter;
        }
    }
}
