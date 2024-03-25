namespace LunaPark
{
    abstract class Ajándék
    {
        public Céllövölde Céllövölde { get; set; }
        public IMéret Méret { get; }

        public Ajándék(IMéret m)
        {
            Méret = m;
        }

        public virtual int Érték()
        {
            return Pont() * Méret.Szorzó();
        }

        public abstract int Pont();
    }

    class Plüss : Ajándék
    {
        public Plüss(IMéret m)
            : base(m) { }

        public override int Pont()
        {
            return 3;
        }
    }

    class Figura : Ajándék
    {
        public Figura(IMéret m)
            : base(m) { }

        public override int Pont()
        {
            return 2;
        }
    }

    class Labda : Ajándék
    {
        public Labda(IMéret m)
            : base(m) { }

        public override int Pont()
        {
            return 1;
        }
    }
}
