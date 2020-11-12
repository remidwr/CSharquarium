using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes.Herbivorous
{
    public class Bar : HerbivorousFish
    {
        public Bar(string name, Sex sex)
            : base(name, sex)
        {
        }

        public Bar(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }
    }
}
