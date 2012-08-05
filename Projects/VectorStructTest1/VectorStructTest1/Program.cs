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
            Vector3D a, b;
            Console.WriteLine("Vector3D struct");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Input Value a.x");
            a.x = double.Parse(Console.ReadLine());
            Console.Write("Input Value a.y");
            a.y = double.Parse(Console.ReadLine());
            Console.Write("Input Value a.z");
            a.z = double.Parse(Console.ReadLine());

            Console.Write("Input Value b.x");
            b.x = double.Parse(Console.ReadLine());
            Console.Write("Input Value b.y");
            b.y = double.Parse(Console.ReadLine());
            Console.Write("Input Value b.z");
            b.z = double.Parse(Console.ReadLine());

            Vector3D z;
            Console.Write("Scale by?  ");
            double factor = double.Parse(Console.ReadLine());

            z = a.ScaleBy(factor);
            Console.WriteLine("a" + a);
            Console.WriteLine("z" + z);


        }

        struct Vector3D
        {
            public double x, y, z;
           
            public Vector3D ScaleBy (double factor)
            {
                Vector3D a;
                a.x *= factor;
                a.y *= factor;
                a.z *= factor;
                return a;
                
                
            }








        }
    }
}
