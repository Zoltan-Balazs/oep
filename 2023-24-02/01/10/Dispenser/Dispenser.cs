namespace Dispenser;

public class Dispenser
{
    private readonly int total;
    private readonly int portion;
    private int current;

    public int Total
    {
        get
        {
            return total;
        }
    }

    public int Portion => portion;
    public int Current => current;

    public Dispenser(int total, int portion)
    {
        this.total = total;
        this.portion = portion;
        this.current = 0;
    }

    public void Press()
    {
        current = Math.Max(current - portion, 0);

        /*
        current = current - portion;
        if (current < 0)
        {
            current = 0;
        }
        */
    }

    public void Fill()
    {
        current = total;
    }
}