namespace Dispenser;

class Program
{
    static void Main(string[] args)
    {
        Dispenser d = new Dispenser(500, 10);
        Dispenser dpp = new(1000, 15);

        Console.WriteLine($"Dispenser \"d\" has a total capacity of: {d.Total} ml");
        Console.WriteLine($"Dispenser \"d\" has a portion size of: {d.Portion} ml");
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of \"soap\"");
        
        d.Fill();
        Console.WriteLine("Fill called on Dispenser \"d\"");
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of \"soap\"");

        for (int i = 0; i < 10; i++)
        {
            d.Press();
        }
        Console.WriteLine($"Dispenser \"d\" currently has {d.Current} ml of \"soap\"");
    }
}