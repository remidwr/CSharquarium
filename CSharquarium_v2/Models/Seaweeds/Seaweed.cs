namespace CSharquarium_v2.Models.Seaweeds
{
    public class Seaweed
    {
        public int PV { get; private set; } = 10;
        public int Age { get; private set; }

        public Seaweed()
        {
        }

        public Seaweed(int age)
        {
            Age = age;
        }

        public void AddPV(int pv)
        {
            PV += pv;
            if (PV > 10)
                PV = 10;
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

        public override string ToString()
        {
            return $"Name : {GetType().Name} | PV : {PV} | Age : {Age}";
        }
    }
}
