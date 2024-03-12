using System.Collections.Generic;
using TextFile;

namespace Purchase
{
    class Department
    {
        public List<Product> stock = new ();
        public Department(string filename)
        {
            TextFileReader reader = new (filename);
            while(Product.Read(reader, out Product product))
            {
                stock.Add(product);
            }
        }

    }
}
