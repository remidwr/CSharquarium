using CSharquarium_v2.Enums;
using CSharquarium_v2.Models.Seaweeds;
using System;
using System.Collections.Generic;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class HerbivorousFish : Fish
    {
        protected HerbivorousFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        protected HerbivorousFish(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }

        public void Eat(Aquarium aquarium)
        {
            Random Rng = new Random();
            List<Seaweed> Seaweeds = aquarium.Seaweeds;

            int Random = Rng.Next(Seaweeds.Count);
            Seaweed Seaweed = Seaweeds[Random];

            Seaweed.RemovePV(2);
            this.AddPV(3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{this.Name} ate a seaweed !");
        }
    }
}
