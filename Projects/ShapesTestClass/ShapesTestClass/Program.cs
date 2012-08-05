using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesTestClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shape Test Class");
            Circle c = new Circle(new Point2D(2, 3), 5);
            Console.WriteLine(c);
            Rectangle r = new Rectangle(new Point2D(4, 4), 2, 4);
            Console.WriteLine(r);
            Console.ReadLine();
        }
    }
}
