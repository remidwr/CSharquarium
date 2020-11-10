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
        static void Main(string[] args)
        {
            Aquarium Aquarium = new Aquarium();

            Aquarium.AddFish(new Tuna("Carl", Sex.Male));
            Aquarium.AddFish(new Grouper("Lili", Sex.Female));
            Aquarium.AddFish(new ClownFish("Robertine", Sex.Female));
            Aquarium.AddFish(new Sole("Kiwi", Sex.Male));
            Aquarium.AddFish(new Bar("Nils", Sex.Male));
            Aquarium.AddFish(new Bar("Nila", Sex.Female));
            Aquarium.AddFish(new Bar("Alex", Sex.Male));
            Aquarium.AddFish(new Bar("Helene", Sex.Female));
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());
            Aquarium.AddSeaweed(new Seaweed());

            Console.WriteLine(Aquarium);
            while (!Console.ReadLine().ToUpper().Equals("Q"))
            {
                Console.WriteLine(Aquarium.Action() + Aquarium);
            }
        }
    }
}
