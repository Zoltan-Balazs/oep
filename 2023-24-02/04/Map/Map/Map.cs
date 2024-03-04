namespace Map
{
    public class Map
    {
        public class AlreadyExistingKeyException : Exception { }
        public class NonExistingKeyException : Exception { }
        
        public class Item
        {
            public string data;
            public int key;

            // public Item(Item item)
            // {
            //     data = item.data;
            //     key = item.key;
            // }

            public Item(int key, string data)
            {
                this.key = key;
                this.data = data;
            }

            public override string ToString()
            {
                /*
                 string s = "(";
                 s += key.toString();
                 s += ":";
                 s += data;
                 s += ")";
                 return s;
                 */
                return $"({key}:{data})";
            }
        }

        private List<Item> seq = new List<Item>();

        public void SetEmpty()
        {
            seq.Clear();
            // seq = new List<Item>();
        }
        
        public int Count()
        {
            return seq.Count;
        }

        public void Insert(Item e)
        {
            bool l = LogSearch(e.key, out int ind);
            if (l)
            {
                throw new AlreadyExistingKeyException();
            }
            seq.Insert(ind, e);
        }

        public void Remove(int key)
        {
            bool l = LogSearch(key, out int ind);
            if (!l)
            {
                throw new NonExistingKeyException();
            }
            seq.RemoveAt(ind);
        }

        public bool In(int key)
        {
            // bool l = LogSearch(key, out int ind);
            // return l;
            return LogSearch(key, out int ind);
        }

        public string Select(int key)
        {
            bool l = LogSearch(key, out int ind);
            if (!l) { 
                throw new NonExistingKeyException();
            }

            return seq[ind].data;
        }

        private bool LogSearch(int key, out int ind)
        {
            bool l = false;
            ind = -1;

            int ah = 0;
            int fh = seq.Count - 1;
        
            while (!l && ah <= fh)
            {
                ind = (ah + fh) / 2;

                if (seq[ind].key > key)
                {
                    fh = ind - 1;
                }
                else if (seq[ind].key == key)
                {
                    l = true;
                }
                else if (seq[ind].key < key)
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

        public override string ToString()
        {
            string s = "[";
            foreach (Item e in seq)
            {
                s += e.ToString();
            }
            s += "]";
            return s;
        }
    }
}
