using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class CarnivorousFish : Fish
    {
        protected CarnivorousFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        protected CarnivorousFish(string name, Sex sex, int age) : base(name, sex, age)
        {
        }

        public void Eat(Fish fish)
        {
            fish.RemovePV(4);
            this.AddPV(5);
        }
    }
}
