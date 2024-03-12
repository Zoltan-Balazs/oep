using System;
using TextFile;
using System.IO;

namespace Cactus
{
    class Program
    {
        struct Cactus
        {
            public string name;
            public string country;
            public string color;
            public int height;
        }
        static void Main()
        {
            TextFileReader reader = new ("inp.txt");
            using StreamWriter writer1 = new (@"..\..\..\out1.txt");
            using StreamWriter writer2 = new (@"..\..\..\out2.txt");

            while (ReadCactus(ref reader, out Cactus cactus))
            {
                if ("piros" == cactus.color) writer1.WriteLine(cactus.name);
                if ("mexico" == cactus.country) writer2.WriteLine(cactus.name);
            }
        }

        static bool ReadCactus(ref TextFileReader reader, out Cactus cactus)
        {
            bool l = reader.ReadString(out cactus.name);
            reader.ReadString(out cactus.country);
            reader.ReadString(out cactus.color);
            reader.ReadInt(out cactus.height);
            return l;
        }
    }
}
