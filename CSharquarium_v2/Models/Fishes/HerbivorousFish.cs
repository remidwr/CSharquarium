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

        public void Eat(Seaweed seaweed)
        {
            AddPV(3);
            seaweed.RemovePV(2);
        }
    }
}
