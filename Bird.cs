using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Bird : IFlyable
    {
        public string Type { get; protected set; }
        public string Name { get; set; }
        public string Species { get; set; }

        public Bird()                                                             // Default Constructor
        {
            Type = "Bird";
            Name = "Some name";
            Species = "Some species";
        }

        public Bird(string name, string species)                                // Syntax Constructor 
        {
            Type = "Bird";
            Name = name;
            Species = species;
        }

        public Bird(Bird bird)                                                   // Copy Constructor 
        {
            this.Type = bird.Type;
            this.Name = bird.Name;
            this.Species = bird.Species;
        }

        public override string ToString()                                              // Override Method ToString
        {
            Thread.Sleep(2000);
            return $"\t\tType: {Type} \n\t\tName: {Name} \n\t\tSpecies: {Species}";
        }

        public void Fly(Coords coordsToFly)
        {
            Console.WriteLine($"\n\t{Name} was send to destination ~ {coordsToFly.Latitude}x{ coordsToFly.Longitude} ~\n");
            Thread.Sleep(1000);
            Console.WriteLine($"\t\tVzhyk.... vzhyk vzhyk vzhyk.....\n");
            Thread.Sleep(2000);
            Console.WriteLine($"\t{Name} has arrived to destination ~ {coordsToFly.Latitude}x{ coordsToFly.Longitude} ~\n");
            Thread.Sleep(2000);
        }
    }
}
