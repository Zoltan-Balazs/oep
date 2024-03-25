using System;
using TextFile;

namespace Invoice2
{
    class Program
    {
        static void Main()
        {
            try
            {
                Infile f = new("input.txt");

                int income = 0;
                while (f.ReadTotal(out int total))
                {
                    income += total;
                }
                Console.WriteLine("Total income: {0}", income);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }
    }
}
