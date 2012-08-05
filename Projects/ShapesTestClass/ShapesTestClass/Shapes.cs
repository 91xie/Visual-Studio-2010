using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesTestClass
{

    struct Point2D
    {
        public double x, y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;

        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }


   

        

        abstract class Shape
        {
            public Point2D Centroid;
            public abstract double Area { get; }

        public Shape(Point2D Centroid)
        {
            this.Centroid = Centroid;
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Shape with:");
            s.WriteLine("   Area    := {0:f2}", Area);
            s.WriteLine("   Centroid:= {0}", Centroid);
            return s.ToString();
        }



        }

        


    

    class Circle : Shape
    {
        public double Radius;//new variable

        public override double Area//overriding base class
        {
            get { return Math.PI * Radius * Radius; }
        }

        public Circle(Point2D Centroid) : base(Centroid) { }
        public Circle(Point2D Centroid, double Radius)
            : base(Centroid)
        { this.Radius = Radius; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Circle ");
            s.Write(base.ToString());
            s.WriteLine("   Radius  :={0}", Radius);

            return s.ToString();
        }

    }

    class Rectangle : Shape
    {
        public double length, width;

        public override double Area
        {
            get { return width * length; }
        }

        public Rectangle (Point2D Centroid) :base (Centroid) {}
        public Rectangle(Point2D Centroid, double width, double length)
            : base(Centroid)
        {
            this.width = width;
            this.length = length;
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Rectangle");
            s.Write(base.ToString());
            s.WriteLine("   Length:= {0:f2}", length);
            s.WriteLine("   Width := {0:f2}", width);
            
            return s.ToString();
        }

    }
}
