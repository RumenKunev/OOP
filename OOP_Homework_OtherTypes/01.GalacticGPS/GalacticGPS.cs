using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    class GalacticGPS
    {
        static void Main(string[] args)
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
            Console.WriteLine();
            Location otherLocation = new Location();
            otherLocation.Latitude = 12.5555;
            otherLocation.Longitude = 14.66664;
            otherLocation.Planet = Planet.Mars;
            Console.WriteLine(otherLocation);
        }
    }
}
