using CSharquarium_v2.Models.Fishes;
using CSharquarium_v2.Models.Seaweeds;
using System;
using System.Collections.Generic;

namespace CSharquarium_v2.Models
{
    public class Aquarium
    {
        public List<Fish> Fishes { get; private set; } = new List<Fish>();
        public List<Seaweed> Seaweeds { get; private set; } = new List<Seaweed>();

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
            DinerTime();
            ToClean();
        }

        private void DinerTime()
        {
            if (Fishes.Count > 1)
            {
                for (int i = 0; i < Fishes.Count; i++)
                {
                    Fish CurrentFish = Fishes[i];

                    if (CurrentFish.PV > 0 && CurrentFish.PV <= 5)
                    {
                        if (CurrentFish is CarnivorousFish)
                        {
                            ((CarnivorousFish)CurrentFish).Eat(this);
                        }
                        else if (Seaweeds.Count > 0)
                        {
                            ((HerbivorousFish)CurrentFish).Eat(this);
                        }
                    }
                }
            }
        }

        private void ToClean()
        {
            for (int i = Fishes.Count - 1; i >= 0; i--)
            {
                Fish fish = Fishes[i];
                if (fish.PV == 0 || fish.Age > 20)
                {
                    Console.WriteLine($"{fish.Name} is dead !");
                    Fishes.Remove(fish);
                }
            }

            for (int i = Seaweeds.Count - 1; i >= 0; i--)
            {
                Seaweed seaweed = Seaweeds[i];
                if (seaweed.PV == 0 || seaweed.Age > 20)
                {
                    Console.WriteLine("A seaweed is dead !");
                    Seaweeds.Remove(seaweed);
                }
            }
        }

        private void UpdateStatus()
        {
            for (int i = 0; i < Fishes.Count; i++)
            {
                Fishes[i].RemovePV(1);
                Fishes[i].AddAge(1);
            }
            for (int i = 0; i < Seaweeds.Count; i++)
            {
                Seaweeds[i].AddPV(1);
                Seaweeds[i].AddAge(1);
            }
        }

        public override string ToString()
        {
            string Result = "";

            Result += "Seaweed :\n";
            if (Seaweeds.Count > 0)
            {
                Result += $"\t--> {Seaweeds.Count} seaweed(s)\n";
                for (int i = 0; i < Seaweeds.Count; i++)
                {
                    Result += $"\t\t- Seaweed n°{i + 1} | {Seaweeds[i].ToString()}\n";
                }
            }
            else
                Result += "\t--> No seaweeds into the aquarium\n";

            Result += "Fishes :\n";
            if (Fishes.Count > 0)
            {
                Result += $"\t--> {Fishes.Count} fishe(s)\n";
                for (int i = 0; i < Fishes.Count; i++)
                {
                    Result += $"\t\t- Fish n°{i + 1} | {Fishes[i].ToString()}\n";
                }
            }
            else
                Result += "\t--> No fishes into the aquarium\n";

            return Result;
        }
    }
}
