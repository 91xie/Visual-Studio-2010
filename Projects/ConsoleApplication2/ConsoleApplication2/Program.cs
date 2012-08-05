using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //everything in static void main is just me testing the thing out...
            double[,] a = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine(_2Darrayprintout(a));

            double [,] b = Outerproduct(new double[] { 1, 2, 3 }, new double[] { 1, 2 });
            Console.WriteLine(_2Darrayprintout(b));
            Console.ReadLine();
        }


        //this is only a method to print out the array to see what it looks like
        static string _2Darrayprintout(double[,] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            for (int i = 0; i <= a.GetUpperBound(0); i++ )
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    s.Write("{0} ,", a[i, j]);
                }
                s.WriteLine();
            }

            return s.ToString();
        }

        
        static double[,] Outerproduct(double[] a, double[] b)//this is the actual solution...
            //algorithm...
            //work across the row (horizontal) by incrementing j and keeping i constant.
            //when you reach the end of the row (the size of which governed by b.Length)
            //then jump onto the next line with the console.writeline()
            //then increment i++ to move down to the next row - work across the row (horizontal) by incrementing... etc. etc...
            //keep looping until you get down to the bottom row.
        
        {
            double[,] answer = new double[a.Length, b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    answer[i, j] = a[i] * b[j];
                }
            }

            return answer;
        
        }


    }
}
