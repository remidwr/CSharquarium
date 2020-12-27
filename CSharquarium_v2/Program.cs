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

            while (!Console.ReadLine().ToUpper().Equals("Q"))
            {
                Aquarium.Action();
                Console.Write(Aquarium);
            }
        }
    }
}
