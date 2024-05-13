using System;

namespace Midterm
{
    class Program
    {
        public static void Main(string[] args)
        {
            Course c = new Course("Objektumelvű Programozás");
            Exam e = new Exam(c, "2024.05.27.");
            Location l = e.MostLikedLocation();


            Random rand = new Random(5);
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(rand.NextInt64(0, 100000));
            }
        }
    }
}