using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vector3DTest3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Vector3DTest3");
                Vector3D a = new Vector3D(2,3,4);
            Console.WriteLine("a =" + a);
            Console.WriteLine("|a|=");
            Console.WriteLine(a.Magnitude());
            
            
            

            Console.Write("enter to quit");
            Console.ReadLine();
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

            public Vector3D (Vector3D a)
            {
                x=a.x;
                y=a.y;
                z = a.z;

            }

            public void Scaleby (double factor)
        {
            x *= factor;
            y *= factor;
            z *= factor;
            

        }
            public double Magnitude()
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }


            public override string  ToString()
{
 	 return "(" + x +  "," + y + "," + z+ ")";


}
            


        }



    }
}
