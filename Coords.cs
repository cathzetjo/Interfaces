using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    public class Coords
    {

        public static readonly Coords @base = new Coords(0, 0);                      // start point to fly FROM
        public static readonly Coords south = new Coords(100, 100);                  // South

        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Coords()                                                             // Default Constructor
        {
            Latitude = 0;
            Longitude = 0;
        }

        public Coords(int la, int lo)                                               // Syntax Constructor 
        {
            Latitude = la;
            Longitude = lo;
        }


        public override string ToString()                                           // Override Method ToString
        {
            Thread.Sleep(2000);
            return $"\t\tDestination: {Latitude} x {Longitude}";
        }
    }
}
