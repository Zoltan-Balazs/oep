namespace Pingvin_3
{
    internal class Program
    {
        public static int Sum(List<Penguin> penguins)
        {
            int sum = 0;
            foreach (Penguin penguin in penguins)
            {
                sum += penguin.num;
            }
            return sum;
        }

        static void Main()
        {
            try
            {
                Infile x = new Infile("inp.txt");
                bool l = true;
                int max = 0;

                while (x.ReadObservation(out Observation e))
                {
                    l = l && (e.estimate > Sum(e.penguins));
                    int diff = Math.Abs(Sum(e.penguins) - e.estimate);

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
