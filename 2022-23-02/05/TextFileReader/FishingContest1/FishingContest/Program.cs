using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace FishingContest
{
    public class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            try
            {
                Fisher fisher = Search(new Infile("input.txt"));
                if (fisher != null)
                    Console.WriteLine($"Sok pontyot fogott: {fisher.Name}");
                else
                    Console.WriteLine("Nincs olyan horgász, aki sok pontyot fogott volna.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }

        public static Fisher Search(Infile f)
        {
            while (f.ReadFisher(out Fisher fisher))
            {
                if (fisher.Sum >= 10.0)
                    return fisher;
            }
            return null;
        }
    }
}
