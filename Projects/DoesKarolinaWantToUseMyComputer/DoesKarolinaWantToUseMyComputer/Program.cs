using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoesKarolinaWantToUseMyComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Does Karolina want to use my computer?");
            Console.WriteLine("y/n");
            string answer = Console.ReadLine();

            if (answer[0] == 'y')
            { 
                Console.WriteLine("nope, you still can't use it :P HAHA!!");
                Console.WriteLine("Try Again");
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
            
            
            }
            else if (answer[0] == 'n')
            { Console.WriteLine("okay, byebye!!"); Console.ReadLine(); Console.WriteLine("Press Enter to Quit"); }

            Console.WriteLine();

        }
    }
}
