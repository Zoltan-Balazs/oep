using System;
using TextFile;

namespace AllEven
{
    class Program
    {
        static void Main()
        {
            TextFileReader reader = new("input.txt");
            bool l = true;
            while (reader.ReadInt(out int e))
            {
                if (!(l = e % 2 == 0))
                    break;
            }
            Console.WriteLine(l ? "igaz" : "hamis");
        }
    }
}
