using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    abstract class Aircrafts: IFlyable, IRefuelable
    {

        protected int weight;
        public int fuel;
        public static readonly int fuelMax = 5000;

        public string Type { get; protected set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public int Weight                                                              // Properties: weight > 0
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value > 0)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Fuel                                                                // Properties: fuelMax >= (fuel) >= 0
        {
            get
            {
                return this.fuel;
            }
            set
            {
                if (value >= 0 && value <=fuelMax)
                {
                    this.fuel = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Aircrafts()                                                             // Default Constructor
        {
            Type = "Some type";
            Name = "Some name";
            Model = "Some model";
            Weight = 1;
            Fuel = 0;
        }

        public Aircrafts(string nameGeneral, string modelGeneral, int weighGeneral)    // Syntax Constructor 
        {
            Name = nameGeneral;
            Model = modelGeneral;
            Weight = weighGeneral;
            Fuel = 0;
        }

        public override string ToString()                                              // Override Method ToString
        {
            Thread.Sleep(2000);
            return $"\t\tType: {Type} \n\t\tName: {Name} \n\t\tModel: {Model} \n\t\tWeight: {Weight} kg \n\t\tFuel: {Fuel} liters";
        }

        public virtual void Fly(Coords coordsToFly)
        {
            Console.WriteLine($"\n\t{Type} \"{Name}\" was send to destination ~ {coordsToFly.Latitude}x{ coordsToFly.Longitude} ~\n");
            Thread.Sleep(1000);
            Console.WriteLine($"\t\tDryn dryn.... dryn dryn dryn.....\n");
            Thread.Sleep(2000);
            Console.WriteLine($"\t{Type} \"{Name}\" has arrived to destination ~ {coordsToFly.Latitude}x{ coordsToFly.Longitude} ~\n");
            Thread.Sleep(2000);
        }

        public int Refuel(int fuelNum)

        {
            Fuel += fuelNum;
            if (Fuel < fuelMax)
            {
                Thread.Sleep(500);
                Console.WriteLine($"\n\tIn {Type} {Name} now {Fuel} liters of fuel.\n");
            }
            else
            {
                Console.WriteLine($"\n\n\t\t\t\tWrong!\n\t\tTotal amount have to be between 0 and {fuelMax}\n\t\t\t\tTry again.\n");
                this.Fuel = 0;
            }
            return fuelNum;

        }
    }
}
