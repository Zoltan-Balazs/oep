using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public class NullDivision : Exception { };

        private readonly double x;
        private readonly double y;
        public Complex(double real, double imag = 0.0)
        {
            x = real; y = imag;
        }
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.x+b.x, a.y+b.y);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.x-b.x, a.y-b.y);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.x*b.x-a.y*b.y, a.x*b.y+a.y*b.x);
        }
        public static Complex operator /(Complex a, Complex b)
        {
            if (b.x==0 && b.y==0) throw new NullDivision();
            return new Complex((a.x*b.x + a.y*b.y)/(b.x*b.x + b.y*b.y), (a.y*b.x - a.x*b.y) / (b.x*b.x + b.y*b.y));
        }

        public override string ToString()
        {
            if (y == 0.0) return String.Format($"{x:0.0#}");
            else if (y > 0.0) return String.Format($"{x:0.0#}+{Math.Abs(y):0.0#}i");
            else if (y < 0.0) return String.Format($"{x:0.0#}-{Math.Abs(y):0.0#}i");
            return "";
        }
    }
}
