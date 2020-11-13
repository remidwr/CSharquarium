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
            if (Age >= 10)
                Sex = Sex.Equals(Sex.Male) ? Sex.Female : Sex.Male;
        }

        public override void AddAge(int age)
        {
            base.AddAge(age);
            if (Age >= 10)
                Sex = Sex.Equals(Sex.Male) ? Sex.Female : Sex.Male;
        }
    }
}
