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
            Console.WriteLine("Input factorial calculation");

            int fstarter = 5;
            
            int f = fstarter;
            int checker = fstarter - 1;
            while (checker >0)
            {
                f *= checker;
                checker--;
            }
            Console.WriteLine("fstarter {0}! factorial {1}", fstarter, f);

            Console.ReadLine();
        }
    }
}
