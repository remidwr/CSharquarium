using CSharquarium_v2.Enums;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class Fish
    {
        public string Name { get; private set; }
        public Sex Sex { get; protected set; }

        public Fish(string name, Sex sex)
        {
            Name = name;
            Sex = sex;
        }
    }
}
