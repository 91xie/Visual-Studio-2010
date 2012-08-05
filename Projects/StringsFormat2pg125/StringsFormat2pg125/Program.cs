using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringsFormat2pg125
{
    class Program
    {
        static void Main(string[] args)
        {
            //upper case to lower case//transfer all to one format to make life easier.
            Console.WriteLine("upper case to lower case//transfer all to one format to make life easier.");

            string lowcase = "armadillo";
            string uppercase = lowcase.ToUpper();
            lowcase = "armadillo";
            Console.WriteLine(uppercase);

            Console.ReadLine();

            Console.WriteLine();


            List<Vector3D> ListofVector3D = new List<Vector3D>();
            string input ="";

            while (input != "quit")
            {

                Console.WriteLine("String Splitter");
                Console.Write("Input values like (x,y,z)=");
                input = Console.ReadLine();
                char[] dividers = { '(', ',', ',', ')' };
                string[] segements = input.Split(dividers);
                double[] vector = new double[3];
                int j = 0;
                for (int i = 0; i < segements.Length && j < 3; i++)
                {
                    if (IsAllDigit(segements[i]))
                    {
                        vector[j] = double.Parse(segements[i]);
                        j++;
                    }



                }

                ListofVector3D.Add(new Vector3D(vector));
                foreach (Vector3D a in ListofVector3D)
                { Console.WriteLine(a); }
            }
            //got segements, now increment through each segement and assign it to new 2DVector

            Console.Write("Quit..."); Console.ReadLine();
        }

        class Vector3D
        {

            public double x, y, z;
            // Constructors
            public Vector3D() { x = 0; y = 0; z = 0; }
            public Vector3D(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
            public Vector3D(Vector3D a) { x = a.x; y = a.y; z = a.z; }
            public Vector3D(double[] a) { x = a[0]; y = a[1]; z = a[2]; }

            // readonly properties
            public double Magnitude { get { return Math.Sqrt(x * x + y * y + z * z); } }
            public Vector3D UnitVector { get { return new Vector3D(this / this.Magnitude); } }

            // Instance Methods
            public double DotProduct(Vector3D a) { return a.x * x + a.y * y + a.z * z; }
            public Vector3D CrossProduct(Vector3D b)
            {
                double p = y * b.z - z * b.y;
                double q = z * b.x - x * b.z;
                double r = x * b.y - y * b.x;
                return new Vector3D(p, q, r);
            }
            public void ScaleBy(double scale) { x /= scale; y /= scale; z /= scale; }

            // Static methods
            public static double DotProduct(Vector3D a, Vector3D b) { return a.DotProduct(b); }
            public static Vector3D CrossProduct(Vector3D a, Vector3D b) { return a.CrossProduct(b); }

            // Overloaded operators
            public static Vector3D operator +(Vector3D a, Vector3D b)
            { return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z); }

            public static Vector3D operator -(Vector3D a, Vector3D b)
            { return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z); }

            public static Vector3D operator *(Vector3D a, double scale)
            { return new Vector3D(a.x * scale, a.y * scale, a.z * scale); }

            public static Vector3D operator *(double scale, Vector3D a)
            { return new Vector3D(a.x * scale, a.y * scale, a.z * scale); }

            public static Vector3D operator /(Vector3D a, double divisor)
            { return new Vector3D(a.x / divisor, a.y / divisor, a.z / divisor); }

            // Overriden methods
            public override string ToString() { return "(" + x + ", " + y + ", " + z + ")"; }

            // Destructor
            ~Vector3D() { Console.WriteLine("Vector3D object finally deleted"); }
        }

        static string FirstCharUpper(string a)
        {
            string newstring ="";
            newstring += a[0].ToString().ToUpper();
            newstring += a.Substring(1, a.Length - 1);
            
            return newstring;


        }

        static bool IsAllDigit(string a)
        {
            if (a.Length == 0)
            {
                return false;
            }
            foreach (char s in a)
            {
                if (!char.IsDigit(s)) { return false; }
            }
            return true;
        }
    }
}
