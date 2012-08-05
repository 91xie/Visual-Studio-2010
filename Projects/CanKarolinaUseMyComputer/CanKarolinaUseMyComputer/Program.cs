using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanKarolinaUseMyComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Can Karolina use my computer?");
            Console.WriteLine("Press Enter for answer. . . ");
            Console.ReadLine();

            Random randomgen = new Random();

            for (; ; )
            {
                double i = randomgen.NextDouble();

                if (i < 0.5)

                { Console.WriteLine("NO!!! :P"); Console.WriteLine("Try Again"); Console.ReadLine(); }
                else
                {
                    Console.WriteLine("YES!! :D"); Console.ReadLine();
                    return;

                }
            }


            Console.ReadLine();
        }
    }
}
