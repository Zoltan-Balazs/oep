using System;
using System.Globalization;
using System.Threading;

namespace FishingContest
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            try
            {
                InFile f = new("input.txt");
                Fisher fisher = Search(f);
                if (fisher != null)
                    Console.WriteLine(
                        $"{fisher.name} a legalább fél méteres pontyokból több, mint 10 kiló fogott."
                    );
                else
                    Console.WriteLine(
                        "Senki sem fogott a legalább fél méteres pontyokból több, mint 10 kilót."
                    );
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Nem találom az inputfájlt.");
            }
        }

        public static Fisher Search(InFile f)
        {
            Fisher fisher;
            while (f.Read(out fisher))
            {
                if (fisher.Sum >= 10.0)
                    break;
            }
            return fisher;
        }
    }
}
