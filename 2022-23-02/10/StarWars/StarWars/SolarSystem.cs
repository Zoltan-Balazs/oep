using System.Collections.Generic;
using System.Xml.Linq;
using TextFile;

namespace StarWars
{
    class SolarSystem
    {
        public readonly List<Planet> planets;
        
        public SolarSystem(string fname) 
        {
            TextFileReader reader = new(fname);
            planets = new List<Planet>(); 
            while(reader.ReadString(out string name))
            {
                planets.Add(new Planet(name));
            }
        }

        public Planet SearchPlanetbyName(string name) 
        {
            foreach(Planet planet in planets) 
            {
                if(string.Equals(planet.name, name)) return planet;
            }
            return null;
        }

        public bool MaxFireShip(out StarShip bestship)
        {
            bool l = false;
            double max = 0.0;
            bestship = null; ;
            foreach (Planet planet in planets)
            {
                bool ll = planet.MaxFirePower(out double power, out StarShip ship);
                if (!ll) continue;
                if (!l) { l = true; max = power; bestship = ship; }
                else
                {
                    if (max < power) { max = power; bestship = ship; }
                }
            }
            return l;
        }

        public Planet Defenseless()
        {
            foreach (Planet e in planets)
            {
                if (0 == e.NumberOfShips()) return e;
            }
            return null;
        }

    }
}
