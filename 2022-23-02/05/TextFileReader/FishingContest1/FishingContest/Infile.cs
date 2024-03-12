using System;
using TextFile;

namespace FishingContest
{
    public class Fisher
    {
        public Fisher(string n, double s)
        {
            Name = n;
            Sum = s;
        }
        public readonly string Name;
        public readonly double Sum;
}
    public class Infile
    {
        readonly TextFileReader reader;
        public Infile(string fname)
        {
            reader = new TextFileReader(fname);
        }
        public bool ReadFisher(out Fisher fisher)
        {
            fisher = null;
            if (reader.ReadLine(out string line))
            {
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                fisher = new Fisher(tokens[0], Sum(tokens));
                return true;
            }
            else return false;
        }

        public static double Sum(string[] tokens)
        {
            double s = 0.0;
            for (int i = 1; i < tokens.Length; i += 4)
            {
                if (tokens[i + 1] == "ponty" && double.Parse(tokens[i + 2]) >= 0.5) s += double.Parse(tokens[i + 3]);
            }
            return s;
        }
    }
}
