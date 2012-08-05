using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Lab6
{
    class Program
    {
        static void Main(string[] args)
        {//requires a 1D array
            double[] a = new double[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(Mean(a));
            Console.ReadLine();
        }

        static double Mean(double[] a)
        {
            double sumxi = 0;
            foreach (double x in a)
            { sumxi += x; }
            double n = a.Count();
            return (1 / n) * (sumxi);
        }

        static double StdDev(double [] a)
        {
            double mu = Mean(a);
            double sumofximu_2 = 0;
            foreach (double x in a)
            {
                sumofximu_2 += Math.Pow((x - mu), 2);
            }
            double n = a.Count();
            return Math.Pow((1 / n) * sumofximu_2, 0.5);

        }

        static double Skewness(double[] a)
        {
            double n = a.Count(), mu = Mean(a), sig = StdDev(a);
            double sumofximu_3 = 0;
            foreach (double x in a)
            {
                sumofximu_3 += Math.Pow((x - mu), 3);
            }

            return (1 / (mu * sig * sig * sig)) * sumofximu_3;
        }
        
    }
}
