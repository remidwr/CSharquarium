using CSharquarium_v2.Enums;
using CSharquarium_v2.Models.Seaweeds;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class HerbivorousFish : Fish
    {
        protected HerbivorousFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        protected HerbivorousFish(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }

        public void Eat(Seaweed seaweed)
        {
            seaweed.RemovePV(3);
            this.AddPV(2);
        }
    }
}
