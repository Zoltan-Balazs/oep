using System;
using System.Globalization;
using System.Threading;

namespace Hunting
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            try
            {
                Hunter hunter = new("Zsolti", 63);
                hunter.Read("input.txt");

                Console.WriteLine($"Number of the male lions: {hunter.CountMaleLions()}");

                if (hunter.MaxHornWeightRate(out double rate))
                {
                    Console.WriteLine($"The most horn-weight rate among the rhinos: {rate:f3}");
                }
                else
                {
                    Console.WriteLine("There are no rhinos");
                }

                if (hunter.SearchEqualTusks())
                {
                    Console.WriteLine("There exists an elephant with same length tusks.");
                }
                else
                {
                    Console.WriteLine("There is no elephant with same length tusks.");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Wrong file name");
            }
        }
    }
}
