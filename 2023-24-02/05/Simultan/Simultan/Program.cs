//Author:   Gregorics Tibor
//Date:     2024.02.15.
//Title:    Decision and maximum selecting simultaneously

using TextFile;

namespace Simultan
{
    public class Program
    {
        public class EmptyFileException : Exception { }
        public static void Main()
        {
            try
            {
                Computing("input.txt", out bool all_even, out int greatest);
                if (all_even) Console.WriteLine("All numbers are even");
                else Console.WriteLine("There are odd numbers");
                Console.WriteLine($"The greatest number: {greatest}");
            }
            catch (EmptyFileException)
            {
                Console.WriteLine($"There is no greatest element in an empty file.");
            }
        }

        public static void Computing(string fname, out bool all_even, out int greatest)
        {
        }
    }
}
