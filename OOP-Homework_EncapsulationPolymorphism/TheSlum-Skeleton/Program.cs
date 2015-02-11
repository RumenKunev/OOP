using System;
using TheSlum.GameEngine;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new OverrittenEngine();
            engine.Run();

        }
    }
}
