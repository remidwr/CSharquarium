using CSharquarium_v2.Models.Fishes;
using CSharquarium_v2.Models.Seaweeds;
using System;
using System.Collections.Generic;

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

        private void DisplayFishes()
        {
            Console.WriteLine("Fishes into the aquarium : ");
            foreach (Fish fish in Fishes)
            {
                Console.WriteLine($"{fish.Name} - {fish.Sex}");
            }
        }

        private void DisplaySeaweed()
        {
            Console.WriteLine("Seaweed into the aquarium : ");
            foreach (Seaweed seaweed in Seaweeds)
            {
                Console.WriteLine(seaweed.ToString());
            }
        }

        private void Display()
        {
            DisplaySeaweed();
            Console.WriteLine();
            DisplayFishes();
        }

        private void Manger()
        {
            for (int i = 0; i < Fishes.Count; i++)
            {
                List<Fish> FishesTemp = Fishes;

                Fish CurrentFish = FishesTemp[i];
                Random Rng = new Random();
                Fish RandomFish = FishesTemp[Rng.Next(FishesTemp.Count)];

                if (CurrentFish is CarnivorousFish)
                {
                    while (CurrentFish == RandomFish)
                    {
                        RandomFish = FishesTemp[Rng.Next(FishesTemp.Count)];
                    }

                    if (FishesTemp.Contains(RandomFish))
                    {
                        FishesTemp.Remove(RandomFish);
                        //((CarnivorousFish)CurrentFish).Eat(RandomFish);
                        Console.WriteLine($"{CurrentFish.Name} ate {RandomFish.Name}.");
                    }
                }
                else if (Seaweeds.Count > 0)
                {
                    Seaweed seaweed = Seaweeds[Rng.Next(Seaweeds.Count)];
                    Seaweeds.Remove(seaweed);
                    //((HerbivorousFish)CurrentFish).Eat(seaweed);
                    Console.WriteLine($"{CurrentFish.Name} ate {seaweed.ToString()}");
                }
            }
        }

        public void SpendTime()
        {
            string Continue;
            int Day = 1;

            do
            {
                Console.WriteLine($"Day {Day} : \n");

                Display();
                Console.WriteLine();
                Manger();

                Console.WriteLine();
                Console.Write("Press ENTER to make a new round or press 'Q' to stop : ");
                Continue = Console.ReadLine().ToUpper();
                Console.WriteLine();

                Day++;
            } while (Continue != "Q" && Fishes.Count > 1);

            if (Fishes.Count == 1)
            {
                Console.WriteLine("Only one survivor left !");
            }
        }
    }
}
