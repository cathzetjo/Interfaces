using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Plane : Aircrafts
    {

        protected int capacity;
        protected int passengers;
        private static readonly int passToFlyMax = 500;
        private static readonly int passToFlyMin = 10;
        public new static readonly int fuelMax = 6000;

        public int Capacity                                                                      // Properties: capacity >= 0
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

        public int Passengers                                                                      // Properties: passengers >= 0
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

        public Plane() : base() { Type="Plane"; Capacity = 500; Passengers = 0; }                                // Default Constructor

        public Plane(string nameGeneral, string modelGeneral, int weighGeneral, int capacity, int passengers)  // Syntax Constructor 
                            : base(nameGeneral, modelGeneral, weighGeneral)
        {
            Capacity = capacity;
            Passengers = passengers;
            Type = "Plane";
        }

        public Plane(Plane plane)                                                   // Copy Constructor 
        {
            this.Type = plane.Type;
            this.Name = plane.Name;
            this.Model = plane.Model;
            this.Weight = plane.Weight;
            this.Fuel = plane.Fuel;
            this.Capacity = plane.Capacity;
            this.Passengers = plane.Passengers;
        }

        public override string ToString()                                                        // Override overrided Method ToString

        {
            return base.ToString() + $" \n\t\tNumber of passengers: {Passengers} people";
        }

        public void LoadPassengers()
        {
            Console.Write($"\tHow many passengers are going to fly (number between {passToFlyMin}-{Capacity - Passengers}): ");
            this.Passengers = this.Passengers + Convert.ToInt32(Console.ReadLine());
            if (Passengers < Capacity && Passengers < passToFlyMax && Passengers > passToFlyMin)
            {

                Console.WriteLine($"\n\tIn {Type} {Name} are seating now {Passengers} passengers.\n");
            }
            else
            {
                Console.WriteLine($"\n\n\t\tWrong!\n\t\tNumber of passengers for {Type} {Name} have to be between {passToFlyMin} " +
                    $"and {passToFlyMax} people." +
                    $" \n\t\tTry again. ;)\n");
                this.Passengers = 0;
                Console.ReadKey();
            }
        }

        public void DropOff()
        {
            Console.WriteLine($"\t Lets drop {Passengers} passengers off.\n ");
            int alive = 0;

            for (int i = 0; i < Passengers; ++i)
            {
                Random randAlive = new Random();
                int randNumber = randAlive.Next(0, 10);


                if (randNumber > 1)
                {
                    Console.WriteLine($"\t\t{i + 1} passanger left the plane");
                    Thread.Sleep(1500);
                    ++alive;
                }


                else
                {
                    Console.WriteLine($"\t\t{i + 1} passanger broke his legs and died...");
                    Thread.Sleep(1500);
                }
            }
            Console.WriteLine($"\n\t\t\tDone.\n\t{alive} passangers successfully reached destination." +
                $"\n\t{Passengers - alive} wasnt so lucky...\n\n\t{Type} {Name} are ready now for new flight.\n");
            this.Passengers = 0;
        }

    }
}

