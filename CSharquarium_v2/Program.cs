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
            Aquarium.AddFish(new Grouper("Azizam", Sex.Female));
            Aquarium.AddFish(new ClownFish("Lilo", Sex.Male));
            Aquarium.AddFish(new ClownFish("Robertine", Sex.Female));
            Aquarium.AddFish(new Sole("Kiwi", Sex.Male));
            Aquarium.AddFish(new Bar("Nils", Sex.Male));
            Aquarium.AddFish(new Bar("Helene", Sex.Female));
            Aquarium.AddFish(new Carp("Balou", Sex.Male));
            Aquarium.AddSeaweed(new Seaweed());

            Console.Write(Aquarium);

            while (!Console.ReadLine().ToUpper().Equals("Q"))
            {
                Aquarium.Action();
                Console.Write(Aquarium);
            }
        }
    }
}
