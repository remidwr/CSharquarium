using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class Fish
    {
        public string Name { get; private set; }
        public Sex Sex { get; protected set; }
        public int PV { get; protected set; } = 10;
        public int Age { get; protected set; }

        protected Fish(string name, Sex sex)
        {
            Name = name;
            Sex = sex;
        }

        protected Fish(string name, Sex sex, int age)
            : this(name, sex)
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
            PV = PV > pv ? PV - pv : 0;
        }

        public void AddAge(int age)
        {
            Age += age;
        }

        public override string ToString()
        {
            return $"Name : {Name} | Type : {GetType().Name} | Sex : {Sex} | PV : {PV} | Age : {Age}";
        }
    }
}
