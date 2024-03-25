namespace Pingvin_5
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Infile x = new Infile("inp.txt");
                bool moreThanEstimate = false;
                string minDate = "";
                int min = 0;
                int antarctic = 0;
                while (x.ReadObservation(out Observation e))
                {
                    if (moreThanEstimate)
                    {
                        antarctic += e.antarctic;

                        if (minDate == "" || e.sum < min)
                        {
                            min = e.sum;
                            minDate = e.date;
                        }
                    }

                    moreThanEstimate = moreThanEstimate || (e.sum > e.estimate);
                }
                Console.WriteLine($"{antarctic} {minDate} {min}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A fájl nem létezik");
            }
        }
    }
}
