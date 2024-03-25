using System;
using System.Collections.Generic;
using TextFile;

namespace Invoice1
{
    class Program
    {
        struct Product
        {
            public Product(string i, int p)
            {
                id = i;
                price = p;
            }

            public string id;
            public int price;
        }

        class Invoice
        {
            public Invoice(string n)
            {
                name = n;
                list = new List<Product>();
            }

            public string name;
            public List<Product> list;

            public void Add(Product product)
            {
                list.Add(product);
            }
        }

        static void Main()
        {
            try
            {
                TextFileReader f = new("input.txt");

                int income = 0;
                while (ReadInvoice(ref f, out Invoice invoice))
                {
                    income += Sum(invoice.list);
                }
                Console.WriteLine("Total income: {0}", income);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }

        static int Sum(List<Product> list)
        {
            int total = 0;
            foreach (Product p in list)
            {
                total += p.price;
            }
            return total;
        }

        static bool ReadInvoice(ref TextFileReader f, out Invoice invoice)
        {
            invoice = null;
            bool l = f.ReadLine(out string line);
            if (l)
            {
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                invoice = new Invoice(tokens[0]);

                for (int i = 1; i < tokens.Length; i += 2)
                {
                    invoice.Add(new Product(tokens[i], int.Parse(tokens[i + 1])));
                }
            }
            return l;
        }
    }
}
