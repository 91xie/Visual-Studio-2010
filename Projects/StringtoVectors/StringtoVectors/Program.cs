using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringtoVectors
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vector3D> ListofVector = new List<Vector3D>();
            //get 3 at a time.
            string rawstring = "(2,3,4) (5,6,3) (6,7,8)";
            Console.WriteLine(rawstring);
            ListofVector = Vector3D.StringToListofVector(rawstring);
            Console.WriteLine(Vector3D.ListToString(ListofVector));
            Console.ReadLine();
            

        }

        

        
        
        static string ArrayofStingtoString(string[] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            for (int i = 0; i < a.Count(); i++)
            {
                s.Write(a[i]);
            }

            return s.ToString();
        }
        
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

        public static List<Vector3D> StringToListofVector(string a)
        {
            List<Vector3D> ListofVector = new List<Vector3D>();
            char[] seperators = new char[] { ',', '(', ')', ' ' };

            string[] w = a.Split(seperators);
            List<string> l1 = new List<string>();

            for (int i = 0; i < w.Count(); i++)
            { if (w[i] != "" && IsDigit(w[i]) == true) { l1.Add(w[i]); } }

            for (int i = 0; i * 3 + 2 < l1.Count(); i++)
            {
                double x, y, z;
                x = double.Parse(l1[(i * 3)]);
                y = double.Parse(l1[(i * 3) + 1]);
                z = double.Parse(l1[(i * 3) + 2]);

                ListofVector.Add(new Vector3D(x, y, z));


            }

            return ListofVector;
        }

        private static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false) return false;

            }
            return true;
        }

        // Overriden methods
        public override string ToString() { return "(" + x + ", " + y + ", " + z + ")"; }

        public static string ListToString(List<Vector3D> a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            for (int i = 0; i < a.Count; i++)
            {
                s.WriteLine(a[i]);
            }
            return s.ToString();
        }


        // Destructor
        ~Vector3D() { Console.WriteLine("Vector3D object finally deleted"); }
    }
}
