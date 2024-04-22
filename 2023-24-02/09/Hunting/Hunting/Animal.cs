namespace Hunting
{
    public class Animal
    {
        public enum Gender
        {
            male,
            female
        };

        public readonly int weight;
        public readonly Gender gender;

        public Animal(int weight, Gender gender)
        {
            this.weight = weight;
            this.gender = gender;
        }

        public virtual bool IsLion()
        {
            return false;
        }

        public virtual bool IsRhino()
        {
            return false;
        }

        public virtual bool IsElephant()
        {
            return false;
        }
    }

    class Elephant : Animal
    {
        public int Lefttusk { get; }
        public int Righttusk { get; }

        public Elephant(int weight, int ltusk, int rtusk, Gender gender)
            : base(weight, gender)
        {
            Lefttusk = ltusk;
            Righttusk = rtusk;
        }

        public override bool IsElephant()
        {
            return true;
        }
    }

    class Rhino : Animal
    {
        public int Horn { get; }

        public Rhino(int weight, int horn, Gender gender)
            : base(weight, gender)
        {
            Horn = horn;
        }

        public override bool IsRhino()
        {
            return true;
        }
    }

    class Lion : Animal
    {
        public Lion(int weight, Gender gender)
            : base(weight, gender) { }

        public override bool IsLion()
        {
            return true;
        }
    }
}
