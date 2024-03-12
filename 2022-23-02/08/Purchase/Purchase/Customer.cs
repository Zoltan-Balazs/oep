using System;
using System.Collections.Generic;
using TextFile;

namespace Purchase
{
    class Customer
    {
        public readonly string name;
        private readonly List<string> list = new();
        public List<Product> cart = new();

        public Customer(string filename)
        {
            TextFileReader reader = new (filename);
            reader.ReadString(out string str);
            name = str;
            while (reader.ReadString(out str))
            {
                list.Add(str);
            }
        }

        
        public void Purchase(Store store)
        {
            Console.WriteLine($"{name} vásárló megvette az alábbi árukat: ");

            foreach (string productName in list)
            {
                if (LinSearch(productName, store.foods, out Product? product))
                {
                    product = null;
                    Drag(product!, ref store.foods);
                    Console.WriteLine($"{product!.name} {product.price}");
                }
                else
                {
                    Console.WriteLine($"{productName} nem volt a boltban");
                }
            }
            foreach (string productName in list)
            {
                if (MinSearch(productName, store.technical, out Product? product))
                {
                    Drag(product!, ref store.technical);
                    Console.WriteLine($"{product!.name} {product.price}");
                }
                else
                {
                    Console.WriteLine($"{productName} nem volt a boltban");
                }
            }
        }

        private void Drag(Product product, ref Department department)
        {
            department.stock.Remove(product!); 
            cart.Add(product!);
        }

        private static bool LinSearch(string name, Department d, out Product? product)
        {
            bool l = false;
            product = null;
            foreach (Product p in d.stock)
            {
                if ((l = (p.name == name)))
                {
                    product = p; break;
                }
            }
            return l;
        }

        private static bool MinSearch(string name, Department d, out Product? product)
        {
            bool l = false;
            product = null;
            int min = 0;
            foreach (Product p in d.stock)
            {
                if (p.name != name) continue;
                if (l)
                {
                    if (min > p.price)
                    {
                        min = p.price;
                        product = p;
                    }
                }
                else
                {
                    l = true;
                    min = p.price;
                    product = p;
                }
            }
            return l;
        }
    }
}
