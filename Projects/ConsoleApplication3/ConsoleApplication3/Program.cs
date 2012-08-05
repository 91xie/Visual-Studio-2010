using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D a = new Vector3D(1, 3, 8);
            Vector3D b = new Vector3D();
            Console.WriteLine("1"+"2"+"3");
            
        }

        static double f(double x)
        { 
            double _x = x;
            double answer = _x * _x - 3 * _x;
            return answer;
        }
    }

    class Vector3D
    {
        public double x, y, z;

        public Vector3D(double x, double y, double z)//
        { this.x = x; this.y = y; this.z = z; }

        public Vector3D()
        { this.x = 0; this.y = 0; this.z = 0; }
        
        public Vector3D(double [] a)
        {this.x = a[0]; this.y = a[1]; this.z = a[2];}

        public Vector3D(Vector3D a)
        { this.x = a.x; this.y = a.y; this.z = a.z; }


        public double Magnitude(Vector3D a)
        {
            double x, y, z;
            x = a.x; y = a.y; z = a.z;
            return Math.Sqrt(x * x + y * y + z * z);
        }


        public override string ToString()
        {

            return "(" + x + "," + y + "," + z +")";
        }

    }
}
