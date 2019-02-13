using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Bomber : Plane
    {
        protected int bombs;

        public int Bombs                                                                      // Properties: bombs >= 0
        {
            get
            {
                return this.bombs;
            }
            set
            {
                if (value >= 0)
                {
                    this.bombs = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Bomber() : base() { Type = "Bomber"; Bombs = 0; }                                               // Default Constructor

        public Bomber(string nameGeneral, string modelGeneral, int weighGeneral, int capacity, int passengers, int bombs)  // Syntax Constructor 
                            : base(nameGeneral, modelGeneral, weighGeneral, capacity, passengers)
        {
            Bombs = bombs;
            Type = "Bomber";
        }

        public Bomber(Bomber bomber)                                                   // Copy Constructor 
        {
            this.Type = bomber.Type;
            this.Name = bomber.Name;
            this.Model = bomber.Model;
            this.Weight = bomber.Weight;
            this.Fuel = bomber.Fuel;
            this.Capacity = bomber.Capacity;
            this.Passengers = bomber.Passengers;
            this.Bombs = bomber.Bombs;
        }

        public override string ToString()                                             // Override overrided Method ToString

        {
            return base.ToString() + $" \n\t\tBombs: {Bombs}";
        }

        public void LoadBombs()
        {
            Console.Write($"\tHow many bombs you want to load  (max number is {Capacity - Bombs}): ");
            this.Bombs = this.Bombs + Convert.ToInt32(Console.ReadLine());
            if (Bombs < Capacity)
            {

                Console.WriteLine($"\n\tIn {Type} {Name} was loaded {Bombs} bombs.\n");
            }
            else
            {
                Console.WriteLine($"\n\n\t\tWrong!\nNumber of bombs for {Type} {Name} have to be " +
                    $"between 0 and {Capacity}\n\t\tTry again.\n");
                this.Bombs = 0;
            }
        }

        public void DropBombs()
        {
            Console.Write($"\tHow many bombs you want to drop (max number is {Bombs}): ");
            int numOfBombsDropped = Convert.ToInt32(Console.ReadLine());
            this.Bombs = this.Bombs - numOfBombsDropped;
            int destroyed = 0;
            for (int i = 0; i < numOfBombsDropped; ++i)
            {
                Random randBlown = new Random();
                int randNumber = randBlown.Next(0, 10);


                if (randNumber > 3)
                {
                    Thread.Sleep(1500);
                    Console.Write($"\n\t\tBomb goes!\t");
                    Thread.Sleep(2500);
                    Console.WriteLine($"\tBloooooooooooooooow! \\|/ \n");
                    Thread.Sleep(2500);
                    Console.WriteLine($"\t{i + 1} target was destroyed! O_O \n");
                    ++destroyed;
                }
                else
                {
                    Thread.Sleep(1500);
                    Console.Write($"\n\t\tBomb goes!\t");
                    Thread.Sleep(2500);
                    Console.WriteLine($"\tBloooooooooooooooow! \\|/ \n");
                    Thread.Sleep(2500);
                    Console.WriteLine($"\tUgh.. Target {i + 1} wasn`t destroyed\n");
                }
            }
            Thread.Sleep(1500);
            Console.WriteLine($"\n\tBombing was finished.\n\tWas sucsessfully destroyed {destroyed} targets." +
                $" \n\tFailed drops : {numOfBombsDropped-destroyed}\n\tIn {Type} {Name} are avaliable {Bombs} bombs for now.\n");
        }
    }    
}

