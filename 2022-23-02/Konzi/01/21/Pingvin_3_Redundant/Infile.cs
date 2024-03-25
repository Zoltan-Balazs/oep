using System;
using TextFile;

namespace Pingvin_3
{
    public class Penguin
    {
        public string type;
        public string origin;
        public int num;

        public Penguin(string type = "", string origin = "", int num = 0)
        {
            this.type = type;
            this.origin = origin;
            this.num = num;
        }
    }

    public class Observation
    {
        public string date;
        public int estimate;
        public List<Penguin> penguins;

        public Observation(string date, int estimate, List<Penguin> penguins)
        {
            this.date = date;
            this.estimate = estimate;
            this.penguins = penguins;
        }
    }

    public class Infile
    {
        private TextFileReader reader;

        public Infile(string filename)
        {
            reader = new TextFileReader(filename);
        }

        public bool ReadObservation(out Observation e)
        {
            e = new Observation("", 0, new List<Penguin>());
            bool l = reader.ReadLine(out string line);
            if (l)
            {
                char[] seperators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                string date = tokens[0];
                int estimate = int.Parse(tokens[1]);

                List<Penguin> penguins = new List<Penguin>();
                for (int i = 2; i < tokens.Length; i += 3)
                {
                    Penguin penguin = new Penguin(
                        tokens[i],
                        tokens[i + 1],
                        int.Parse(tokens[i + 2])
                    );
                    penguins.Add(penguin);
                }

                e = new Observation(date, estimate, penguins);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
