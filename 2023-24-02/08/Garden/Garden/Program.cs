using System;

namespace Garden
{
    class Program
    {
        static void Main()
        {
            Garden garden = new(5);
            Gardener gardener = new(garden);

            gardener.garden.Plant(1, Potato.Instance(), 4);
            gardener.garden.Plant(2, Pea.Instance(), 4);
            gardener.garden.Plant(4, Pea.Instance(), 4);

            Console.Write("A betakarithato parcellak azonositoi: ");
            foreach (int i in gardener.garden.CanHarvest(9))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
