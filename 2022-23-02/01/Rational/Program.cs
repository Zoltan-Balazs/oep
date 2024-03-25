using System;

namespace Rational
{
    class Program
    {
        static void Main()
        {
            try
            {
                Rational a = new(-3, 2);
                Rational b = new(-1, 2);

                Console.WriteLine($"a = {a}, b = {b}");

                Console.WriteLine("a + b = {0}", a + b);
                Console.WriteLine("a - b = {0}", a - b);
                Console.WriteLine("a * b = {0}", a * b);
                Console.WriteLine("a / b = {0}", a / b);
            }
            catch (Rational.NullDenominator)
            {
                Console.WriteLine("Érvénytelen szám");
            }
            catch (Rational.NullDivision)
            {
                Console.WriteLine("Nullával való osztás");
            }
        }
    }
}
