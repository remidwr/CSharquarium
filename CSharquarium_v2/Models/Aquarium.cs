using CSharquarium_v2.Models.Fishes;
using CSharquarium_v2.Models.Seaweeds;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string Action()
        {
            StringBuilder actions = new StringBuilder("");
            UpdateStatus();
            actions.Append(Eating());
            actions.Append(Clean(Fishes));
            return actions.ToString();
        }

        private string Eating()
        {
            StringBuilder actions = new StringBuilder("");

            List<Fish> FishesTemp = Fishes;

            for (int i = 0; i < Fishes.Count; i++)
            {
                Fish CurrentFish = FishesTemp[i];
                Random Rng = new Random();
                Fish RandomFish = FishesTemp[Rng.Next(FishesTemp.Count)];

                if (CurrentFish.PV <= 5)
                {
                    if (CurrentFish is CarnivorousFish)
                    {
                        while (CurrentFish == RandomFish || CurrentFish.GetType() == RandomFish.GetType())
                        {
                            RandomFish = FishesTemp[Rng.Next(FishesTemp.Count)];
                        }

                        ((CarnivorousFish)CurrentFish).Eat(RandomFish);
                        actions.Append($"{CurrentFish.Name} ate {RandomFish.Name} !\n");
                    }
                    else if (Seaweeds.Count > 0)
                    {
                        Seaweed seaweed = Seaweeds[Rng.Next(Seaweeds.Count)];
                        ((HerbivorousFish)CurrentFish).Eat(seaweed);
                        actions.Append($"{CurrentFish.Name} ate seaweed !\n");
                    }
                }
            }

            Fishes = FishesTemp;
            return actions.ToString();
        }

        public string Clean(List<Fish> fishes)
        {
            List<Fish> FishesTemp = fishes;
            List<Seaweed> SeaweedsTemp = Seaweeds;

            StringBuilder cleaning = new StringBuilder("");
            for (int i = 0; i < FishesTemp.Count; i++)
            {
                Fish fish = FishesTemp[i];
                if (fish.PV == 0)
                {
                    cleaning.Append($"{fish.Name} is dead !\n");
                    fishes.Remove(fish);
                }
            }
            for (int i = 0; i < SeaweedsTemp.Count; i++)
            {
                Seaweed seaweed = Seaweeds[i];
                if (seaweed.PV == 0)
                {
                    cleaning.Append("A seaweed is dead !\n");
                    Seaweeds.Remove(seaweed);
                }
            }

            return cleaning.ToString();
        }

        public void UpdateStatus()
        {
            for (int i = 0; i < Fishes.Count; i++)
            {
                Fishes[i].RemovePV(1);
            }
            for (int i = 0; i < Seaweeds.Count; i++)
            {
                Seaweeds[i].AddPV(1);
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
