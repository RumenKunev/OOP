using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringDisperser
{
    class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        public StringDisperser()
        {
                
        }
        public StringDisperser(params string[] inputArray)
        {
            this.JoinedStrings = String.Join("", inputArray);
        }

        public string JoinedStrings { get; set; }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;

            if (stringDisperser == null) 
            {
                return false;
            }
            return Object.Equals(this.JoinedStrings, stringDisperser);
        }

        public static bool operator ==(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return StringDisperser.Equals(firstDisperser, secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return !StringDisperser.Equals(firstDisperser, secondDisperser);
        }
        public override int GetHashCode()
        {
            return this.JoinedStrings.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in this.JoinedStrings)
            {
                 result += item.ToString();
            }
            return result;
        }

        public object Clone()
        {
            StringDisperser cloned = new StringDisperser();
            cloned.JoinedStrings = (string)this.JoinedStrings.Clone();
            return cloned;
        }

        public int CompareTo(StringDisperser inputDisperser)
        {
            return this.JoinedStrings.CompareTo(inputDisperser.JoinedStrings);
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.JoinedStrings.Length; i++)
            {
                yield return this.JoinedStrings[i];   
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        
    }
}


