using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StringBuilderextentions
{
    public static class ExtentionMetods
    {
        public static string Substring(this StringBuilder inputIndex, int startIndex, int length)
        {
            string result = inputIndex.ToString().Substring(startIndex, length);
            return result;
        }

        public static StringBuilder Substring(this StringBuilder inputIndex, string text)
        {
            return inputIndex.Replace(text, string.Empty);
            
        }

        public static StringBuilder AppendAll<T>(this StringBuilder inputIndex, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                inputIndex.Append(item);
            }
            return inputIndex;
        }
    }
}
