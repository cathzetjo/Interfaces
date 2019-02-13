using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Train: IRefuelable
    {
        private int capacity;
        private int fuel;
        private int passengers;
        public static readonly int fuelMax = 7000;

        public string Type { get; protected set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public int Passengers                                                               // Properties: passengers >= 0
        {
            get
            {
                return this.passengers;
            }
            set
            {
                if (value >= 0)
                {
                    this.passengers = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public int Capacity                                                                // Properties: capacity >= 0
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value >= 0)
                {
                    this.capacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Fuel                                                                    // Properties: fuel >= 0
        {
            get
            {
                return this.fuel;
            }
            set
            {
                if (value >= 0)
                {
                    this.fuel = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Train()                                                                     // Default Constructor
        {
            Type = "Train";
            Name = "Some name";
            Model = "Some model";
            Fuel = 0;
        }

        public Train(string name, string model, int capacity)                             // Syntax Constructor 
        {
            Type = "Train";
            Name = name;
            Model = model;
            Fuel = 0;
            Capacity = capacity;
        }

        public override string ToString()                                                 // Override Method ToString
        {
            Thread.Sleep(2000);
            return $"\t\tType: {Type} \n\t\tName: {Name} \n\t\tModel: {Model} \n\t\tCapacity: {Capacity} people" +
                $"\n\t\tFuel: {Fuel} liters \n\t\tPassengers: {Passengers} people";
        }

        public Train(Train train)                                                         // Copy Constructor 
        {
            this.Type = "Train";
            this.Name = train.Name;
            this.Model = train.Model;
            this.Fuel = train.Fuel;
            this.Capacity = train.Capacity;
            this.Passengers = train.Passengers;
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
