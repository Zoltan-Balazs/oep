namespace Bag;

public class Bag
{
    public class Pair
    {
        public string data;
        public int count;

        public Pair(string e, int c)
        {
            data = e;
            count = c;
        }
    }
    
    private List<Pair> seq = new List<Pair>();
    private int maxInd = 0;
    
    public Bag()
    {
        // seq = new List<Pair>();
    }

    public void SetEmpty()
    {
        seq.Clear();
        // seq = new List<Pair>();
    }

    public class EmptyBagException : Exception
    {
        
    }

    public string Max()
    {
        if (seq.Count > 0)
        {
            return seq[maxInd].data;
        }

        // return "";
        throw new EmptyBagException();
    }

    public struct boolXint
    {
        public bool b;
        public int i;
    }

    private boolXint LogSearch(string e)
    {
        bool l = false;
        int ah = 0;
        int fh = seq.Count - 1;
        int ind = -1;

        while (!l && ah <= fh)
        {
            ind = (ah + fh) / 2;

            if (string.Compare(seq[ind].data, e) > 0)
            {
                fh = ind - 1;
            }
            else if (string.Compare(seq[ind].data, e) == 0)
            {
                l = true;
            }
            else if (string.Compare(seq[ind].data, e) < 0)
            {
                ah = ind + 1;
            }
        }

        if (!l)
        {
            ind = ah;
        }

        boolXint bxi = new boolXint();
        bxi.b = l;
        bxi.i = ind;
        
        return bxi;
    }

    private bool LogSearch(string e, out int ind)
    {
        bool l = false;
        ind = -1;

        int ah = 0;
        int fh = seq.Count - 1;
        
        while (!l && ah <= fh)
        {
            ind = (ah + fh) / 2;

            if (string.Compare(seq[ind].data, e) > 0)
            {
                fh = ind - 1;
            }
            else if (string.Compare(seq[ind].data, e) == 0)
            {
                l = true;
            }
            else if (string.Compare(seq[ind].data, e) < 0)
            {
                ah = ind + 1;
            }
        }

        if (!l)
        {
            ind = ah;
        }

        return l;
    }

    public int Multipl_1(string e)
    {
        boolXint bxi = LogSearch(e);

        bool l = bxi.b;
        int ind = bxi.i;

        if (l) // l == bxi.b
        {
            return seq[ind].count; // ind == bxi.i;
        }

        return 0;
    }

    public int Multipl_2(string e)
    {
        bool l = LogSearch(e, out int ind);
        if (l)
        {
            return seq[ind].count;
        }
        else
        {
            return 0;
        }
    }

    public void Insert(string e)
    {
        boolXint bxi = LogSearch(e);
        bool l = LogSearch(e, out int ind); // l == bxi.b
        // int ind = bxi.i;
        if (l)
        {
            ++seq[ind].count;
            if (seq[ind].count > seq[maxInd].count)
            {
                maxInd = ind;
            }
        }
        else
        {
            seq.Insert(ind, new Pair(e, 1));
            if (seq.Count == 1)
            {
                maxInd = 1;
            }
            else if (maxInd > ind)
            {
                ++maxInd;
            }
        }
    }

    public void Remove(string e)
    {
        bool l = LogSearch(e, out int ind);
        if (l)
        {
            if (seq[ind].count > 1)
            {
                --seq[ind].count;
            }
            else if (seq[ind].count == 1)
            {
                seq.RemoveAt(ind);
            }

            if (seq.Count > 0)
            {
                int max = 0;
                for (int i = 0; i < seq.Count; ++i)
                {
                    if (seq[i].count > max)
                    {
                        max = i;
                    }
                }

                maxInd = max;
            }
        }
    }
}