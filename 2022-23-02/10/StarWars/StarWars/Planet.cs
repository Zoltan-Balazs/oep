using System.Collections.Generic;
using System.Numerics;

namespace StarWars
{
    class Planet
    {
        public readonly string name;
        private readonly List<StarShip> ships;

        public int NumberOfShips()
        {
            return ships.Count;
        }

        public Planet(string name) { this.name = name; ships = new List<StarShip>(); }

        public void ProtectedBy(StarShip ship)
        {
            if (!ships.Contains(ship)) ships.Add(ship);
        }

        public void LeftBy(StarShip ship)
        {
            if (ships.Contains(ship)) ships.Remove(ship);
        }
        public int TotalShield()
        {
            int s = 0;
            foreach (StarShip e in ships) s += e.GetShield(this);
            return s;
        }
        public bool MaxFirePower(out double max, out StarShip bestship)
        {
            bool l = false;
            max = 0.0;
            bestship = null; ;
            foreach (StarShip ship in ships)
            {
                double power = ship.Firepower();
                if (!l) { l = true; max = power; bestship = ship; }
                else
                {
                    if (max < power) { max = power; bestship = ship; }
                }
            }
            return l;
        }

    }
}
