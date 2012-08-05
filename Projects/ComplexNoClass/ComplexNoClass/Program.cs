using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ComplexNo Class and Struct");

            ComplexClass a = new ComplexClass(1,2);
            Console.WriteLine("a= {0}", a);
            ComplexClass b = new ComplexClass(3, 4);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("a+b = {0}", a+b);
            
            double w= ComplexClass.ArgumentDegrees(a);
            Console.WriteLine(w);
            Console.ReadLine();
        }
    }
}
