namespace Dispenser;

class Program
{
    static void Main(string[] args)
    {
        Dispenser d = new Dispenser(500, 15);
        Dispenser dpp = new(1000, 10);

        Console.WriteLine($"Dispenser \"d\" has a Total capacity: {d.Total} ml");
        Console.WriteLine($"Dispenser \"d\" has a Portion size of: {d.Portion} ml");
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of soap");
        
        d.Fill();
        Console.WriteLine("Called Fill on Dispenser \"d\"");
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of soap");

        for (int i = 0; i < 13; i++)
        {
            d.Press();
        }
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of soap");
    }
}

