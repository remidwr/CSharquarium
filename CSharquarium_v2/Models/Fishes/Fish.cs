using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class Fish
    {
        public string Name { get; private set; }
        public Sex Sex { get; protected set; }
        public int PV { get; protected set; } = 10;

        public Fish(string name, Sex sex)
        {
            Name = name;
            Sex = sex;
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
            return $"Name : {Name} | Type : {GetType().Name} | Sex : {Sex} | PV : {PV}";
        }
    }
}
