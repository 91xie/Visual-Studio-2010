using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1PartBDraft1
{
    class Program
    {
        static void Main(string[] args)
        {
            double f_x1, f_x2, x_1, m, mi, delta_m, f_m;

            double Q, A, R, P, s, k, g, delta_h, a, delta_a, h_min, h_lim, a_lim, a_min, B, D, h, b1, b2;
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
            a= 1;//test starting value a
            h=0.2;//test starting value h



            int w, o;
            w = 1;
            o = 0;

            double b1_x1, b1_x2, a_x1, a_x2, h_x1, h_x2;
            double q_bx1, q_bx2, q_bxm;
            do
            {
                




                b1_x1 = w;
                Console.Write("Input x_1= {0}", b1_x1);


                b1 = b1_x1;
                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                q_bx1 = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));

                
                b1_x2 = o;
                Console.Write("Input b1_x2= {0}", b1_x2);


                b1 = b1_x2;
                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                q_bx2 = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));




                
                Console.WriteLine("q_bx1=" + q_bx1);
                Console.WriteLine("q_bx2=" + q_bx2);
                w++;
                o--;

            } while (q_bx1 * q_bx2 < 0 && q_bx1 * q_bx2 != 0);

            b1_x1 = w;
            b1_x2 = o;

            Console.WriteLine("");
            Console.WriteLine("Two valid roots are available, Press Enter to Continue . . .");
            Console.ReadLine();



            int i = 0;
            do{
                
                i++;
                Console.WriteLine("Run No." + i);

                b1 = b1_x1;
                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                q_bx1 = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));



                b1 = b1_x2;
                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                q_bx2 = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));


                double b1_xm = (b1_x1 + b1_x2) / 2;

                b1 = b1_x2;
                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                q_bxm = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));


                if (q_bxm * q_bx1 < 0)
                {
                    b1_x2 = b1_xm;
                    mi = b1_xm;
                }
                else if (q_bxm * q_bx2 < 0)
                {
                    b1_x1 = b1_xm;
                    mi = b1_xm;
                }
                else if (q_bxm * q_bx2 == 0 || q_bxm * q_bx1 == 0)
                {
                    Console.WriteLine("Break");
                    break;
                }
                Console.WriteLine("m=" + b1_xm);
                b1_xm = (b1_x1 + b1_x2) / 2;

            } while (i < 100);
            Console.Write("Press Enter to Continue");
            Console.ReadLine();


        }
    }
}
