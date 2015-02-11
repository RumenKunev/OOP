namespace _03.GenericList
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        private int majorVersionIndex;
        private int minorVersionIndex;

        public VersionAttribute(int majorIndex, int minorIndex)
        {
            this.MajorVersionIndex = majorIndex;
            this.MinorVersionIndex = minorIndex;
        }

        public int MajorVersionIndex { get; private set; }
        
        public int MinorVersionIndex { get; private set; }
       
        public override string ToString()
        {
            string result = String.Empty;
            result += String.Format("{0}.{1}",this.MajorVersionIndex, this.MinorVersionIndex);
            return result;
        }

    }
}
