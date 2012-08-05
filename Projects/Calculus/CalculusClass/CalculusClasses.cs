using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculusClasses
{
    public class Calculus
    {//call solution a different name.
        //object browser allows you to see what dll files have been added.
        //prototype of a funciton

        static double dx = 0.000001;
        public delegate double theFunction(double x);

        public theFunction f;
        //the function is like a 

        public double FirstDerivative(double x)
        {
            double f1 = f(x + dx);
            double f0 = f(x - dx);

            return (f1 - f0) / (2*dx);
        }

        public double SecondDerivative(double x)
        {
            return (FirstDerivative(x+dx) - FirstDerivative(x-dx))/(2*dx);
        }

        public static double FirstDerivative(theFunction f, double x)
        {
            return (f(x + dx) - f(x - dx)) / (2 * dx);
        }
    }
}
