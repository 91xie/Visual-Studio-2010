using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2007Summer
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double [] { 1, 2, 3 };
            double[] b = new double [] { 3, 4, 5 };
            double[] c = CrossProduct(a, b);
            Console.WriteLine("{0} X {1} = {2}", ArrayWrite(a), ArrayWrite(b), ArrayWrite(c));
            Console.ReadLine();
        }

        static string ArrayWrite(double[] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("(");
            for (int i = 0; i < a.Length; i++)
            { s.Write("{0},", a[i]); }

            s.Write(")");
            return s.ToString();

        }

        static double[] CrossProduct(double[] a, double[] b)
        {
            if ((a.Length!= 3)||(b.Length!=3) )
            {
                Console.WriteLine("Wrong Length");
                return new double[] { 0, 0, 0 };
            }
            double x, y, z;
            x = (a[1] * b[2]) - (a[2] * b[1]);
            y = (a[2] * b[0]) - (a[0] * b[2]);
            z = (a[0] * b[1]) - (a[1] * b[0]);
            return new double[] { x, y, z };
        }
    }
}
