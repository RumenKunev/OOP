using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_Point3D
{
    class Path3D
    {
        private List<Point3D> points = new List<Point3D>();

        public Path3D(params Point3D[] points)
        {
            this.points.AddRange(points);
        }

        public void WriteToFile(string fileName)
        {
            File.WriteAllText(fileName, this.ToString());
        }

        public static Path3D readPathFromFile(string filename)
        {
            string pathFromFile = File.ReadAllText(filename);
            Regex pattern = new Regex("x = (.*?); y = (.*?); z = (.*?)[)]");
            var matches = pattern.Matches(pathFromFile);
            Path3D path = new Path3D();
            for (int i = 0; i < matches.Count; i++)
            {
                double x = Double.Parse(matches[i].Groups[1].Value);
                double y = Double.Parse(matches[i].Groups[2].Value);
                double z = Double.Parse(matches[i].Groups[3].Value);
                Point3D point = new Point3D(x, y, z);
                path.points.Add(point);
            }
            return path;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Path3D {");
            result.Append(string.Join(", ", this.points));
            result.Append("}");
            return result.ToString();
        }


    }
}
