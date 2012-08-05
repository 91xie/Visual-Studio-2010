using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial1a
{//notice in same bracket/same name class.
    struct Point2D
    {
        public double x, y;

        public Point2D(double x, double y)
        { this.x = x; this.y = y; }
    }

    class Shape
    {
        public Point2D Centroid;
        public double Area;
        public double Perimeter;
    }

    class Circle : Shape
    {
        public double radius;
    }

    class Rectangle : Shape
    {
        public double height, width;
    }
}
