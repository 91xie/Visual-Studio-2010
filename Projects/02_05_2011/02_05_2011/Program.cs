using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_05_2011
{
    class Program
    {
        static void Main(string[] args)
        {
            //test valves

            List<ConstantValve> ListofValves = new List<ConstantValve>();
            ListofValves.Add(new ConstantValve("add", true, 1));

            Console.Write(ListofValves[0]);
            Console.ReadLine();

            

        }

        
    }

   

    
}
