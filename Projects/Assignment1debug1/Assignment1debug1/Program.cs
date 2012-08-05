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

            Console.WriteLine("CE1005 - Assignment No.1");
            Console.WriteLine("Name: Patrick Xie");
            Console.WriteLine("ID No: 110352329");
            Console.WriteLine("Course: Energy Eng");
            Console.WriteLine("Date Started: 29-01-11");
            Console.WriteLine("Part A");

            Console.WriteLine("");
            Console.WriteLine("");





            //<Proper Table>

            double Q, A, R, P, s, k, g, delta_h, a, delta_a, h_min, h_lim, a_lim, a_min, B, D, h, b1, b2;
            int i;

            g = 9.81;
            B = 4.5;
            D = 2.0;
            h_lim = D;
            h_min = 0;
            delta_h = D / 10;
            a_lim = (Math.PI) / 2;
            a_min = Math.Atan((2 * D) / B);
            delta_a = ((a_lim - a_min) / 6);
            s = 0.00125;
            k = 0.015;
            h = h_min;
            a_min = Math.Atan((2 * D) / B);
            i = 0;

            //a_counter<>
            double a_counter, a_tan;

            a_counter = a_min;

            Console.Write("a:=        ");
            do
            {

                Console.Write(" |{0,6:F3} ", a_counter);
                a_tan = Math.Tan(a_counter);

                a_counter += delta_a;
            } while (a_counter <= a_lim + 0.0001);


            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------------------");


            h = h + delta_h;
            while (h <= h_lim)
            {


                i++;
                a = a_min;

                Console.WriteLine("h:= {0,4:f1}   ", h);



                do
                {

                    b1 = B + 2 * ((h - D) / Math.Tan(a));
                    b2 = b1 - ((2 * h) / Math.Tan(a));
                    A = 0.5 * (b1 + b2) * h;
                    P = b2 + 2 * (h / Math.Sin(a));
                    R = A / P;
                    Q = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));



                    //Console.Write(Q.ToString("F3") + " ");
                    Console.Write("b1 |{0,6:F3} ", b1); 
                    Console.Write("a |{0,6:F3} ", a);
                    Console.WriteLine(" |{0,6:F3} ", Q);


                    a = a + delta_a;



                }
                while (a <= a_lim + 0.00001);
                h = h + delta_h;

                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------------------------------------");




            }


            Console.WriteLine("");






            //</Proper Table>



            //<Quit>
            Console.WriteLine("Press Enter to Quit");
            Console.ReadLine();



            //</Quit>

        }
    }
}
