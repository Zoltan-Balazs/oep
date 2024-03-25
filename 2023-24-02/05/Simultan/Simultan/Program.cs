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
            allEven = true;
            greatest = 0;

            try
            {
                TextFileReader textFileReader = new(fileName);

                bool canRead = textFileReader.ReadInt(out int e);

                if (!canRead)
                {
                    throw new EmptyFileException();
                }

                while (canRead)
                {
                    if (e > greatest)
                    {
                        greatest = e;
                    }

                    // greatest = Math.Max(greatest, e);

                    allEven = allEven && (e % 2 == 0);
                    canRead = textFileReader.ReadInt(out e);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Unable to find file: {fileName}");
            }
        }
    }
}
