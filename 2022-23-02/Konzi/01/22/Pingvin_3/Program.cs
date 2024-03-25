namespace Pingvin_3
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Infile x = new Infile("inp.txt");
                bool l = true;
                int max = 0;
                while (x.ReadObservation(out Observation e))
                {
                    l = l && (e.estimate > e.sum);
                    int diff = Math.Abs(e.sum - e.estimate);

                    if (diff > max)
                    {
                        max = diff;
                    }
                }
                if (l)
                {
                    Console.WriteLine($"Igaz {max}");
                }
                else
                {
                    Console.WriteLine($"Hamis {max}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A fájl nem létezik!");
            }
        }
    }
}
