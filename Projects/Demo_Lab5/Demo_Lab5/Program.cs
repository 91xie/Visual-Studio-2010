using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            double tol = 0.00000001;
            
            double x = 2;
            double intialx=0, deltax=1000;
            int i = 0;
            string outputstring = "";
            while (Math.Abs(deltax - intialx) > tol) 
                {
                    i++;

                    double f = x - Math.Exp(-x);
                    double f_ = 1 + Math.Exp(-x);
                    intialx = x;
                    x = x - f / f_;
                    deltax = x;
                    outputstring += string.Format("i:{0} x: {1}\n",i,x);

                }

                Console.WriteLine(outputstring);
                Console.WriteLine(x);

                Console.ReadLine();

            
        }

        
    }
}
