using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes.Carnivorous
{
    public class Grouper : CarnivorousFish
    {
        public Grouper(string name, Sex sex)
            : base(name, sex)
        {
        }

        public Grouper(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }

        public override void AddAge(int age)
        {
            base.AddAge(age);
            if (Age >= 10)
                Sex = Sex.Equals(Sex.Male) ? Sex.Female : Sex.Male;
        }
    }
}
