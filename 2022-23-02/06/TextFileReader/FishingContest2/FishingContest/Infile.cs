using System;
using System.Collections.Generic;
using TextFile;

namespace FishingContest
{
    public class Fisher
    {
        public Fisher(string n, bool o)
        {
            Name = n;
            OK = o;
        }

        public readonly string Name;
        public readonly bool OK;
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

                fisher = new Fisher(tokens[0], OK(tokens));
                return true;
            }
            else
                return false;
        }

        public static bool OK(string[] tokens)
        {
            int i;
            for (
                i = 1;
                i < tokens.Length
                    && !(tokens[i + 1] == "ponty" && double.Parse(tokens[i + 3]) >= 1.0);
                i += 4
            ) { }
            int db = 0;
            for (; i < tokens.Length; i += 4)
            {
                if (tokens[i + 1] == "harcsa" && double.Parse(tokens[i + 2]) >= 1.0)
                    ++db;
            }
            return db >= 4;
        }
    }
}
