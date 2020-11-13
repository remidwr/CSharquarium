using CSharquarium_v2.Enums;
using System;
using System.Reflection;

namespace CSharquarium_v2.Models.Fishes
{
    public abstract class Fish
    {
        public string Name { get; private set; }
        public Sex Sex { get; protected set; }
        public int PV { get; protected set; } = 10;
        public int Age { get; protected set; }

        protected Fish(string name, Sex sex)
        {
            Name = name;
            Sex = sex;
        }

        protected Fish(string name, Sex sex, int age)
            : this(name, sex)
        {
            Age = age;
        }

        public void AddPV(int pv)
        {
            PV += pv;
        }

        public void RemovePV(int pv)
        {
            PV = PV > pv ? PV - pv : 0;
        }

        public void AddAge(int age)
        {
            Age += age;
        }

        public Fish MakeLove(Type type, string name1, string name2)
        {
            Fish Child = null;

            try
            {
                // Type inconnu qui contient deux attributs
                Type[] Types = new Type[] { typeof(string), typeof(Sex) };
                // appelle le constructeur du type reçu
                ConstructorInfo constructor = type.GetConstructor(Types);
                // composition du nouveau nom du fils/fille
                string ChildName = name1.Substring(0, name1.Length / 2)
                    + name2.Substring(name2.Length / 2);
                // choix aléatoire du sex du fils/fille
                Sex ChildSex = (new Random().Next(2) == 0) ? Sex.Female : Sex.Male;
                // invoque les paramètres d'un nouvel objet
                Child = (Fish)constructor.Invoke(new object[] { ChildName, ChildSex });
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ArgumentException: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return Child;
        }

        public override string ToString()
        {
            return $"Name : {Name} | Type : {GetType().Name} | Sex : {Sex} | PV : {PV} | Age : {Age}";
        }
    }
}
