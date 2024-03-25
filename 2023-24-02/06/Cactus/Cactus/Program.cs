namespace CactusAssortment
{
    public class Program
    {
        static void Main()
        {
            Assortment("cactus.txt", "red.txt", "mexico.txt");
        }

        public static void Assortment(string cactus, string red, string mexico)
        {
            try
            {
                Infile cactusfile = new(cactus);
                using StreamWriter redfile = File.CreateText(red),
                    mexicofile = File.CreateText(mexico);

                while (cactusfile.Read())
                {
                    Infile.Cactus e = cactusfile.Current;
                    if (e.color == "red")
                        redfile.WriteLine(e.name);
                    if (e.descendant == "Mexico")
                        mexicofile.WriteLine(e.name);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File open error");
            }
        }
    }
}
