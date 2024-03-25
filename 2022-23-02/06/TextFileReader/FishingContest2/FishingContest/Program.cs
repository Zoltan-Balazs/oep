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
                Console.WriteLine("Ügyes horgászok:");
                foreach (string e in Collect(new Infile("input2.txt")))
                {
                    Console.WriteLine(e);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }

        public static List<string> Collect(Infile f)
        {
            List<string> names = new List<string>();
            while (f.ReadFisher(out Fisher fisher))
            {
                if (fisher.OK)
                    names.Add(fisher.Name);
            }
            return names;
        }
    }
}
