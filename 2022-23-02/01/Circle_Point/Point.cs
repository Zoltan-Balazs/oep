using System;

namespace Circle_Point
{
    class Point
    {
        private readonly double x;
        private readonly double y; 
        public Point(double a, double b) { x = a; y = b; }
        public double Distance(Point p) {
            return Math.Sqrt(Math.Pow(x-p.x,2) + Math.Pow(y-p.y,2));
        }
    }
}
