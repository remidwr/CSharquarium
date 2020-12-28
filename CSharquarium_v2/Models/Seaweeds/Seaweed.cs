using System;

namespace CSharquarium_v2.Models.Seaweeds
{
    public class Seaweed
    {
        public int PV { get; private set; }
        public int Age { get; private set; }

        public Seaweed()
        {
            PV = 10;
        }

        public Seaweed(int age) 
            : this()
        {
            Age = age;
        }

        public void AddPV(int pv)
        {
            PV += pv;
        }

        public void RemovePV(int pv)
        {
            PV -= pv;
            if (PV <= 0)
                PV = 0;
        }

        public void AddAge(int age)
        {
            Age += age;
        }

        public Seaweed Repoduction()
        {
            PV /= 2;
            Age /= 2;
            Seaweed MiniSeaweed = new Seaweed(Age);
            MiniSeaweed.PV = PV;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Seaweed splits !");
            return MiniSeaweed;
        }

        public override string ToString()
        {
            return $"Name : {GetType().Name} | PV : {PV} | Age : {Age}";
        }
    }
}
