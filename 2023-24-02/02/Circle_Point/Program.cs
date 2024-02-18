using System;
using TextFile;
using System.Collections.Generic;

namespace Circle_Point
{
    class Program
    {
        static void Main()
        {
            try {
                TextFileReader reader = new ("input.txt");

                reader.ReadDouble(out double a);
                reader.ReadDouble(out double b);
                reader.ReadDouble(out double c);
                Circle k = new (new Point(a, b), c);

                reader.ReadInt(out int n);
                Point[] x = new Point[n];
                for (int i = 0; i<n; ++i)
                {
                    reader.ReadDouble(out a);
                    reader.ReadDouble(out b);
                    x[i] = new Point(a, b);
                }

                // számlálás
                int db = 0;
                foreach (Point e in x)
                {
                    if (k.Contains(e)) ++db;
                }
                Console.WriteLine($"A kör lemezére eső pontok száma: {db}" );

            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Rossz a fájl név!");
            }
            catch (Circle.WrongRadiusException)
            {
                Console.WriteLine("Kör sugara nem lehet negativ!");
            }
        }

    }
}
