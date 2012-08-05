using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCalculusConsole
{
    class Program
    {
        static double myf(double x)
        {
            return Math.Sin(x);
        }
        static double myf2(double x)
        { return Math.Exp(x) * Math.Cos(x); }

        static void Main(string[] args)
        {
            CalculusClasses.Calculus myCalc = new CalculusClasses.Calculus();
            myCalc.f = myf;
            //pass the function on towards.
            //pass the function instead of using the entire thing.
            //delegate is a function reference.
            Console.WriteLine(myCalc.FirstDerivative(1.0));
            Console.WriteLine(Math.Cos(1.0));
            Console.WriteLine(myCalc.SecondDerivative(1.0));
            Console.WriteLine(-1 * Math.Sin(1.0));

            Console.WriteLine(CalculusClasses.Calculus.FirstDerivative(myf, 1.0));
            Console.WriteLine(CalculusClasses.Calculus.FirstDerivative(myf2, 1.0));
            Console.ReadLine();
        }
    }
}
