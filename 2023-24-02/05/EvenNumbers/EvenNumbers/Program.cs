using TextFile;

namespace EvenNumbers
{
    public class Program
    {
        static void Main()
        {
            Counting("input.txt", out int countBegin, out int countEnd);

            Console.WriteLine($"Number of even numbers before the first negative: {countBegin}");
            Console.WriteLine($"Number of even numbers after the first negative: {countEnd}");
        }

        public static void Counting(string fileName, out int countBegin, out int countEnd)
        {
            countBegin = 0;
            countEnd = 0;

            try
            {
                TextFileReader textFileReader = new(fileName);

                bool canRead = textFileReader.ReadInt(out int e);
                while (canRead && e >= 0)
                {
                    if (e % 2 == 0)
                    {
                        countBegin++;
                    }
                    canRead = textFileReader.ReadInt(out e);
                }

                // canRead = textFileReader.ReadInt(out e); - Ha az első negativ számot nem akarjuk belevenni

                while (canRead)
                {
                    if (e % 2 == 0)
                    {
                        countEnd++;
                    }

                    canRead = textFileReader.ReadInt(out e);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Specified file is not found: {fileName}");
            }
        }
    }
}
