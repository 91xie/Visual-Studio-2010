using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_05_2011
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle Circlea = new Circle(new Centroid(1, 3), 4);
            Console.WriteLine(Circlea);

            Square Squarea = new Square(new Centroid(3, 4), 5, 6);
            Console.WriteLine(Squarea);
            Console.ReadLine();

            Console.WriteLine("Another Section...");

            double[] a = new double[] { 1, 2, 3, 5 };
            double[] b = new double[] { 3, 4, 5, 6 };

            double[] size4_1D_array = new double[4] { 1, 3, 4, 5 };
            double[] shorthand = { 4, 5, 6, 7 };

            double[][] jaggedarraya = new double[3][];// jagged array, an array of varying length inside of another array.
            jaggedarraya[0] = new double[] { 1, 2 };//an sub array in the main jagged array.
            jaggedarraya[1] = new double[] { 3, 5, 6 };
            jaggedarraya[2] = new double[] { 4, 5, 6, 7 };

            // jagged arrays

            double[,] c = new double[3, 2] { { 2, 3, }, { 2, 3 }, { 4, 3 } };//2D arrays

            double[,] copyofc = (double[,])c.Clone();//copy and also notice casting


            Console.WriteLine("");
            Console.WriteLine("c.GetUpperBound(0) {0}", c.GetUpperBound(0) + 1); //GetUpperBound(0) is the no of rows
            Console.WriteLine("c.GetUpperBound(1) {0}", c.GetUpperBound(1) + 1); //GetUpperBound(1) is the no of columns
            //both are zero indexing.


            Console.ReadLine();

            //==============
            /* 
             VARIABLES- is an OJBECT that cane store data during runtime.
             * Identifier is the name.
             * type is the type of data (like double, int string etct)
             * 
             * 2 types of variables.
             * 1. Value type
             * 2. Reference type
             * 
             * 1. considering value type variables for the moment
             * Variables which refer directly to the data. any manipulation is carried out directly on the value stored in the memory location.
             * int n = 33; assigns 33 to this memory location called n. whatever you do to change "n" it will change the value which is stored in n.
             * 
             * 
             * 
             */

            List<double> Listofrandomdoubles = new List<double>();

            Random myrandomgen = new Random();

            for (int i = 0; i <= 10; i++)
            { Listofrandomdoubles.Add(myrandomgen.NextDouble()); }

            for (int i = 0; i <= Listofrandomdoubles.Count() - 1; i++)
            {
                Console.WriteLine(Listofrandomdoubles[i]);
            }

                bool inRange1, inRange2, xInRange;
                int x = 0;
                inRange1 = x > 0 && x < 10;
                inRange2 = x > 20 && x < 30;
                xInRange = inRange1 || inRange2;
                if (xInRange)
                { /*write a method... these booleans could be used inside the "if" statements or while or etcs...*/};


            //switch contorl statement...
            //is a control statement that selects a switch section to execute from a list of candidates///

            //write bisection method and write a macluarin series.

            //Write code to compute factorial...
                double sum = 0;
            Console.Write("f(x) = cosx input x:=  ");
                double input = double.Parse(Console.ReadLine());
                int f = 1;    
            for (int n = 0; n < 10; n++)
                {
                    
                    if (n != 0)
                    {
                        int fstarter = 2 * n;

                         f = fstarter;
                        int checker = fstarter - 1;
                        while (checker > 0)
                        {
                            f *= checker;
                            checker--;
                        }
                    }
                    else if (n == 0) { f = 1; }
                    sum += (Math.Pow(-1, n) * Math.Pow(input, 2 * n))/f;
                    Console.WriteLine("n= {0}, factorial = {1},     top of the line = {2}", n,f,(Math.Pow(-1, n) * Math.Pow(input, 2 * n + 1)));
                    Console.WriteLine("         sum = {0}",sum);
                    //f is the factorial under the line.
                    

                    
                }

                Console.WriteLine("input (x) : {0} , f(x): {1} ", input, sum);
            
            Console.WriteLine("Value of math.cos(x) = {0}", Math.Cos(input));
            Console.ReadLine();



            }
        


        static double [,] OuterProduct(double[] a, double[] b)
        {
            double[,] c = new double[,] { };
            return c;
        }
    }





    struct Centroid
    { 
        public double x, y;
        public Centroid(double x, double y) { this.x = x; this.y = y; }
        
        public Centroid(Centroid a) { x = a.x; y = a.y; }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }

    abstract class Shapes
    {
        abstract public string Type { get; }
        abstract public double Area { get; }
        public Centroid Center;

        public Shapes(Centroid Center)
        { this.Center = Center; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Name: {0}", Type);
            s.WriteLine("Centroid {0}", Center);
            s.Write("Area {0}", Area);
            return s.ToString();
        }

    }

    class Circle : Shapes
    {
        public override string Type {get {return "Circle";}}
        public double Radius;
        public override double Area { get { return Math.PI * Radius * Radius; } }

        //constructors
        public Circle(Centroid Center, double Radius)
            : base(Center)
        { this.Radius = Radius; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine(base.ToString());
                s.WriteLine("Radius {0}",Radius);

            return s.ToString();
        }
    }

    class Square : Shapes
    {
        public override string Type
        {
            get { return "Sqaure"; }
        }
        public double Width, Height;
        public override double Area
        {
            get { return Width * Height; }
        }

        public Square(Centroid Center, double Width, double Height)
            : base(Center)
        { this.Width = Width; this.Height = Height; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine(base.ToString());
            s.WriteLine("Width {0}, Height {1}", Width, Height);

            return s.ToString();
        }
    }
}
