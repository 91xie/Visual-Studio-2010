using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Random myR = new Random();
            double[,] A, B;
            Console.Write("Enter no rows in A: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter no cols in A: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter no cols in B: ");
            int m = int.Parse(Console.ReadLine());

            int i, j;
            

            for (i = 0; i <= n; i++)
            {
                for (j = 0; j < p; j++)
                    A[i, j] = myR.NextDouble() * 10;

            }

                for (i = 0; i < p; i++)
                {
                    for (j = 0; j < m; j++)
                        B[i, j] = myR.NextDouble() * 10;
                }




                double[,] C = MultMat(A,B);
            

        }
        /*
        static void PrintArray(double[,] A)
        {
            for ( int i 
        };
        */

        static double[,] MultMat(double[,] A, double[,] B)
        {
            int p = A.GetUpperBound(1); //get the max no. of columns
                int q = B.GetUpperBound(0);
            if (p != q) return null;

            int n = A.GetUpperBound(0); //highest index of rows of A.
            int m = B.GetUpperBound(1); //highest index of columns of B.

            double[,] C = new double[n + 1, m + 1]; //make sure that your out put matrix is big enough.

            for (int i = 0; i<= n ; i++) //run until i reaches the no or rows available...
            {
                for ( int j = 0; j <= m ; j ++)//run until j gets to the end of the column of B.
                {
                    C[i,j] = 0 ;//this only deals with the position
                    for ( int k = 0 ; k <= p ; k ++)
                       C[i,j] += A[i,k]*B[k,j]; //notice outside indexs of A and B. while value of k is the same.
                    //value k is never incremented and never goes over p, p being the the max no of columsn of A.
                }
            }

            return C;
        }
    }
}
