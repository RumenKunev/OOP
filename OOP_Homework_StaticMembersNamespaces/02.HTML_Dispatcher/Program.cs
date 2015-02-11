using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HTML_Dispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class","big");
            div.AddContent("<p>Hello</p>");
            
            Console.WriteLine(div * 2);

            string url = "#";
            string title = "abv.bg";
            string text = "abv.bg";

            Console.WriteLine(HTNLDispatcher.CreateURL(url, title, text));
                
            
        }
    }
}
