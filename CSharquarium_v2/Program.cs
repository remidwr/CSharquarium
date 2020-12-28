using CSharquarium_v2.Enums;
using CSharquarium_v2.Models;
using CSharquarium_v2.Models.Fishes.Carnivorous;
using CSharquarium_v2.Models.Fishes.Herbivorous;
using CSharquarium_v2.Models.Seaweeds;
using System;

namespace CSharquarium_v2
{
    class Program
    {
        private static Aquarium Aquarium = new Aquarium();

        static void Main(string[] args)
        {
            AddFishesAndSeaweeds();
            LiveAquarium();
        }

        private static void AddFishesAndSeaweeds()
        {
            //Aquarium.AddFish(new Tuna("Carlito", Sex.Male, 5));
            Aquarium.AddFish(new Tuna("Lila", Sex.Female, 7));
            Aquarium.AddFish(new Grouper("Cacao", Sex.Male, 8));
            Aquarium.AddFish(new ClownFish("Homer", Sex.Male, 2));
            //Aquarium.AddFish(new ClownFish("Bob", Sex.Male, 2));
            //Aquarium.AddFish(new Sole("Kira", Sex.Female, 11));
            Aquarium.AddFish(new Sole("Anna", Sex.Female, 3));
            Aquarium.AddFish(new Bar("Nils", Sex.Male, 7));
            Aquarium.AddFish(new Bar("Helene", Sex.Female, 4));
            Aquarium.AddFish(new Carp("Balou", Sex.Male, 1));
            Aquarium.AddFish(new Carp("Bagera", Sex.Male, 6));
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());
        }

        private static void LiveAquarium()
        {
            Console.Write(Aquarium);

            while (AquariumMenu())
            {
                Aquarium.Action();
                Console.Write(Aquarium);
            }
        }

        private static bool AquariumMenu()
        {
            int choice, count = 0;

            Console.WriteLine("\nMENU :");
            Console.WriteLine("[1] CONTINUE");
            Console.WriteLine("[2] STOP");
            Console.WriteLine("[3] ADD FISH or SEAWEED");

            do
            {
                if (count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID CHOICE ! Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                int.TryParse(Console.ReadLine(), out choice);
                count++;
            } while (choice < 1 || choice > 3);

            switch (choice)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                case 3:
                    AddFishOrSeaweed();
                    return true;
                default:
                    return true;
            }
        }

        private static void AddFishOrSeaweed()
        {
            int choice, count = 0, age;
            char confirmed;

            Console.WriteLine("[1] ADD FISH");
            Console.WriteLine("[2] ADD SEAWEED");
            Console.WriteLine("[3] BACK TO MAIN MENU");

            do
            {
                if (count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID CHOICE ! Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                int.TryParse(Console.ReadLine(), out choice);
                count++;
            } while (choice < 1 || choice > 3);

            switch (choice)
            {
                case 1:
                    AddingFish();
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Which AGE do you want to choose for SEAWEED");
                        int.TryParse(Console.ReadLine(), out age);
                        Console.WriteLine($"Do you want to confirmed the AGE of {age} ? Y/N");
                        char.TryParse(Console.ReadLine().ToUpper(), out confirmed);
                    } while (age < 0 || age > 20 || confirmed != 'Y');

                    Aquarium.AddSeaweed(new Seaweed(age));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old SEAWEED.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            AquariumMenu();
        }

        private static void AddingFish()
        {
            int choice, count = 0, age;
            string fishName, sexFish;
            char confirmed;
            Sex sex;

            Console.WriteLine("[1] ADD CLOWNFISH");
            Console.WriteLine("[2] ADD GROUPER");
            Console.WriteLine("[3] ADD TUNA");
            Console.WriteLine("[4] ADD BAR");
            Console.WriteLine("[5] ADD CARP");
            Console.WriteLine("[6] ADD SOLE");

            do
            {
                if (count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID CHOICE ! Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                int.TryParse(Console.ReadLine(), out choice);
                count++;
            } while (choice < 1 || choice > 6);

            do
            {
                Console.WriteLine("Which NAME do you want to choose for your FISH ?");
                fishName = Console.ReadLine();
                Console.WriteLine($"Do you want to confirmed the NAME ({fishName.ToUpper()}) ? Y/N");
                char.TryParse(Console.ReadLine().ToUpper(), out confirmed);
            } while (confirmed != 'Y');

            do
            {
                Console.WriteLine($"Which SEX do you want to choose for {fishName.ToUpper()} ? M/F");
                do
                {
                    sexFish = Console.ReadLine().ToUpper();
                } while (sexFish != "M" && sexFish != "F");

                if (sexFish == "M")
                {
                    sexFish = Sex.Male.ToString();
                    sex = Sex.Male;
                }
                else
                {
                    sexFish = Sex.Female.ToString();
                    sex = Sex.Female;
                }

                Console.WriteLine($"Do you want to confirmed the SEX ({sexFish}) ? Y/N");
                char.TryParse(Console.ReadLine().ToUpper(), out confirmed);
            } while (confirmed != 'Y');

            do
            {
                Console.WriteLine($"Which AGE do you want to choose for {fishName.ToUpper()}");
                int.TryParse(Console.ReadLine(), out age);
                Console.WriteLine($"Do you want to confirmed the AGE of {age} ? Y/N");
                char.TryParse(Console.ReadLine().ToUpper(), out confirmed);
            } while (age < 0 || age > 20 || confirmed != 'Y');

            Console.WriteLine($"Are you sure to add {fishName.ToUpper()} ? Y/N");
            char.TryParse(Console.ReadLine().ToUpper(), out confirmed);

            if (confirmed == 'Y')
            {
                switch (choice)
                {
                    case 1:
                        Aquarium.AddFish(new ClownFish(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old CLOWNFISH ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        Aquarium.AddFish(new Grouper(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old GROUPER ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        Aquarium.AddFish(new Tuna(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old TUNA ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        Aquarium.AddFish(new Bar(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old BAR ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        Aquarium.AddFish(new Carp(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old CARP ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 6:
                        Aquarium.AddFish(new Sole(fishName, sex, age));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCONGRATULATION ! You have a new {age} year old SOLE ({sex}) named {fishName}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }
            }
            else
                AquariumMenu();
        }
    }
}
