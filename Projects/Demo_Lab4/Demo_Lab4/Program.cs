using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("{0,5}", "y:");
            for (int no = 0; no <= 10; no++) { Console.Write("{0,5}", no); }
            Console.WriteLine();
            for (int x = 0; x <= 10; x++)
            {
                Console.Write("x: {0,2}",x);
                for (int y = 0; y <= 10; y++)
                {
                    
                    double z = x * x + y * y - x * y;
                    Console.Write("{0,5}",z);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
