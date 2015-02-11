using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class ShapesMain
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle(2.5, 3.4);
            Triangle triangle = new Triangle(2.4, 3.4, 5);
            Circle circle = new Circle(5);

            IShape[] shapes = new IShape[]
            {
                rectangle,
                triangle,
                circle
            };
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine("Area: {0:F2} -> Perimeter: {1:F2}", shape.CalculateArea(), shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}
