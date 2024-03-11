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
                Computing("input.txt", out bool allEven, out int greatest);
                if (allEven)
                {
                    Console.WriteLine("All numbers are even");
                }
                else
                {
                    Console.WriteLine("There are odd numbers");
                }
                Console.WriteLine($"The greatest number: {greatest}");
            }
            catch (EmptyFileException)
            {
                Console.WriteLine($"There is no greatest element in an empty file.");
            }
        }

        public static void Computing(string fileName, out bool allEven, out int greatest)
        {
        }
    }
}
