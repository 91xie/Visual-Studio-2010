using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_04_11b
{
    class Program
    {
        static void Main(string[] args)
        {
            //bisection method

            double x1, x2, fx1, fx2, xm;
            x1 = 0; x2 = 10;
            Console.WriteLine("Starting Values x1: [{0}] and x2: [{1}]", x1, x2);
            fx1 = f(x1); fx2 = f(x2);
            Console.WriteLine("f(x1): [{0}] and f(x2): [{1}]", fx1, fx2);
            xm = 0;
            for (int i = 0; i < 100; i++)
            {
                xm = (x1 + x2) / 2;
                if (f(x1) * f(xm) < 0)
                { x2 = xm; }
                else
                {x1 = xm;}
                Console.Write("i:", i);
                Console.Write("x1: [{0}] and x2: [{1}]", x1, x2);
                Console.WriteLine("f(x1): [{0}] and f(x2): [{1}]", fx1, fx2);

                

            }

            Console.WriteLine("xm =: {0}", xm);
            Console.WriteLine("f(xm)=: {0}", f(xm));
            Console.ReadLine();
            

        }

        static double f(double x)
        {
            return Math.Pow(Math.E, -x) - x;
        }
    }
}
