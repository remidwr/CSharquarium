using CSharquarium_v2.Enums;
using System;
using System.Collections.Generic;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class CarnivorousFish : Fish
    {
        protected CarnivorousFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        protected CarnivorousFish(string name, Sex sex, int age) : base(name, sex, age)
        {
        }

        public void Eat(Aquarium aquarium)
        {
            Random Rng = new Random();
            List<Fish> Fishes = aquarium.Fishes;
            int Random = Rng.Next(Fishes.Count);
            Fish Fish = Fishes[Random];

            if (Fish.Name.Equals(this.Name) || Fish.GetType().Equals(this.GetType()))
            {
                Fish.RemovePV(4);
                this.AddPV(5);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{this.Name} ate {Fish.Name} !");
            }
        }
    }
}
