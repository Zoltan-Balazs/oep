using System.Globalization;

namespace Complex
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            try
            {
                Complex a = new(-3.0, 2.0);
                Complex b = new(-1.3, 2.5);

                Console.WriteLine($"a = {a}, b = {b}");

                Console.WriteLine($"a + b = {a + b}");
                Console.WriteLine($"a - b = {a - b}");
                Console.WriteLine($"a * b = {a * b}");
                Console.WriteLine($"a / b = {a / b}");
            }
            catch (Complex.NullDivision)
            {
                Console.WriteLine("Nullával való osztás");
            }
        }
    }
}