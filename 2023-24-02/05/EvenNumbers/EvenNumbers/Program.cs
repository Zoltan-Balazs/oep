using TextFile;

namespace EvenNumbers
{
    public class Program
    {
        static void Main()
        {
            Counting("input.txt", out int countBegin, out int countEnd);

            Console.WriteLine($"Number of even numbers before the first negativ: {countBegin}");
            Console.WriteLine($"Number of even numbers after the first negativ: {countEnd}");
        }

        public static void Counting(string fileName, out int countBegin, out int countEnd)
        {
        }
    }
}
