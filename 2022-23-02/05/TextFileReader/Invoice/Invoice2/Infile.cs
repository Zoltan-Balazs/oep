using System;
using TextFile;

namespace Invoice2
{
    class Infile
    {
        readonly TextFileReader reader;
        public Infile(string fname)
        {
            reader = new TextFileReader(fname);
        }
        public bool ReadTotal(out int total)
        {
            total = 0; 
            bool l = reader.ReadLine(out string line);
            if (l)
            {
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                
                total = 0;
                for (int i = 2; i < tokens.Length; i += 2)
                {
                    total += int.Parse(tokens[i]);
                }
            }
            return l;
        }
    }
}
