using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StringBuilderextentions
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder example = new StringBuilder();
            example.Append("ljljljl");
            example.Append("lllkk");
            List<int> list = new List<int> { 1, 3, 4 };

            Console.WriteLine(example.AppendAll(list).ToString());        
        }
    }
}
