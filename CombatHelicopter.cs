using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class CombatHelicopter : Helicopter
    {
        protected int rockets;
        private static readonly int rocketsMax = 10;

        public int Rockets                                                                      // Properties: rockets >= 0
        {
            get
            {
                return this.rockets;
            }
            set
            {
                if (value >= 0)
                {
                    this.rockets = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public CombatHelicopter() : base() { Type = "Combat Helicopter"; Rockets = 0; }                                     // Default Constructor
        public CombatHelicopter(string nameGeneral, string modelGeneral, int weighGeneral, int carry, int rockets)  // Syntax Constructor 
                    : base(nameGeneral, modelGeneral, weighGeneral, carry)
        {
            Rockets = rockets;
            Type = "Combat Helicopter";
        }

        public CombatHelicopter(CombatHelicopter combatHelicopter)                                    // Copy Constructor 
        {
            this.Type = combatHelicopter.Type;
            this.Name = combatHelicopter.Name;
            this.Model = combatHelicopter.Model;
            this.Weight = combatHelicopter.Weight;
            this.Fuel = combatHelicopter.Fuel;
            this.Carrying = combatHelicopter.Carrying;
            this.Rockets = combatHelicopter.Rockets;
        }

        public override string ToString()                                                        // Override overrided Method ToString

        {
            return base.ToString() + $" \n\t\tRockets: {Rockets}";
        }

        public void LoadRockets()
        {
            Console.Write($"\tHow many rockets need to be loaded (max number is {rocketsMax - Rockets}): ");
            this.Rockets = this.Rockets + Convert.ToInt32(Console.ReadLine());
            if (Rockets < rocketsMax)
            {

                Console.WriteLine($"\n\tIn {Type} {Name} there are {Rockets} rocket(s) now.\n");
            }
            else
            {
                Console.WriteLine($"\n\n\t\tAttention!\n\tMaximum of rockets for {Type} {Name} is {rocketsMax}." +
                    $" \n\t\tTry again.\n");
                this.Rockets = 0;
            }
        }

        public virtual void Shoot()
        {
            Console.Write($"\tWith how many rockets you want to shoot (max number is {Rockets}): ");
            this.Rockets = this.Rockets - Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(2000);
            Console.Write($"\n\t\tBang Bang Bang!!! \n");
            Thread.Sleep(3000);
            Console.WriteLine($"\n\tIn {Type} {Name} are left {Rockets} rocket(s) for now.\n");
        }
    }
}
