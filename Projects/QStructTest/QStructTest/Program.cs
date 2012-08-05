using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QStructTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Q Struct Test");


            //take value b, and write a struct to compute q from given value b
            //from that, take value a and compute the value for q fixing the other values,
            //basically... you need to put in three variables into the same struct
            //OR write three different structs taking each variable as you need to assign different values each time
            //Consider Option 1 first.
            //Also write an algorithm for computing by brute force method.
            //Also consider using increasing and decreasing "hill approach" as suggested.
            //In terms of going back to partial derivation, taking small increments of dx, dy

            double b1, h, a;
            b1 = 4.5;
            h = 1.571;
            a = 1.4;

            qstruct Q = new qstruct(b1, h, a);
            Console.Write("Struct Q value");
            Console.WriteLine(Q.qstruct_b1_h_a());


            //normal method

            double A, R, P, s, k, g, b2;
            



            g = 9.81;
            s = 0.00125;
            k = 0.015;

            b2 = b1 - ((2 * h) / Math.Tan(a));
            A = 0.5 * (b1 + b2) * h;
            P = b2 + 2 * (h / Math.Sin(a));
            R = A / P;
            double Q1 = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));
            Console.Write("Normal method value of Q = {0}", Q1);
            Console.WriteLine("Normal method of A= {0}", A);

            //</>normal method
            Console.WriteLine("Press Enter to Quit...");
            Console.ReadLine();


        }
        struct qstruct
        {
            public double b1, h, a;

            public qstruct(double b1, double h, double a)
            {
                this.b1 = b1;
                this.h = h;
                this.a = a;

            }

            public qstruct(qstruct x)
            {
                b1 = x.b1;
                h = x.h;
                a = x.a;

            }

            public double qstruct_b1_h_a()
            {
                
                double Q, A, R, P, s, k, g;
                double b2;

                g = 9.81;
                s = 0.00125;
                k = 0.015;

                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                return Q = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));




            }








        }


    }
}
