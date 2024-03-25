using TextFile;

namespace Purchase
{
    class Department
    {
        public List<Product> stock = new List<Product>();

        public Department(string fileName)
        {
            TextFileReader reader = new TextFileReader(fileName);
            while (Product.Read(reader, out Product product))
            {
                stock.Add(product);
            }
        }
    }
}
