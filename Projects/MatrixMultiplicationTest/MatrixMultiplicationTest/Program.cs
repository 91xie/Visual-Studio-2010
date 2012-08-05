using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixMultiplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //matrix multiplication test...
            //dot product between columns of one matrix and the column of the other.

            double [,] a = new double [,] {{2,3,4},{6,7,8}};
            double [,] b = new double [,] {{3,3},{4,5},{6,7}};
            double[,] c = new double[,] { };
            //result should be {55,64},{94,109}

            Console.WriteLine(matrixToString(a));
            Console.WriteLine(matrixToString(b));
            c = MatrixMultiplication(a, b);
            Console.WriteLine(matrixToString(c));
            Console.ReadLine();
        }

        static double[,] MatrixMultiplication(double[,] a, double[,] b)
        {

            
            if (a.GetUpperBound(0) != b.GetUpperBound(1))
            { Console.WriteLine("Not of right format"); 
                //probably a more efficient way of doing it instead of creating a new one for the sake of deleting.
                return null; }
            int n = a.GetUpperBound(0);
            int m = b.GetUpperBound(1);
            double[,] c = new double[n +1 ,m +1 ];
            

            //fix first row of a, increment column of a. fix first column, multiply through rows, the increment columns.
            int arow = 0, acolumn = 0, brow = 0, bcolumn = 0;

            int i = 0, j = 0;
            double sum;
            
            sum = 0;


            while ( bcolumn < b.GetUpperBound(1))
            {
            while (arow < a.GetUpperBound(0))
            {
                c[arow, bcolumn] += a[arow, acolumn] * b[brow, bcolumn]; // position of resultant are the outside values.
                acolumn++;
                brow++;

            }
            acolumn = 0;
            brow = 0;
            bcolumn++;
            if (bcolumn == b.GetUpperBound(1))
            { bcolumn = 0; }

                if (arow == a.GetUpperBound(0) && bcolumn == b.GetUpperBound(1))
                {break;}
            }

            /*
             * create all the bits first before getting the sum of all the bits.
             * have a loop with a rolling sum and as soon as you get value. add it to the sum.
             * stop the loop when you reach the size restrictdions
             */

            //inside loop... 
            return c;
        }


        static string matrixToString(double[,] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();

            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer <= a.GetUpperBound(0))
            {
                while (columnincrementer <= a.GetUpperBound(1))
                {
                    s.Write("{0,3}", a[rowincrementer, columnincrementer]);
                    columnincrementer++;
                }
                columnincrementer = 0;
                s.WriteLine();
                rowincrementer++;
            }

            return s.ToString();
        }
    }
}
