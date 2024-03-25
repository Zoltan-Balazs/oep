namespace Pingvin_5
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Infile x = new Infile("inp.txt");
                int db = 0;
                int min = 0;
                string when = "";
                bool moreThanEstimate = false;

                while (x.ReadObservation(out Observation e))
                {
                    if (moreThanEstimate)
                    {
                        db += e.antarctic;

                        if (when == "" || e.sum < min)
                        {
                            min = e.sum;
                            when = e.date;
                        }
                    }

                    moreThanEstimate = moreThanEstimate || (e.sum > e.estimate);
                }

                Console.WriteLine($"{db} {when} {min}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A fájl nem létezik!");
            }
        }
    }
}
