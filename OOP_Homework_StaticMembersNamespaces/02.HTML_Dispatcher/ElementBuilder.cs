using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HTML_Dispatcher
{
    class ElementBuilder
    {
        private string name;
        private string content = "";
        private Dictionary<string, string> attributes = new Dictionary<string, string>();
        private bool isSelfClosed = false;

        public ElementBuilder(string tagName)
        {
            this.Name = tagName;
        }
       
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public void SelfClosed(bool selfClosed)
        {
            this.isSelfClosed = selfClosed;
        }

        public void AddAttribute(string tagAttribute, string attValue)
        {
            this.attributes.Add(tagAttribute, attValue);
        }
        public void AddContent(string content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            string result = "";
            result += String.Format("<{0}", this.Name);
            foreach (var attribut in this.attributes)
            {
                result += String.Format(" {0}=\"{1}\"",attribut.Key, attribut.Value);
            }
            if (this.isSelfClosed)
            {
                result += String.Format("/>{0}", this.content);
            }
            else
            {
                result += String.Format(">{0}</{1}>", this.content, this.Name);
            }
            return result;
        }

        public static string operator *(ElementBuilder element, int num)
        {
            string result = "";
            for (int i = 0; i < num; i++)
            {
                result += element.ToString();
            }
            return result;
        }
    }
}
