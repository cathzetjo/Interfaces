using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    sealed class Suicide : CombatHelicopter
    {
        private static readonly int deathBomb = 1;
        public new static readonly int fuelMax = 10000;

        public Suicide() : base() { Type = "Suicide"; }                                                      // Default Constructor

        public Suicide(string nameGeneral, string modelGeneral, int weighGeneral, 
            int carry, int rockets)                                                        // Syntax Constructor 
                    : base(nameGeneral, modelGeneral, weighGeneral, carry, rockets)
        {
            Type = "Suicide";
        }

        public Suicide(Suicide suicide)                                                    // Copy Constructor 
        {
            this.Type = suicide.Type;
            this.Name = suicide.Name;
            this.Model = suicide.Model;
            this.Weight = suicide.Weight;
            this.Fuel = suicide.Fuel;
            this.Carrying = suicide.Carrying;
            this.Rockets = suicide.Rockets;
        }

        public override string ToString()                                                  // Override overrided Method ToString

        {
            return base.ToString() + $" \n\t\tDeath bomb: {deathBomb}";
        }
        
        public override void Fly(Coords coordsToFly)                                       // Override Method Fly
        {
            Thread.Sleep(1000);
            Console.Write($"\t\tThe death is close....  \n");
            Thread.Sleep(3000);
            base.Fly(coordsToFly);
            JumpSkyDivers();
            Shoot();

            Console.WriteLine("Not enough demage? Still wanna destroy the whole world? \n\n\t\t1 -> Yes, let them all die!\n\t\t2 -> No.Stop me please.");

            short choise = Convert.ToInt16(Console.ReadLine());                                
            Thread.Sleep(500);

            switch (choise)
            {
                case 1:
                    Thread.Sleep(1000);
                    Console.WriteLine("\t\tDeath bomb go!\n");
                    Thread.Sleep(2500);
                    Console.WriteLine($"\t\tBloooooooooooooooow! \\|/ \\|/ \\|/ \\|/ \\|/\n");
                    Thread.Sleep(3500);
                    Console.WriteLine($"\t______________________________________________________" +
                        $"\n\t\t\tThe world was destroyed!\n\t\tYou better search for new home now. O|O \n");
                    Process.GetCurrentProcess().Kill();
                    break;

                case 2:

                    Console.WriteLine("!");
                    Console.WriteLine($"\n\tThanks God...\n\t{Type} \"{Name}\" go back to base ~ {coordsToFly.Latitude=0}x{ coordsToFly.Longitude=0} ~ now!\n");
                    break;

            }

        }

    }
}
