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
            Vector3D b = new Vector3D(1, 3, -12);
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
            Console.WriteLine("a.Add(b)=" + a.Add(b));
            Console.WriteLine("c = a+b {0}", a+b);

            Vector3D x = new Vector3D(1, 2, 3);

           
            //static keyword
            // consider example
            //static allows you access to any element (method, field variable) through the actual type itself.
            //e.g. math.tan(a);
            //or double.Parse;
            a = Vector3D.Add(b, x);
            Console.WriteLine("a:= " + a);
            

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

        public static Vector3D Add(Vector3D a, Vector3D b)
        {
            return a + b;
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


        public Vector3D Add(Vector3D b)
        {
        Vector3D ans;
        ans.x= x + b.x;
        ans.y = y + b.y;
        ans.z = z + b.z;
        return ans;
        }
          

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


        //operator overloading.
        //You can't write down c = a + b when they are defined as vector3D's already.
        //so ye need to override these.
        //e.g c =a/b when they are defined as ints, you can't ints back, eventhough it might not be right (rounding off to the nearest whole number)
        //book, page 48-50
        public static Vector3D operator + (Vector3D a, Vector3D b) //have to declare static
            //order is very important, vector3d is the vector infront of the operate and b after the operator.
        {
            return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z);

        }

        public static Vector3D operator *(double factor, Vector3D b)
        {
            Vector3D ans;
            ans.x = b.x * factor;
            ans.y = b.y* factor;
            ans.z = b.z* factor;
            return ans; //returns magnitude. must be placed in this order "double * Vector3D." it won't work if you don't have the terms in that order.
        }
    }

}
