using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {

        static void Main(string[] args)
        {
            Helicopter helicopter1 = new Helicopter("Mr.Fly", "Boeing Sikorsky RAH - 66 Comanche", 4218, 15);
            Helicopter helicopter2 = new Helicopter(helicopter1) { Name = "Mrs.Fly" };
            Helicopter helicopter3 = new Helicopter("Jonny", "McDonnell Douglas AH-64 Apache", 5500, 20);
            List<Helicopter> helicoptersList = new List<Helicopter>(capacity: 0);
            helicoptersList.Add(helicopter1);
            helicoptersList.Add(helicopter2);
            helicoptersList.Add(helicopter3);


            CombatHelicopter coHelicopter1 = new CombatHelicopter("Sunny", "Lockheed AH-56 Cheyenne", 3900, 2, 0);
            CombatHelicopter coHelicopter2 = new CombatHelicopter("Fastman", "Boeing RAH - 10 Comanche", 3200, 3, 0);
            CombatHelicopter coHelicopter3 = new CombatHelicopter(coHelicopter2) { Name = "Fastgirl", Weight = 3150 };
            List<CombatHelicopter> coHelicoptersList = new List<CombatHelicopter>(capacity: 0);
            coHelicoptersList.Add(coHelicopter1);
            coHelicoptersList.Add(coHelicopter2);
            coHelicoptersList.Add(coHelicopter3);


            Suicide suicide1 = new Suicide("Darkness", "Machine 666", 66666, 20, 0);
            Suicide suicide2 = new Suicide(suicide1) { Name = "Hell" };
            Suicide suicide3 = new Suicide(suicide2) { Name = "Demon" };
            List<Suicide> suicidesList = new List<Suicide>(capacity: 0);
            suicidesList.Add(suicide1);
            suicidesList.Add(suicide2);
            suicidesList.Add(suicide3);

            Plane plane1 = new Plane("Bird", "Boeing 747 S200", 160000, 425, 0);
            Plane plane2 = new Plane(plane1) { Name = "Butterfly", Model = "Airbus A330", Capacity = 400 };
            Plane plane3 = new Plane("Bee", "TY 134", 120000, 90, 0);
            List<Plane> planesList = new List<Plane>(capacity: 0);
            planesList.Add(plane1);
            planesList.Add(plane2);
            planesList.Add(plane3);

            Bomber bomber1 = new Bomber("Forrest Gump", "Rockwell B-1 Lancer", 70300, 50, 0, 0);
            Bomber bomber2 = new Bomber(bomber1) { Name = "Spirit", Model = "Northrop B-2", Capacity = 40 };
            Bomber bomber3 = new Bomber("Black Jack", "TY-160", 95000, 90, 0, 0);
            List<Bomber> bombersList = new List<Bomber>(capacity: 0);
            bombersList.Add(bomber1);
            bombersList.Add(bomber2);
            bombersList.Add(bomber3);


            Bird bird1 = new Bird("Bobby", "Seagull");
            Bird bird2 = new Bird(bird1) { Name = "Lili" };
            List<Bird> birdsList = new List<Bird>(capacity: 0);
            birdsList.Add(bird1);
            birdsList.Add(bird2);

            Train train1 = new Train("French Boy", "TGV", 2000);
            Train train2 = new Train("Japanese Girl", "Shinkansen", 1900);
            List<Train> trainsList = new List<Train>(capacity: 0);
            trainsList.Add(train1);
            trainsList.Add(train2);

            List<IFlyable> flyablesList = new List<IFlyable>
            {
                bird1,
                helicopter1,
                coHelicopter1,
                plane1,
                bomber1
            };

            List<IRefuelable> refuelablesList = new List<IRefuelable>
            {
                helicopter1,
                helicopter2,
                helicopter3,
                coHelicopter1,
                coHelicopter2,
                coHelicopter3,
                suicide1,
                suicide2,
                suicide3,
                plane1,
                plane2,
                plane3,
                bomber1,
                bomber2,
                bomber3,
                train1,
                train2
            };

            void SendAllToSouth(List<IFlyable> flyables)
            {
                Console.WriteLine("\n\t\tThere are all avaliable flyable objects :\n");
                Thread.Sleep(1000);
                for (int i = 0; i < flyables.Count; i++)
                {
                    Console.Write($"\n{ flyables[i]}\n");
                }

                Console.WriteLine("\n     ~ ~ ~ ~ OK, lets send them all to the warm places ~ ~ ~ ~ ~\n");
                Thread.Sleep(2000);

                for (int i = 0; i < flyables.Count; i++)
                {
                    flyables[i].Fly(Coords.south);
                }

                Thread.Sleep(2000);
                Console.WriteLine($"\n\t~ ~ ~ ~ Great, {flyables.Count} objects has arrived to the SOUTH! ~ ~ ~ ~ ~\n");
                Console.ReadKey();
            }     // Method Fly_to_South for all objects from Interface Iflyable

            void RefuelAll(List<IRefuelable> refuelables)
            {

                Console.WriteLine($"\n\t\t{refuelables.Count} objects will be refuel.");
                Thread.Sleep(1000);

                Console.Write($"\tHow many liters you want to dope (till {Aircrafts.fuelMax})): ");
                int fuelNum = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < refuelables.Count; i++)
                {
                    refuelables[i].Refuel(fuelNum);
                }

                Thread.Sleep(2000);
                Console.WriteLine($"\n\t~ ~ ~ ~ All {refuelables.Count} objects are ready for using now! ~ ~ ~ ~ ~\n");
                Console.ReadKey();
            }    // Method Refuel_All for all objects from Interface IRefuelable

            int index = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\t\t\t\tPress:\n\n\t\t\t1 -> Choose aircraft object\n\t\t\t2 -> Choose other object" +
                    "\n\t\t\t3 -> Refuel all objects\n\t\t\t4 -> Send all flyables to South\n\t\t\t5 -> Exit");
                short choise;
                string choiseTemp = Console.ReadLine();                                 // user choose action

                if (Int16.TryParse(choiseTemp, out choise))
                {
                    Console.Clear();

                    switch (choise)
                    {
                        case 1:

                            Console.Clear();
                            Console.WriteLine("\t\t\tPress to choose:\n\n\t\t1 -> Helicopter \n\t\t2 -> Combat Helicopter " +
                                "\n\t\t3 -> Suicide \n\t\t4 -> Plane\n\t\t5 -> Bomber");
                            short choisetype = Convert.ToInt16(Console.ReadLine());                // user choose type
                            Thread.Sleep(500);
                            switch (choisetype)

                            {

                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Helicopters are available:\n");

                                    for (int i = 0; i < helicoptersList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + helicoptersList[i].Name + "\n");
                                    }

                                    if (helicoptersList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < helicoptersList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }
                                    }
                                    short choiseAction = 0;
                                    while (choiseAction != 5)                                          //case 5 for Exit
                                    {
                                        Console.WriteLine("\n\t\t      Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel " +
                                            "\n\t\t2 -> Load Sky Divers \n\t\t3 -> Fly and make Sky Divers jump \n\t\t4 -> " +
                                            "Show information \n\t\t5 -> Back to main menu");
                                        choiseAction = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction)
                                        {
                                            case 1:

                                                Console.Write($"\tHow many liters you want to dope (till {Helicopter.fuelMax - helicoptersList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                helicoptersList[index].Refuel(fuelNum);
                                                break;


                                            case 2:
                                                helicoptersList[index].LoadSkyDivers();
                                                break;


                                            case 3:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                helicoptersList[index].Fly(toPos);
                                                helicoptersList[index].JumpSkyDivers();
                                                break;

                                            case 4:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {helicoptersList[index]}");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Combat Helicopters are available:\n");

                                    for (int i = 0; i < coHelicoptersList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + coHelicoptersList[i].Name + "\n");
                                    }

                                    if (coHelicoptersList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < coHelicoptersList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }

                                    }

                                    short choiseAction2 = 0;
                                    while (choiseAction2 != 5)                                          //case 5 for Exit
                                    {
                                        Console.WriteLine("\n\t\t Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel " +
                                            "\n\t\t2 -> Load Rockets \n\t\t3 -> Fly and shoot \n\t\t4 -> Show information" +
                                            "\n\t\t5 -> Back to main menu");
                                        choiseAction2 = Convert.ToInt16(Console.ReadLine());            // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction2)
                                        {
                                            case 1:
                                                Console.Write($"\tHow many liters you want to dope (till {CombatHelicopter.fuelMax - coHelicoptersList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                coHelicoptersList[index].Refuel(fuelNum);
                                                break;

                                            case 2:
                                                coHelicoptersList[index].LoadRockets();
                                                break;

                                            case 3:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                coHelicoptersList[index].Fly(toPos);
                                                coHelicoptersList[index].Shoot();
                                                Console.ReadKey();
                                                break;

                                            case 4:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {coHelicoptersList[index]}");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;


                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Suicedes are available:\n");

                                    for (int i = 0; i < suicidesList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + suicidesList[i].Name + "\n");
                                    }

                                    if (suicidesList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < suicidesList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }
                                    }
                                    short choiseAction3 = 0;
                                    while (choiseAction3 != 6)                                          //case 6 for Exit
                                    {
                                        Console.WriteLine("\n\t\t      Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel" +
                                      " \n\t\t2 -> Load Sky Divers \n\t\t3 -> Load Rockets \n\t\t4 -> " +
                                      "Fly and kill the world \n\t\t5 -> Show information\n\t\t6 -> Back to main menu");
                                        choiseAction3 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction3)
                                        {
                                            case 1:
                                                Console.Write($"\tHow many liters you want to dope (till {Suicide.fuelMax - suicidesList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                suicidesList[index].Refuel(fuelNum);
                                                break;

                                            case 2:
                                                suicidesList[index].LoadSkyDivers();
                                                break;

                                            case 3:
                                                suicidesList[index].LoadRockets();
                                                break;


                                            case 4:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                suicidesList[index].Fly(toPos);
                                                Console.ReadKey();
                                                break;

                                            case 5:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {suicidesList[index]}");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;


                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Planes are available:\n");

                                    for (int i = 0; i < planesList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + planesList[i].Name + "\n");
                                    }

                                    if (planesList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < planesList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }
                                    }
                                    short choiseAction4 = 0;
                                    while (choiseAction4 != 5)                                          //case 5 for Exit
                                    {
                                        Console.WriteLine("\n\t\t      Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel " +
                                        "\n\t\t2 -> Load Passengers \n\t\t3 -> Choose destination and bring passengers there" +
                                        " \n\t\t4 -> Show information \n\t\t5 -> Back to main menu");
                                        choiseAction4 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction4)
                                        {
                                            case 1:
                                                Console.Write($"\tHow many liters you want to dope (till {Plane.fuelMax - planesList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                planesList[index].Refuel(fuelNum);
                                                break;

                                            case 2:
                                                planesList[index].LoadPassengers();
                                                break;

                                            case 3:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                planesList[index].Fly(toPos);
                                                planesList[index].DropOff();
                                                Console.ReadKey();
                                                break;

                                            case 4:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {planesList[index]}");
                                                Console.ReadKey();
                                                break;

                                        }
                                    }
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Bombers are available:\n");

                                    for (int i = 0; i < bombersList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + bombersList[i].Name + "\n");
                                    }

                                    if (bombersList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < bombersList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }
                                    }
                                    short choiseAction5 = 0;
                                    while (choiseAction5 != 5)                                          //case 5 for Exit
                                    {
                                        Console.WriteLine("\n\t\t      Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel " +
                                        "\n\t\t2 -> Load bombs \n\t\t3 -> Fly and drop bombs  \n\t\t4 -> Show information" +
                                        "\n\t\t5 -> Back to main menu");
                                        choiseAction5 = Convert.ToInt16(Console.ReadLine());            // user choose action
                                        Thread.Sleep(500);


                                        switch (choiseAction5)
                                        {
                                            case 1:
                                                Console.Write($"\tHow many liters you want to dope (till {Bomber.fuelMax - bombersList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                bombersList[index].Refuel(fuelNum);
                                                break;

                                            case 2:
                                                bombersList[index].LoadBombs();
                                                break;


                                            case 3:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                bombersList[index].Fly(toPos);
                                                bombersList[index].DropBombs();
                                                Console.ReadKey();
                                                break;

                                            case 4:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {bombersList[index]}");
                                                Console.ReadKey();
                                                break;

                                        }
                                    }
                                    break;

                            }
                            break;

                        case 2:

                            Console.Clear();
                            Console.WriteLine("\t\t\tPress to choose:\n\n\t\t1 -> Bird \n\t\t2 -> Train ");
                            short choisetype2 = Convert.ToInt16(Console.ReadLine());                // user choose type
                            Thread.Sleep(500);
                            switch (choisetype2)

                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext birds are available:\n");

                                       for (int i = 0; i < birdsList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + birdsList[i].Name + "\n");
                                    }

                                    if (birdsList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < birdsList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }
                                    }
                                    short choiseAction = 0;
                                    while (choiseAction != 3)                                          //case 3 for Exit
                                    {
                                        Console.WriteLine("\n\t\t      Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Fly" +
                                            "\n\t\t2 -> Show information \n\t\t3 -> Back to main menu");
                                        choiseAction = Convert.ToInt16(Console.ReadLine());           // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction)
                                        {
                                            case 1:

                                                Console.Write("Enter coordinate of latitude: ");
                                                short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                                Console.Write("Enter coordinate of longitude: ");
                                                short choiseLongitude = Convert.ToInt16(Console.ReadLine());
                                                Coords toPos = new Coords(choiceLatitude, choiseLongitude);
                                                birdsList[index].Fly(toPos);
                                                Console.ReadKey();

                                                break;


                                            case 2:

                                                Console.WriteLine($"\n\t\tInformation about currant bird:\n\n {birdsList[index]}");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tNext Trains are available:\n");

                                    for (int i = 0; i < trainsList.Count; i++)
                                    {
                                        Console.Write("\t\t\t" + i + "  ->  " + trainsList[i].Name + "\n");
                                    }

                                    if (trainsList.Count != 0)
                                    {
                                        short choiseName = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                        if (choiseName >= 0 && choiseName < trainsList.Count)
                                        {
                                            index = choiseName;

                                            Console.Clear();
                                        }

                                    }

                                    short choiseAction2 = 0;
                                    while (choiseAction2 != 3)                                          //case 5 for Exit
                                    {
                                        Console.WriteLine("\n\t\t Choose actions: \n\n\t\t\tPress:\n\n\t\t1 -> Refuel " +
                                            "\n\t\t2 -> Show information \n\t\t3 -> Back to main menu");
                                        choiseAction2 = Convert.ToInt16(Console.ReadLine());            // user choose action
                                        Thread.Sleep(500);

                                        switch (choiseAction2)
                                        {
                                            case 1:
                                                Console.Write($"\tHow many liters you want to dope (till {Train.fuelMax - trainsList[index].Fuel})): ");
                                                int fuelNum = Convert.ToInt32(Console.ReadLine());
                                                trainsList[index].Refuel(fuelNum);
                                                break;

                                            case 2:
                                                Console.WriteLine($"\n\t\tInformation about currant aircraft:\n\n {trainsList[index]}");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                            }
                            break;

                        case 3:

                            RefuelAll(refuelablesList);
                            break;

                        case 4:
                            
                            SendAllToSouth(flyablesList);
                            break;

                        case 5:

                            Environment.Exit(0);
                            break;


                        //case 2 when index != -1:                                                      
                        //    break;


                        default:

                            if (index == -1)
                            {
                                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\t\t\tChoose any object at first...");
                                Console.ReadKey();
                            }

                            break;
                    }

                }

            }
            while (true);

        }

    }
}


