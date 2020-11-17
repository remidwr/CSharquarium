using CSharquarium_v2.Enums;
using CSharquarium_v2.Interfaces;

namespace CSharquarium_v2.Models.Fishes.Herbivorous
{
    public class Sole : HerbivorousFish, IOpportunistic
    {
        public Sole(string name, Sex sex)
            : base(name, sex)
        {
        }

        public Sole(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }

        public void ChangeSex()
        {
            Sex = Sex.Equals(Sex.Male) ? Sex.Female : Sex.Male;
        }
    }
}
