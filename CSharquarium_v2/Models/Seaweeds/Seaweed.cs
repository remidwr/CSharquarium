namespace CSharquarium_v2.Models.Seaweeds
{
    public class Seaweed
    {
        public int PV { get; private set; } = 10;

        public Seaweed()
        {
        }

        public void AddPV(int pv)
        {
            PV += pv;
        }

        public void RemovePV(int pv)
        {
            PV = PV > pv ? PV - pv : 0;
        }

        public override string ToString()
        {
            return $"Name : {GetType().Name} | PV : {PV}";
        }
    }
}
