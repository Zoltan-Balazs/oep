namespace AHM
{
    public class AHM
    {
        public class ReferenceToNullPartException : Exception { };

        public class DifferentSizeException : Exception { };

        private readonly List<double> x = new();
        private readonly int dim;

        public AHM(int dim)
        {
            this.dim = dim;
            for (int i = 0; i < dim * (dim + 1) / 2; ++i)
            {
                x.Add(0.0);
            }
        }

        private static int Ind(int i, int j)
        {
            return (i - 1) * i / 2 + j - 1;
        }

        public double this[int i, int j]
        {
            get
            {
                if (i <= 0 || i > dim || j <= 0 || j > dim)
                    throw new IndexOutOfRangeException();
                if (i >= j)
                    return x[Ind(i, j)];
                else
                    return 0;
            }
            set
            {
                if (i <= 0 || i > dim || j <= 0 || j > dim)
                    throw new IndexOutOfRangeException();
                if (i >= j)
                    x[Ind(i, j)] = value;
                else
                    throw new ReferenceToNullPartException();
            }
        }

        public static AHM operator +(AHM a, AHM b)
        {
            if (a.dim != b.dim)
                throw new DifferentSizeException();
            AHM c = new(a.dim);
            for (int i = 0; i < c.x.Count; ++i)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }

        public static AHM operator *(AHM a, AHM b)
        {
            if (a.dim != b.dim)
                throw new DifferentSizeException();
            AHM c = new(a.dim);
            for (int i = 1; i <= c.dim; ++i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    double s = 0.0;
                    for (int k = j; k <= i; ++k)
                        s += a.x[Ind(i, k)] * b.x[Ind(k, j)];
                    c.x[Ind(i, j)] = s;
                }
            }
            return c;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 1; i <= dim; ++i)
            {
                for (int j = 1; j <= dim; ++j)
                {
                    str += "\t" + this[i, j];
                }
                str += "\n";
            }
            return str;
        }
    }
}
