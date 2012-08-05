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
            Console.WriteLine("Multiple Variable Loop Test");
            //Basic Bisection Method First.
            //http://www.c-sharpcorner.com/UploadFile/mahesh/RandomNumber11232005010428AM/RandomNumber.aspx
            double f_x1, f_x2, x_1, x_2, m, mi, delta_m, f_m;
            int w, o;
            w = 1;
            o = 0;

            do
            {




                x_1 = w;
                Console.Write("Input x_1= {0}", x_1);
                x_2 = o;
                Console.Write("Input x_2= {0}", x_2 );
                
                f_x1 = Math.Exp(-x_1) - x_1;
                f_x2 = Math.Exp(-x_2) - x_2;
                Console.WriteLine("f_x1=" + f_x1);
                Console.WriteLine("f_x2=" + f_x2);
                w++;
                o--;

            } while (f_x1 * f_x2 > 0 && f_x1 * f_x2 != 0);

            x_1 = w;
            x_2 = o;

            Console.WriteLine("");
            Console.WriteLine("Two valid roots are available, Press Enter to Continue . . .");
            Console.ReadLine();

            int i;
            i = 0;
            m = (x_1 + x_2) / 2;

            do
            {

                i++;
                Console.Write("Run No." + i);
                f_x1 = Math.Exp(-x_1) - x_1;
                f_x2 = Math.Exp(-x_2) - x_2;
                f_m = Math.Exp(-m) - m;

                if (f_m * f_x1 < 0)
                {
                    x_2 = m;
                    mi = m;
                }
                else if (f_m * f_x2 < 0)
                {
                    x_1 = m;
                    mi = m;
                }
                else if (f_m * f_x2 == 0 || f_m * f_x1 == 0)
                {
                    Console.WriteLine("Break");
                    break;
                }
                Console.WriteLine("m=" + m);
                m = (x_1 + x_2) / 2;

            } while (i < 100);
            Console.Write("Press Enter to Continue");
            Console.ReadLine();


        }
    }
}
