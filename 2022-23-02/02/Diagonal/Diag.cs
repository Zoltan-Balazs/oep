using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal
{
    public class Diag
    {
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };

        private readonly List<double> x = new ();

        public Diag(int k)
        {
            for (int i = 0; i < k; ++i)
            {
                x.Add(0);
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= x.Count || j < 0 || j >= x.Count) throw new IndexOutOfRangeException();
                if (i == j) return x[i]; else return 0;
            }
            set
            {
                if (i < 0 || i >= x.Count || j < 0 || j >= x.Count) throw new IndexOutOfRangeException();
                if (i == j) x[i] = value; else throw new ReferenceToNullPartException();
            }
        }

        public static Diag operator +(Diag a, Diag b)
        {
            if (a.x.Count != b.x.Count) throw new DifferentSizeException();
            Diag c = new (a.x.Count);
            for (int i = 0; i < c.x.Count; ++i)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }

        public static Diag operator *(Diag a, Diag b)
        {
            if (a.x.Count != b.x.Count) throw new DifferentSizeException();
            Diag c = new (a.x.Count);
            for (int i = 0; i < c.x.Count; ++i)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < x.Count; ++i)
            {
                for (int j = 0; j < x.Count; ++j)
                {
                    str += "\t" + this[i, j];
                }
                str += "\n";
            }
            return str;
        }
    }
}
