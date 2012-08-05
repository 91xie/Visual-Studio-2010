using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathsAppDLL1
{
    public class MathMethods
    {
        public static double UnitStep(double a)
        { if (a >= 0) { return 1; } else { return 0; } }

        public static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false && achar != '-' && achar != '.') return false;

            }
            return true;
        }

        public delegate double theFunction1 (double x);
        public delegate double theFunction2(double x, double y);


        //VOLUME ESTIMATION
        /*

        public static double VolEstSimpRule(theFunction2 fVol, double ax, double bx, double y, int m)
        {
            double h = (bx - ax) / (2 * m);
            double[] x = new double[2 * m + 1];
            x[0] = ax;

            for (int i = 1; i <= 2 * m; i++)
            { x[i] += x[i - 1] + h; }


            double sumfx1 = 0;
            for (int i = 1; i <= m; i++)
            { sumfx1 += fVol(x[2 * i - 1], y); }

            double sumfx2 = 0;

            for (int i = 1; i <= m - 1; i++)
            {
                sumfx2 += fVol(x[2 * i], y);
            }

            return (h / 3) * (fVol(ax, y) + 4 * sumfx1 + 2 * sumfx2 + fVol(bx, y));
        }


        public static double VolEst(theFunction2 fVol, double ax, double bx, double ay, double by, int m)
        {
            double h = (by - ay) / (2 * m);
            double[] y = new double[2 * m + 1];
            y[0] = ay;

            for (int i = 1; i <= 2 * m; i++)
            { y[i] += y[i - 1] + h; }
            //y matrix



            int j = 0;
            double sumVol = 0;
            foreach (double y1 in y)
            {
                sumVol += h * VolEstSimpRule(fVol, ax, bx, y1, m);
                j++;
            }

            return sumVol;
        }

        public static double VolEstAv(theFunction2 fVol, double ax, double bx, double ay, double by, int m)
        {
            double run1 = VolEst(fVol, ax, bx, ay, by, m);
            double run2 = VolEst(fVol, ay, by, ax, bx, m);
            return (run1 + run2) / 2;
        }


        public static double VolEstTrapRule(List<Vector3D> aList)
        {
            //just consider x's and z's;

            //each x needs to be distinct.
            double[,] xys = new double[aList.Count, 2];
            double[] xs = new double[aList.Count];
            int i = 0;

            foreach (Vector3D a in aList)
            { xs[i] = a.x; i++; }

            Array.Sort(xs);



            i = 0;
            foreach (double x in xs)
            { xys[i, 0] = x; i++; }


            for (i = 1; i < xs.Length; i++)
            {
                if (xs[i] == xs[i - 1])
                {
                    Console.WriteLine("x's coordinates are not all unique");
                    return 0;
                }
            }



            for (i = 0; i < aList.Count; i++)
            {
                for (int j = 0; j < aList.Count; j++)
                {
                    if (xys[i, 0] == aList[j].x)
                    { xys[i, 1] = aList[j].z; }
                }
            }


            double sum = 0;

            for (i = 0; i < xys.GetUpperBound(0); i++)
            { sum += (xys[i + 1, 0] - xys[i, 0]) * ((xys[i, 1] + xys[i + 1, 1]) / 2); }

            return sum;
        }

        //VOLUME ESTIMATIONXXXX
        */





        //DIFFERENTIAL

        

        public static double Diff2Point(theFunction1 fDiff, double x, double h)
        { return (fDiff(x + h) - fDiff(x - h)) / (2 * h); }

        //DIFFERENTIALXXXXXXX

        //BISECTION.......
        
        static bool BisectionValid(theFunction1 fBisection, double a, double b)
        {
            if (fBisection(a) * fBisection(b) < 0) return true;
            else return false;
        }

        public static double BisectionMethod(theFunction1 fBisection, double x1, double x2, double eps)
        {
            double a = x1; double b = x2;
            //starting values for x1 and x2... only works if they are on opposite side of the equation. you also need an equation.
            double m = 0, fm;

            fm = 1000000;


            while (fm > eps)
            {
                {
                    m = (a + b) / 2;
                    fm = fBisection(m);
                    if (fBisection(a) * fm < 0) { b = m; }
                    else if (fBisection(b) * fm < 0) { a = m; }
                }

            }

            return m;

        }

        public static string BisectionConsoleWriteLine(theFunction1 fBisection, double x1, double x2, double eps)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("x1=({0}) x2=({1}) iterations=({2})", x1, x2, eps);
            if (BisectionValid(fBisection, x1, x2) == true)
            {
                s.WriteLine("Bisection Valid = TRUE");
                s.WriteLine("m=({0})", BisectionMethod(fBisection, x1, x2, eps));
            }
            else { s.WriteLine("Bisection Valid = FALSE"); }
            return s.ToString();
        }
        //BISECTIONXXXXXXXXXXX

        //ITERATIONS.......
        static double fIteration(double x)
        {//
            //compute squareroot of 3...
            return (0.5) * (3 / x + x);
        }

        public static double IterationMethod(double startvalue, int iterations)
        {
            double x = startvalue;
            //assuming that it is lipschitz whatever...
            for (int i = 0; i < iterations; i++)
            {
                Console.WriteLine("i({0}) x({1})", i, x);
                x = fIteration(x);

            }
            return x;

        }

        //ITERATIONSXXXXXXXXXX


        //SimpsonsRule

        

        public static double SimpRule(theFunction1 fSimpRule , double a, double b, int m)
        {
            double h = (b - a) / (2 * m);
            double[] x = new double[2 * m + 1];
            x[0] = a;

            for (int i = 1; i <= 2 * m; i++)
            { x[i] += x[i - 1] + h; }

            double sumfx1 = 0;
            for (int i = 1; i <= m; i++)
            { sumfx1 += fSimpRule(x[2 * i - 1]); }

            double sumfx2 = 0;

            for (int i = 1; i <= m - 1; i++)
            {
                sumfx2 += fSimpRule(x[2 * i]);
            }





            return (h / 3) * (fSimpRule(a) + 4 * sumfx1 + 2 * sumfx2 + fSimpRule(b));
        }

        public static double[] MatlabVector(double a, double delta, double b)
        {
            List<double> aList = new List<double>();

            double x = a;
            aList.Add(x);
            while (x < b - delta)
            {
                x += delta;
                aList.Add(x);
            }

            double[] output = new double[aList.Count];
            int i = 0;
            foreach (double ax in aList)
            {
                output[i] = ax;
                i++;
            }
            return output;
        }
        //SimpRulexxxxxxxxxx
        /*
        //TrapRule

        public static double TrapRule(List<Vector3D> aList)
        {
            //just consider x's and y's;

            //each x needs to be distinct.
            double[,] xys = new double[aList.Count, 2];
            double[] xs = new double[aList.Count];
            int i = 0;

            foreach (Vector3D a in aList)
            { xs[i] = a.x; i++; }

            Array.Sort(xs);



            i = 0;
            foreach (double x in xs)
            { xys[i, 0] = x; i++; }


            for (i = 1; i < xs.Length; i++)
            {
                if (xs[i] == xs[i - 1])
                {
                    Console.WriteLine("x's coordinates are not all unique");
                    return 0;
                }
            }



            for (i = 0; i < aList.Count; i++)
            {
                for (int j = 0; j < aList.Count; j++)
                {
                    if (xys[i, 0] == aList[j].x)
                    { xys[i, 1] = aList[j].y; }
                }
            }


            double sum = 0;

            for (i = 0; i < xys.GetUpperBound(0); i++)
            { sum += (xys[i + 1, 0] - xys[i, 0]) * ((xys[i, 1] + xys[i + 1, 1]) / 2); }

            return sum;
        }

        //TrapRULEXXX
        */


    }//
    class Vector3D
    {

        public double x, y, z;
        // Constructors
        public Vector3D() { x = 0; y = 0; z = 0; }
        public Vector3D(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        public Vector3D(Vector3D a) { x = a.x; y = a.y; z = a.z; }
        public Vector3D(double[] a) { x = a[0]; y = a[1]; z = a[2]; }
        public Vector3D(string a)
        {
            x = 0; y = 0; z = 0;
            char[] sep = new char[] { ',', ' ' };
            string[] segments = a.Split(sep);

            List<string> segments2 = new List<string>();
            foreach (string ofsegments in segments)
            {
                if (ofsegments != "")
                {
                    segments2.Add(ofsegments);
                }
            }



            List<double> listofstringno = new List<double>();
            for (int i = 0; i < segments2.Count; i++)
            {
                if (IsDigit(segments2[i]))
                {
                    listofstringno.Add(double.Parse(segments2[i]));
                }
            }

            x = listofstringno[0]; y = listofstringno[1]; z = listofstringno[2];

        }


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
            char[] seperators = new char[] { ',', '(', ')', ' ', '\n' };

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
                if (char.IsDigit(achar) == false && achar != '-' && achar != '.') return false;

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
