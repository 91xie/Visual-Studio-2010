using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsAssignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Physics Assignment 4 Q2");
            Console.WriteLine();

            double V, R_1, R_2, R_3, R_4, G_1, G_2, G_3, G_4, e_1, e_2;
            //w = 2, x = 3, y = 2, z = 9
            
            V = 29;
            R_1 = 2.2;
            R_2 = 3.3;
            R_3 = 1.2;
            R_4 = 4;
            G_1 = 1 / R_1;
            G_2 = 1 / R_2;
            G_3 = 1 / R_3;
            G_4 = 1 / R_4;
            Console.WriteLine("V= " + V);
            Console.WriteLine("R_1=" + R_1);
            Console.WriteLine("R_2=" + R_2);
            Console.WriteLine("R_3=" + R_3);
            Console.WriteLine("R_4=" + R_4);
            Console.WriteLine("G_1=" + G_2);
            Console.WriteLine("G_2=" + G_2);
            Console.WriteLine("G_3=" + G_3);
            Console.WriteLine("G_4=" + G_4);

            double a1, a2, b1, b2, c1, c2, co, d1, d2;
            Console.WriteLine("a1x + b1y = c1");
            Console.WriteLine("a2x + b2y = c2");
            a1 = G_1 + G_2 + G_3;
            b1 = -1*(G_2 + G_3);
            c1 = V*G_1;
            a2 = G_2 + G_3;
            b2 = -1*(G_2 + G_3 + G_4);
            c2 = 0;
            
            double det = a1 * b2 - b1 * a1;
            e_1 = (c1 * b2 - c2 * b1) / det;
            e_2 = (a1 * c2 - a2 * c1) / det;
            
            Console.WriteLine("e_1 = " + e_1);
            Console.WriteLine("e_2 = " + e_2);

            Console.WriteLine("Press Enter to Quit...");
            Console.ReadLine();
           


        }
    }
}
