using System;

namespace StarWars
{
    abstract class StarShip
    {
        public class StarShipInServiceException : Exception { }

        public class NotYourBuisnessException : Exception { }

        class StarShipFree : Exception { }

        protected readonly string name;
        protected readonly int shield;
        protected readonly int armor;
        protected int guard;
        protected Planet planet;

        public int GetShield(Planet planet)
        {
            if (planet != this.planet)
                throw new NotYourBuisnessException();
            return shield;
        }

        public StarShip(string name, int shield, int armor, int guard)
        {
            this.name = name;
            this.shield = shield;
            this.armor = armor;
            this.guard = guard;
        }

        public void Protect(Planet planet)
        {
            if (this.planet != null)
                throw new StarShipInServiceException();
            this.planet = planet;
            planet.ProtectedBy(this);
        }

        public void Leave()
        {
            if (this.planet == null)
                throw new StarShipFree();
            this.planet.LeftBy(this);
            this.planet = null;
        }

        public abstract int Firepower();
    }

    class Breaker : StarShip
    {
        public Breaker(string name, int shield, int armor, int guard)
            : base(name, shield, armor, guard) { }

        public override int Firepower()
        {
            return armor / 2;
        }
    }

    class Lander : StarShip
    {
        public Lander(string name, int shield, int armor, int guard)
            : base(name, shield, armor, guard) { }

        public override int Firepower()
        {
            return guard;
        }
    }

    class Laser : StarShip
    {
        public Laser(string name, int shield, int armor, int guard)
            : base(name, shield, armor, guard) { }

        public override int Firepower()
        {
            return shield;
        }
    }
}
