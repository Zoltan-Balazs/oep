using TextFile;

namespace CactusAssortment
{
    public class Infile
    {
        public record Cactus
        {
            public string name, color, descendant;
            public int size;
        }

        public Cactus Current { get; }

        private readonly TextFileReader reader;

        public Infile(string fileName)
        {
            reader = new TextFileReader(fileName);
            Current = new Cactus();
        }

        public bool Read()
        {
            reader.ReadString(out Current.name);
            reader.ReadString(out Current.color);
            reader.ReadString(out Current.descendant);
            return reader.ReadInt(out Current.size);
        }
    }
}
