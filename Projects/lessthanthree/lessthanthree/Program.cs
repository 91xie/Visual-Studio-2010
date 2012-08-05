using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lessthanthree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("Insert Big Postive No.");

            int lovecounter = int.Parse(Console.ReadLine());
            for (int i = 0; i < lovecounter; i++)
            { Console.Write("<3"); }
            //or I could put it on an infinite loop so the love is infinite too.
            Console.ReadLine();
        }
    }
}
