using System;
using System.Collections.Generic;


namespace _02.CustomLinqExtentionMethods
{
    class CustomLinqExtentionMethods
    {
        static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3, 5, 6, 8 };

            var listWhereNot = list.WhereNot(x => x % 2 == 0);

            foreach (var item in listWhereNot)
            {
                Console.WriteLine(item);
            }

            var repeatList = list.Repeat(5);
            foreach (var item in repeatList)
            {
                Console.WriteLine(item);
            }

            List<string> listOfWords = new List<string>() { "hello", "comfortable", "window", "world", "stringosvam", "chislosvam" };
            List<string> suffixes = new List<string>() { "able", "osvam" };
            var filteredWords = listOfWords.WhereEndsWith(suffixes);

            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
