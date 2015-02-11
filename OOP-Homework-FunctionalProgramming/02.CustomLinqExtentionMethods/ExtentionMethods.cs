using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CustomLinqExtentionMethods
{
    public static class ExtentionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(a => !predicate(a));
        }

        //public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        foreach (var item in collection)
        //        {
        //            yield return item;
        //        }
        //        Console.WriteLine();
        //    }
        //}
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var list = collection.ToList();
            for (int i = 0; i < count; i++)
            {
                foreach (var item in collection)
                {
                    list.AddRange(collection);
                }
            }
            return list as IEnumerable<T>;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            var output = new List<string>();
            foreach (var item in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (item.EndsWith(suffix))
                    {
                        output.Add(item);
                    }
                }
            }
            return output as IEnumerable<string>;
        }
    }
}
