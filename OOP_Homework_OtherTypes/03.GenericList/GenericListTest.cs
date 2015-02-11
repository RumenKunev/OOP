using System;

namespace _03.GenericList
{
    class GenericListTest
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>();
            list.Add("Aa");
            list.Add("bbb");
            list.Add("ccc");
            list.Add("ddd");
            list.Add("eee");
            list.Add("fff");
            list.Add("ggg");
            list.Remove(2);
            list.Add("hjhjhh");
            list[11] = "jjj";
            list.InsertElementAtPosition("aaa", 1);
            list.Clear();
            list.Add("Aa");
            list.Add("bbb");
            list.Add("ccc");
            int index = list.IndexOf("ccc");
            list.InsertElementAtPosition("Rumen", 0);
            Console.WriteLine(list.ToString());
            Console.WriteLine(list.Max());
      
           
           
                     


            Console.WriteLine();
        }
    }
}
