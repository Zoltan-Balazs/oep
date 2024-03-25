using System;

namespace Circle_Point
{
    class Circle
    {
        public class WrongRadiusException : Exception { }

        private readonly Point c;
        private readonly double r;

        public Circle(Point c, double r)
        {
            if (r < 0)
                throw new WrongRadiusException();
            this.c = c;
            this.r = r;
        }

        public bool Contains(Point p)
        {
            return c.Distance(p) <= r;
        }
    }
}
