using CSharquarium_v2.Interfaces;
using CSharquarium_v2.Models.Fishes;
using CSharquarium_v2.Models.Seaweeds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharquarium_v2.Models
{
    public class Aquarium
    {
        private List<Fish> Fishes = new List<Fish>();
        private List<Seaweed> Seaweeds = new List<Seaweed>();

        public void AddFish(Fish fish)
        {
            Fishes.Add(fish);
        }

        public void AddSeaweed(Seaweed seaweed)
        {
            Seaweeds.Add(seaweed);
        }

        public void Action()
        {
            UpdateStatus();
            ToClean(Fishes);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fishes are eating or making love...");
            LoveAndDinerTime();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private void LoveAndDinerTime()
        {
            List<Fish> HungryFishes = new List<Fish>(Fishes);
            List<Fish> FishesInLove = new List<Fish>(Fishes);

            if (Fishes.Count > 1)
            {
                for (int i = 0; i < Fishes.Count; i++)
                {
                    Fish CurrentFish = Fishes[i];
                    Random Rng = new Random();
                    int Target = Rng.Next(HungryFishes.Count);
                    Fish TargetFish = HungryFishes[Target];

                    while (CurrentFish == TargetFish)
                    {
                        Target = Rng.Next(HungryFishes.Count);
                        TargetFish = HungryFishes[Target];
                    }

                    if (CurrentFish.PV > 5
                        && FishesInLove.Contains(CurrentFish)
                        && FishesInLove.Contains(TargetFish)
                        && CurrentFish.GetType() == TargetFish.GetType())
                    {
                        if (CurrentFish is IOpportunistic
                            && CurrentFish.Sex == TargetFish.Sex)
                        {
                            ((IOpportunistic)CurrentFish).ChangeSex();
                        }
                        if (CurrentFish.Sex != TargetFish.Sex)
                        {
                            Fish Child = CurrentFish.MakeLove(CurrentFish.GetType(), CurrentFish.Name, TargetFish.Name);
                            HungryFishes.Add(Child);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{CurrentFish.Name} and {TargetFish.Name} had a baby ({Child.Name}) !");
                            FishesInLove.Remove(CurrentFish);
                            FishesInLove.Remove(TargetFish);
                        }
                    }

                    if (CurrentFish.PV <= 5 && HungryFishes.Contains(CurrentFish))
                    {
                        if (CurrentFish is CarnivorousFish)
                        {
                            if (CurrentFish.GetType() != TargetFish.GetType())
                            {
                                ((CarnivorousFish)CurrentFish).Eat(TargetFish);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"{CurrentFish.Name} ate {TargetFish.Name} !");
                            }
                        }
                        else if (Seaweeds.Count > 0)
                        {
                            Seaweed seaweed = Seaweeds[Rng.Next(Seaweeds.Count)];
                            ((HerbivorousFish)CurrentFish).Eat(seaweed);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{CurrentFish.Name} ate {TargetFish.Name} !");
                        }
                    }
                    ToClean(HungryFishes);
                }
                Fishes = HungryFishes;
            }
        }

        private void ToClean(List<Fish> fishes)
        {
            for (int i = fishes.Count - 1; i >= 0; i--)
            {
                Fish fish = fishes[i];
                if (fish.PV == 0 || fish.Age > 20)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{fish.Name} is dead !");
                    fishes.Remove(fish);
                }
            }

            for (int i = Seaweeds.Count - 1; i >= 0; i--)
            {
                Seaweed seaweed = Seaweeds[i];
                if (seaweed.PV == 0 || seaweed.Age > 20)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("A seaweed is dead !");
                    Seaweeds.Remove(seaweed);
                }
            }
        }

        private void UpdateStatus()
        {
            List<Seaweed> seaweeds = new List<Seaweed>(Seaweeds);
            for (int i = 0; i < Fishes.Count; i++)
            {
                Fishes[i].RemovePV(1);
                Fishes[i].AddAge(1);
            }
            for (int i = 0; i < seaweeds.Count; i++)
            {
                Seaweed Seaweed = Seaweeds[i];
                Seaweed.AddPV(1);
                Seaweed.AddAge(1);
                if (Seaweed.PV >= 10)
                {
                    Seaweed MiniSeaweed = Seaweed.Repoduction();
                    Seaweeds.Add(MiniSeaweed);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder Result = new StringBuilder();

            Result.Append("Seaweed :\n");
            if (Seaweeds.Count > 0)
            {
                Result.Append($"\t--> {Seaweeds.Count} seaweed(s)\n");
                for (int i = 0; i < Seaweeds.Count; i++)
                {
                    Result.Append($"\t\t- Seaweed n°{i + 1} | {Seaweeds[i]}\n");
                }
            }
            else
                Result.Append("\t--> No seaweeds into the aquarium\n");

            Result.Append("Fishes :\n");
            if (Fishes.Count > 0)
            {
                Result.Append($"\t--> {Fishes.Count} fishe(s)\n");
                for (int i = 0; i < Fishes.Count; i++)
                {
                    Result.Append($"\t\t- Fish n°{i + 1} | {Fishes[i]}\n");
                }
            }
            else
                Result.Append("\t--> No fishes into the aquarium\n");

            return Result.ToString();
        }
    }
}
