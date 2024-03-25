namespace Dispenser;

public class Dispenser
{
    private readonly int total;
    private readonly int portion;
    private int current;

    public int Total
    {
        get { return total; }
    }

    public int Portion => portion;

    public int Current
    {
        get { return current; }
    }

    public Dispenser(int total, int portion)
    {
        this.total = total;
        this.portion = portion;
        this.current = 0;
    }

    public void Press()
    {
        current = Math.Max(current - Portion, 0);
    }

    public void Fill()
    {
        current = Total;
    }
}
