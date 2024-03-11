//Author:   Gregorics Tibor
//Date:     2024.02.15.
//Title:    Even numbers

using TextFile;

namespace EvenNumbers
{
    public class Program
    {
        static void Main()
        {
            Counting("input.txt", out int countbegin, out int countend);

            Console.WriteLine($"Number of even numbers before the first negativ: {countbegin}");
            Console.WriteLine($"Number of even numbers after the first negativ: {countend}");
        }

        public static void Counting(string fname, out int countbegin, out int countend)
        {
        }
    }
}
