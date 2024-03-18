//Author:   Gregorics Tibor
//Date:     2024.02.15.
//Title:    Cactus

using TextFile;

namespace CactusAssortment
{
    public class Infile
    {
        public record Cactus
        {
        }

        public Cactus Current { get; private set; }

        private readonly TextFileReader reader;

        public Infile(string fname)
        {
        }

        public bool Read()
        {
        }
    }
}
