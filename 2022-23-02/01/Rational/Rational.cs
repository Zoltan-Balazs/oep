using System;

namespace Rational
{
    class Rational
    {
        public class NullDenominator : Exception { };
        public class NullDivision : Exception { };

        private int n;
        private int d;
        public Rational(int n = 0, int d = 1) 
        { 
            if (d == 0) throw new NullDenominator();
            this.n = n; this.d = d;
            // Reduce();
        }
        public static Rational operator + (Rational a, Rational b)
        {
            return new Rational(a.n * b.d + a.d * b.n, a.d * b.d);
        }
        public static Rational operator - (Rational a, Rational b)
        {
            return new Rational(a.n * b.d - a.d * b.n, a.d * b.d);
        }
        public static Rational operator * (Rational a, Rational b)
        {
            return new Rational(a.n * b.n, a.d * b.d);
        }
        public static Rational operator / (Rational a, Rational b)
        {
            if (0 == b.n) throw new NullDivision();
            return new Rational(a.n * b.d, a.d * b.n);
        }
        public override string ToString() 
        {
            return "(" + n.ToString() + "," + d.ToString() + ")";
        }
        /*
        private void Reduce()
        {
            int s = n * d < 0 ? -1 : 1;
            int a = Math.Abs(n);
            int b = Math.Abs(d);
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            n = s * Math.Abs(n)/a;
            d = Math.Abs(d) / a;
        }
        */
    }
}
