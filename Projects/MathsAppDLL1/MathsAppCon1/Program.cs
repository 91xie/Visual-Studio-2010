using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathsAppDLL1;

namespace MathsAppCon1
{
    class Program
    {
        static double f(double x)
        { return Math.Cos(x); }
        static void Main(string[] args)
        {
            Console.WriteLine(MathMethods.Diff2Point(f, 0.5, 0.00001));
            Console.WriteLine(-1*Math.Sin(0.5));
            Console.ReadLine();
        }
    }
}
