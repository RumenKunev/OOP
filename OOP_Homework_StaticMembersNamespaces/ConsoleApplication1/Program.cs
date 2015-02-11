using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{

    class Program
    {
        static void Main(string[] args)
        {
            Point3D firstPoint = new Point3D(3, 5, -4);
            Console.WriteLine(firstPoint.ToString());

            Console.WriteLine(Point3D.StartingPoint);

            Point3D p1 = new Point3D(-7, -4, 3);
            Point3D p2 = new Point3D(17, 6, 2.5);
            Console.WriteLine(DistanceCalculator.CalcDistance(p1, p2));

            Path3D path = new Path3D(p1, p2, Point3D.StartingPoint);
            Console.WriteLine(path);

            path.WriteToFile("Path3D.txt");

            Path3D p = Path3D.readPathFromFile("Path3D.txt");
            Console.WriteLine(p.ToString());
        }
    }
}
