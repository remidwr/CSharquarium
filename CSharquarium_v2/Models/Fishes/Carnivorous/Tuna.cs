using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes.Carnivorous
{
    public class Tuna : CarnivorousFish
    {
        public Tuna(string name, Sex sex)
            : base(name, sex)
        {
        }

        public Tuna(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }
    }
}
