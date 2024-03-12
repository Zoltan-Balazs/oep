using TextFile;

namespace Purchase
{
    class Product
    {
        public readonly string name;
        public readonly int price;
        public Product(string name, int price)
        {
            this.name = name; this.price = price;
        }

        static public bool Read(TextFileReader reader, out Product product)
        {
            bool l;
            _ = reader.ReadString(out string name);
            l = reader.ReadInt(out int price);
            product = new Product(name, price);
            return l;
        }
    }
}
