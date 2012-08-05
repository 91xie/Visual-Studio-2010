using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mockexam2011
{
    class Program
    {
        static void Main(string[] args)
        {
            //array
            double [,] array1 = new double [,]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };


            //columns depends on size b, rows depend on size a.

            double [] a = new double []{1,2,3,4,5,6};
            double [] b = new double []{1,2,3,4,5,6};

            double[,] c = new double[a.Count(), b.Count()];


            //a.outerproduct.b
            //



            matrixstring(array1);


            Console.WriteLine(matrixToString(array1));

            Console.WriteLine(matrixToString(outerproduct(a, b)));
            Console.ReadLine();
        }
        //void method.

        static double[,] outerproduct(double[] a, double[] b)
        {
            double[,] c = new double[a.Count(), b.Count()];

            //columns first and then rows.
            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer < a.Count())
            {
                while (columnincrementer < b.Count())
                {
                    c[rowincrementer, columnincrementer] = a[rowincrementer] * b[columnincrementer];
                    columnincrementer++;
                }
                columnincrementer = 0;
                rowincrementer++;
            }

            return c;
        }

        static void matrixstring(double[,] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            
            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer <= a.GetUpperBound(0))
            {
                while (columnincrementer <= a.GetUpperBound(1))
                {
                    Console.Write(a[rowincrementer, columnincrementer]);
                    columnincrementer++;
                }
                columnincrementer = 0;
                Console.WriteLine();
                rowincrementer++;
            }


            
        }

        static string matrixToString(double[,] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();

            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer <= a.GetUpperBound(0))
            {
                while (columnincrementer <= a.GetUpperBound(1))
                {
                    s.Write("{0,3}" ,a[rowincrementer, columnincrementer]);
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
