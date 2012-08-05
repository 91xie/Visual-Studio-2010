using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Exercise1a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x= ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y= ");
            double y = double.Parse(Console.ReadLine());

            double fxy = (3*Math.Sqrt(x/y)*((Math.Pow(x,3)*y+3*(x*y*y - 10* Math.Pow((Math.Pow(y,1/3)),4)))/(1-(4*x*y - 5)/(x*x))));
            Console.WriteLine("fxy = {0}",fxy);
            Console.ReadLine();


        }
    }
}
