using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HTML_Dispatcher
{
    public static class HTNLDispatcher
    {
        public static string CreateImage(string src, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img");
            img.AddAttribute("src", src);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);
            img.SelfClosed(true);
            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder a = new ElementBuilder("a");
            a.AddAttribute("href", url);
            a.AddAttribute("title", title);
            a.AddContent(text);
            return a.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            input.SelfClosed(true);
            return input.ToString();
        }
    }
}
