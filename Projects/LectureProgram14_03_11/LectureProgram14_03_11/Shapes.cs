using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    struct Point2D 
    {
        public double x, y;
    
    public override string ToString()
        {
          return "(" + x + "," + y + ")";
        }
    }

    abstract class Shapes
    {
        public Point2D centroid;
        public abstract double area { get; }
        //property
        //I'll be able to get it afterwards :P
       //fucking spoof...
        //
        public Shapes(Point2D centroid) 
        {
            this.centroid = centroid;
            Console.WriteLine("Shape constructor is called"); 
        } //default constructors
        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("SHape with:");
            s.WriteLine(" Ara : = {0:f2}", area);
            s.WriteLine(" centroid: = {0}", centroid);

            return base.ToString();
        }
        
    }


    class circle : Shapes
    {
        //every class has a default constructor.
        //no default constructor anymore.
        //need to invoke the parameter for the first constructor to go to the second constructor.
        public double radius;
        public circle(Point2D centroid) : base(centroid) { }
        public circle(Point2D centroid, double radius) : base(centroid) { this.radius = radius; }//this is explicity running.
        public override double area
        {
            get { return Math.PI * radius * radius; }
        }
        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine(" Circle Centre:= {0}", centroid);
            return s;
        }
    
    }

   
    class rectangle : Shapes
    {
        public rectangle(Point2D centroid) : base(centroid) { }
        public double length, width;
        public rectangle (Point2D centroid, double length, double width):base (centroid)
        {
            this.centroid = centroid;
            this.length = length;
            this.width = width;

        }
    }

     
}
//inherit property from the parent class, you can override it.

//vitural keyword, decalring a themod or property as vitual i n the base class allows the mthod to be orrideden in the derived class.
//the override keyword
//shoudl I Bet able to instiatiate. abstract definition of a shape.
//abstract stuff... parent class abstract. "must inherit it"
//one you prevent it from being instiatating it.
//could define a method or a property as abstract as well....


//POLYMORPHISM
/*
 * Greek -many forms.
 * comes from the greeek meanting many forms and menas that an ojbecdt may be treated as a differnt objecdt providing ocmmon sense prevails.
 * ie a chld ojbecdt or many child objects amy be accessed using their parent class
 * for example; in ourdemo exmap sinces hape is a parentof cirel and rectand, then it is possible to access alll the inherited membersof the paretn calss in circle and rectangle.
 * e.g. this is valid.
 * circle c1 = new circle ();
 * shape s1;
 * s1=c1 // s1 now refers to the child obejctd c1
 * Console.WriteLine(s1);
 * 
 * //basically a cirlce is a shape. so you could go shape = circle.
 * however not all shapes are circles so you can't do the reverse of saying circle = shape.
 * 
 * 
 * 
 */
