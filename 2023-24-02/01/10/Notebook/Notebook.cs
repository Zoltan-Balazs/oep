using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class Notebook
    {
        public class IllegalSideException : Exception {};
     
        public enum Sort { plain, grid, lined };
        private readonly Sort type;
        public Sort Type { get { return type; } }
        public enum State { empty, full };
        public class Page 
        { 
            public State state;
            public string content;
            public Page()
            {
                state = State.empty;
                content = "";
            }
        };

        private readonly List<Page> pages;
        private int total;

        public Notebook(int n, Sort t)
        {
            type = t;
            pages = new List<Page>(); 
            for(int i=0; i < n; ++i) { pages.Add(new Page()); }
            total = 0;
        }

        public int EmptyCount() { return pages.Count - total; }

        public int Count() { return pages.Count; }

        public void Remove(int ind) 
        {
            --ind;
            if (ind < 0 || ind >= pages.Count) throw new IllegalSideException();
            if (pages[ind].state == State.full) { --total; }
            pages.RemoveAt(ind);
        }

        public void Write(int ind) 
        {
            --ind;
            if (ind < 0 || ind >= pages.Count || pages[ind].state==State.full) throw new IllegalSideException();
            pages[ind].state = State.full;
            ++total;
        }

        public class BoolxNat
        {
            public bool b;
            public int n;

            public BoolxNat(bool b, int n)
            {
                this.b = b;
                this.n = n;
            }
        }
        
        public BoolxNat Search()
        {
            int ind = 0;
            for(int i=0; i<pages.Count; ++i)
            {
                if (pages[i].state == State.empty) { ind = i+1; return new BoolxNat(true, ind); }
            }
            return new(false, ind);
        }
    };

}