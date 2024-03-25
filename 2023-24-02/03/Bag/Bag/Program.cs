using TextFile;

namespace Bag
{
    class Program
    {
        static void Main()
        {
            try
            {
                TextFileReader reader = new("input.txt");

                Bag bag = new();

                while (reader.ReadString(out string elem))
                {
                    bag.Insert(elem);
                }

                Console.WriteLine($"The most frequent element: {bag.Max()}");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }
    }
}
