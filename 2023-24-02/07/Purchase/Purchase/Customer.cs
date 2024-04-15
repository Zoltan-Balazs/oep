using System;
using System.Collections.Generic;
using TextFile;

namespace Purchase
{
    class Customer
    {
        private List<string> shoppingList = new List<string>();
        public List<Product> shoppingCart = new List<Product>();

        private string name;

        public Customer(string fileName)
        {
            TextFileReader reader = new TextFileReader(fileName);
            reader.ReadLine(out string name);
            this.name = name;

            while (reader.ReadLine(out string str))
            {
                shoppingList.Add(str);
            }
        }

        private void PutsIntoCart(Product product, ref Department department)
        {
            department.stock.Remove(product!);
            shoppingCart.Add(product!);
        }

        private static bool Search(string name, Department department, out Product? product)
        {
            bool l = false;
            product = null;
            // for (int i = 0; i < department.stock.Size() && !l; ++i) .. Product p = department.stock[i];
            foreach (Product p in department.stock)
            {
                if (p.name == name)
                {
                    l = true;
                    product = p;
                    break; // Ha a legelső kell
                }
            }

            return l;
        }

        private static bool MinSearch(string name, Department department, out Product? product)
        {
            bool l = false;
            product = null;
            int min = 0;

            foreach (Product p in department.stock)
            {
                if (p.name != name)
                {
                    continue;
                }

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

        public void Purchase(Store store)
        {
            Console.WriteLine($"{name} bought the following items: ");
            foreach (string productName in shoppingList)
            {
                if (Search(productName, store.foods, out Product? product))
                {
                    PutsIntoCart(product!, store.foods);
                    Console.WriteLine($"{product.name} - {product.price}");
                }
            }

            foreach (string productName in shoppingList)
            {
                if (MinSearch(productName, store.technical, out Product? product))
                {
                    PutsIntoCart(product!, store.technical);
                    Console.WriteLine($"{product.name} - {product.price}");
                }
            }
        }
    }
}
