using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle a = new Circle(new Point2D(1, 1), 5);
            Console.WriteLine(a);

            Rectangle b = new Rectangle(new Point2D(1, 1), 4, 5);
            Console.WriteLine(b);
            Console.ReadLine();

        }
    }

    struct Point2D
    {
        double x, y;
        public Point2D(double x, double y)
        { this.x = x; this.y = y; }
        public override string ToString()
        {
            return "(" + x + "," + y+ ")";
        }
    }

    abstract class Shape
    {
        public Point2D Centroid;
        public virtual double Area { get { return 0; } }//write virtual on stuff which could be overriden.

        public Shape(Point2D Centroid)
        {
            this.Centroid = Centroid;
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Centroid {0}", this.Centroid);
            s.WriteLine("Area {0}", Area);
            return s.ToString();
        }

    }

    class Circle : Shape
    {
        public double Radius;

        public Circle(Point2D Centroid, double Radius)
            : base(Centroid)
        {
            this.Radius = Radius;
        }

        public override double Area//and override the stuff in your child class
        {
            get { return Math.PI * Radius *Radius; }
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Circle with");
            s.WriteLine(base.ToString());
            s.WriteLine("Radius {0}", Radius);
            return s.ToString();
            

        }
    }

    class Rectangle:Shape
    {
        public double Height, Width;

        public Rectangle(Point2D Centroid, double Height, double Width):base(Centroid)//knows its a constructor so it knows where to put the information
        {
            this.Height = Height;
            this.Width = Width;
        }

        public override double Area
        {
            get
            {
                return Width*Height;
            }
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Rectangle with");
            s.WriteLine(base.ToString());
            s.WriteLine("H {0} W {1}", Height, Width);
            return s.ToString();
        }
    }



}
