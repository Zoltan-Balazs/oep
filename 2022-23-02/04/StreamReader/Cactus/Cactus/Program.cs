using System;
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
            using StreamReader reader = new ("inp.txt");
            using StreamWriter writer1 = new (@"..\..\..\out1.txt");
            using StreamWriter writer2 = new (@"..\..\..\out2.txt");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ParseLine(line, out Cactus cactus);
                if ("piros" == cactus.color) writer1.WriteLine(cactus.name);
                if ("mexico" == cactus.country) writer2.WriteLine(cactus.name);
            }
        }

        static void ParseLine(string line, out Cactus cactus)
        {
            string[] content = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            cactus.name = content[0];
            cactus.country = content[1];
            cactus.color = content[2];
            cactus.height = Int32.Parse(content[3]);
        }
    }
}
