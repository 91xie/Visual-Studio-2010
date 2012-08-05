using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vector3DTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D a = new Vector3D(1, 2, 3);
            Console.WriteLine("a " + a);
            Vector3D b = new Vector3D();

            b.x = 2; b.y=3; b.z =4;


            Console.WriteLine("b " + b);
            Console.WriteLine("|b| " + b.Magnitude());

            a.Scaleby(3);
            Console.WriteLine("a" + a);
            Console.WriteLine("a . b = " + a.DotProduct(b));
            

            //Quit sequence
            Console.Write("Press Enter to Quit...");
                Console.ReadLine();

        }

        struct Vector3D
        {
            public double x, y, z;

            public Vector3D(double x, double y, double z)//constructor
                //^ brackets define arguments/parameters
                
            {
                this.x = x; //<assigns the value z as highlighted above as x for the struct
                this.y = y;
                this.z = z;

            }

            public Vector3D (Vector3D a)//alternative way of setting up values of x, y and z
            {
                x = a.x;
                y = a.y;
                z = a.z;

            }

            public void Scaleby(double factor) //void doesn't return a value // double factor highlights number which you input in brackets
            {
                x *= factor; //takes x and scales it by a factor which is input
                y *= factor;
                z *= factor;


            }

            public double Magnitude() //since there is no number here, you don't need input a number since it is finding the magnitude
            {
                return Math.Sqrt(x * x + y * y + z * z);

            }

            public double DotProduct(Vector3D b) //takes a vector3D and multiplies it by another vector 3D
                //the vector3d which it takes in the brackets would be renamed b for this struct and does the following functions on it.
            {
                return x * b.x + y * b.y + z * b.z;

            }



            public override string ToString()
            {
                return "(" + x + "," + y + "," + z + ")";
            }












        }
    }
}
