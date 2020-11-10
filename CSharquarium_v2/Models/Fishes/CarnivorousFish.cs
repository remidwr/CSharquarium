using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class CarnivorousFish : Fish
    {
        protected CarnivorousFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        public void Eat(Fish fish)
        {

        }
    }
}
