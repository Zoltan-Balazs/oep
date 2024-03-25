using System.Collections.Generic;

namespace FishingContest
{
    public record Fisher
    {
        public record Catch
        {
            public string time, species;
            public double weight, length;

            public Catch(string time, string species, double weight, double length)
            {
                this.time = time;
                this.species = species;
                this.weight = weight;
                this.length = length;
            }
        }

        public string name;
        public List<Catch> catches = new List<Catch>(); // nem kell..
        public double Sum;

        public Fisher(string name)
        {
            this.name = name;
            catches = new List<Catch>();
            Sum = 0.0;
        }

        public void Add(Catch caught)
        {
            catches.Add(caught); // Nem kell...
            if (caught.species == "ponty" && caught.length >= 0.5)
            {
                Sum += caught.weight;
            }
        }
    }
}
