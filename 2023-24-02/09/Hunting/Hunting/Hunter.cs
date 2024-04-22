using System;
using System.Collections.Generic;
using TextFile;

namespace Hunting
{
    class Hunter
    {
        public readonly string name;
        public readonly int age;
        public readonly List<Trophy> trophies = new();

        public Hunter(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Shot(Animal animal, string place, string date)
        {
            trophies.Add(new Trophy(animal, place, date));
        }

        public int CountMaleLions()
        {
            int c = 0;
            foreach (Trophy e in trophies)
            {
                if (e.animal.IsLion() && e.animal.gender == Animal.Gender.male)
                    ++c;
            }
            return c;
        }

        public bool MaxHornWeigthRate(out double rate)
        {
            bool l = false;
            rate = 0.0;
            foreach (Trophy e in trophies)
            {
                if (!e.animal.IsRhino())
                    continue;
                // Rhino rhino = (Rhino)e.animal;
                Rhino rhino = e.animal as Rhino;
                double r = (double)rhino.Horn / rhino.weight;
                if (!l)
                {
                    l = true;
                    rate = r;
                }
                else if (rate < r)
                {
                    rate = r;
                }
            }
            return l;
        }

        public bool SearchEqualTusks()
        {
            foreach (Trophy e in trophies)
            {
                // if (e.animal.IsElephant() && ((Elephant)e.animal).Lefttusk==((Elephant)e.animal).Righttusk) return true;
                if ((e.animal is Elephant elephant) && elephant.Lefttusk == elephant.Righttusk)
                    return true;
            }
            return false;
        }

        public void Read(string fname)
        {
            TextFileReader reader = new(fname);

            Animal animal = null;

            char[] separators = new char[] { ' ', '\t' };
            while (reader.ReadLine(out string line))
            {
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string place = tokens[0];
                string date = tokens[1];
                string species = tokens[2];
                int weight = int.Parse(tokens[3]);
                Animal.Gender gender = (Animal.Gender)Enum.Parse(typeof(Animal.Gender), tokens[4]);
                /*
                if (tokens[4] == "male") gender = Animal.Gender.male;
                else gender = Animal.Gender.female;
                */
                switch (species)
                {
                    case "lion":
                        animal = new Lion(weight, gender);
                        break;
                    case "rhino":
                        int horn = int.Parse(tokens[5]);
                        animal = new Rhino(weight, horn, gender);
                        break;
                    case "elephant":
                        int lefttusk = int.Parse(tokens[5]);
                        int righttusk = int.Parse(tokens[6]);
                        animal = new Elephant(weight, lefttusk, righttusk, gender);
                        break;
                }

                Shot(animal, place, date);
            }
        }
    }
}
