using CSharquarium_v2.Enums;
using CSharquarium_v2.Interfaces;

namespace CSharquarium_v2.Models.Fishes.Carnivorous
{
    public class ClownFish : CarnivorousFish, IOpportunistic
    {
        public ClownFish(string name, Sex sex)
            : base(name, sex)
        {
        }

        public ClownFish(string name, Sex sex, int age)
            : base(name, sex, age)
        {
        }

        public void ChangeSex()
        {
            Sex = Sex.Equals(Sex.Male) ? Sex.Female : Sex.Male;
        }
    }
}
