using TextFile;

namespace Purchase
{
    class Product
    {
        // Bármelyik jó megoldás... - getter is!
        public readonly string name;
        public int price { get; }

        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public static bool Read(TextFileReader reader, out Product product)
        {
            bool l = false;
            l = reader.ReadString(out string name);
            l = reader.ReadInt(out int price) && l;
            product = new Product(name, price);
            return l;
        }
    }
}
