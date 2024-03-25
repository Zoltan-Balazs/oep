namespace PriorityQueue
{
    class Element
    {
        public int pr;
        public string data;

        public Element()
        {
            data = "";
        }

        public Element(int p, string str)
        {
            pr = p;
            data = str;
        }

        public override string ToString()
        {
            return "(" + pr.ToString() + ", " + "data" + ")";
        }

        public void Read()
        {
            Console.WriteLine("Elembe kerülő adat: ");
            data = Console.ReadLine()!;
            bool ok;
            do
            {
                Console.WriteLine("Elem prioritása (egész szám): ");
                try
                {
                    pr = int.Parse(Console.ReadLine()!);
                    ok = true;
                }
                catch (System.FormatException)
                {
                    ok = false;
                }
            } while (!ok);
        }
    }

    class PrQueue
    {
        private readonly List<Element> seq = new(); //tároló sorozat vectorral implementálva

        public class PrQueueEmpty : Exception { }

        public void Add(Element a)
        {
            seq.Add(a);
        }

        public Element RemMax() //legnagyobb prioritássú elem kivétele a sorból
        {
            if (seq.Count == 0)
                throw new PrQueueEmpty();
            int ind = MaxIndex();
            Element best = seq[ind];
            seq.RemoveAt(ind);
            return best;
        }

        public Element GetMax() //(egyik) legnagyobb prioritású elem visszaadása
        {
            if (seq.Count == 0)
                throw new PrQueueEmpty();
            int ind = MaxIndex();
            return seq[ind];
        }

        public bool IsEmpty() //pr.sor ürességét vizsgálja
        {
            return seq.Count == 0;
        }

        public int GetCapacity()
        {
            return seq.Capacity;
        }

        public void Write()
        {
            foreach (Element e in seq)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private int MaxIndex() //maximális elem indexének kiválasztása
        {
            int ind = 0;
            int maxkey = seq[0].pr;
            for (int i = 1; i < seq.Count; ++i)
            {
                if (seq[i].pr > maxkey)
                {
                    ind = i;
                    maxkey = seq[i].pr;
                }
            }
            return ind;
        }
    }
}
