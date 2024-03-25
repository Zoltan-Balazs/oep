using System;
using System.IO;

namespace AllEven
{
    class Program
    {
        static void Main()
        {
            using StreamReader reader = new("input.txt");
            bool l = true;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] content = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in content)
                {
                    int e = Int32.Parse(part);
                    if (!(l = e % 2 == 0))
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(l ? "igaz" : "hamis");
        }
    }
}
