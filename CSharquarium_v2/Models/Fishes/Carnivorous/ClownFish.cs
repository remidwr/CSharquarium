using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes.Carnivorous
{
    public class ClownFish : CarnivorousFish
    {
        public ClownFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        public ClownFish(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }
    }
}
