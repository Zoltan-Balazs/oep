using System;
using TextFile;

namespace FishingContest
{
    public class InFile
    {
        private readonly TextFileReader reader;

        public InFile(string fileName)
        {
            reader = new TextFileReader(fileName);
        }

        public bool Read(out Fisher fisher)
        {
            fisher = null;
            bool l = reader.ReadLine(out string line);
            if (l)
            {
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                fisher = new Fisher(tokens[0]);
                for (int i = 1; i < tokens.Length; i += 4)
                {
                    fisher.Add(
                        new Fisher.Catch(
                            tokens[i],
                            tokens[i + 1],
                            double.Parse(tokens[i + 2]),
                            double.Parse(tokens[i + 3])
                        )
                    );
                }
            }

            return l;
        }
    }
}
