using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE1005_3D_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D a = new Vector3D();
            Console.WriteLine("a:= " + a);

            a.x = 2; a.y = -4; a.z = 7;
            Console.WriteLine("a:= " + a);
            Vector3D b = new Vector3D(1, 3, -12);//from constructor
            Console.WriteLine("b:= " + b);

            Console.WriteLine("Vector has a magnitude: {0}.", b.Magnitude());

            b.ScaleBy(3);
            Console.WriteLine("b:= " + b);

            Console.WriteLine("Vector has a magnitude: {0}.", b.Magnitude());

            double dp = a.DotProduct(b);

            Console.WriteLine("A.b:= {0}.", dp);

            dp = a.DotProduct(a);

            Vector3D c = a.CrossProduct(b);
            Console.WriteLine("a x b = " + c);
            Console.WriteLine("a x a = " + a.CrossProduct(a));
            Console.WriteLine(a);
            Console.WriteLine(b.ToString());


            Vector3D x = new Vector3D(1, 2, 3);
            Console.Write("Press Enter to Quit...");
            Console.ReadLine();


        }
    }

    struct Vector3D
    {
        public double x, y, z;


        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D(Vector3D a)
        {
            x = a.x;
            y = a.y;
            z = a.z;
        }

        public void ScaleBy(double factor)
        {
            x *= factor;
            y *= factor;
            z *= factor;
        }

        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public double DotProduct(Vector3D b)
        { return x * b.x + y * b.y + z * b.z; }


        public Vector3D CrossProduct(Vector3D b)
        {
            Vector3D ans;
            ans.x = y * b.z - z * b.y;
            ans.y = z * b.x - x * b.z;
            ans.z = x * b.y - y * b.x;
            return ans;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

    }

}
