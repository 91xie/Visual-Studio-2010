using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_05_11_Lecture
{
    class Program
    {
        static void Main(string[] args)
        {

            double[,] array = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double[] array3 = new double[] { 1, 2, 3 };
            
            Console.WriteLine(array[0, 2]);
            Console.WriteLine(array[2, 0]);
            Console.WriteLine(array3.GetUpperBound(0));
            

            Console.WriteLine(DotProduct(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }));
            Console.ReadLine();

            Console.Write(Math.Exp(1));
        }

        static double[,] OuterProduct(double[] a, double[] b)
        {
            int n = a.GetUpperBound(0); int m = b.GetUpperBound(0);
            double[,] C = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C[i, j] = a[i] * b[j];
                }
            }

            return C;
        }

        static double DotProduct(double[] a, double[] b)
        {
            
            if (a.Length != b.Length)
            {
                Console.WriteLine("Error");
                return 0;
            }
            
            double sum =0;
            for (int i = 0; i < a.Length ; i++)
            {
                sum += a[i] * b[i];
            }
            return sum;
            

        }
    }

    
    


}
