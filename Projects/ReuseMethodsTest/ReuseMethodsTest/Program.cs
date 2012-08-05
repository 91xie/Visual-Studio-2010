using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReuseMethodsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get values from other methods");
            testclass a = new testclass(1, 2, 3);
            Console.WriteLine(a);

            Console.ReadLine();
             

        }
    }
}
