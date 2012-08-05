using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureProgrammeClasses
{
    class Vector3D
    {
        public double x, y, z;
        //constructors
        public Vector3D() { x = 0; y = 0; z = 0; } //default constructors when put nothing into the argument.

        public Vector3D(double x, double y, double z)
        {   
        
        this.x = x;
        this.y = y;
        this.z = z;
        
        }

        public Vector3D(Vector3D a)
        { x = a.x; y = a.y; z = a.z; }
        //</constructors>


        //instance method
        public double DotProduct(Vector3D a) { return a.x * x + a.y * y + a.z * z; }
        public Vector3D CrossProduct(Vector3D b)
        {
            double p = y * b.z - z * b.y;
            double q = y * b.x - x * b.z;
            double r = x * b.y - y * b.x;
            return new Vector3D(p, q, r);
        }
        
        //static method
        public static double DotProduct(Vector3D a, Vector3D b) { return a.DotProduct(b); }
        public static Vector3D CrossProduct(Vector3D a, Vector3D b) { return a.CrossProduct(b); }

        //overloaded operators
        public static Vector3D operator + (Vector3D a, Vector3D b) //operator override.
            //the order of the arguments matter.
        {
            return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z); //note the word "new"
        }

        public static Vector3D operator - (Vector3D a, Vector3D b)
        {
            return new Vector3D(a.x - b.y, a.y - b.y, a.z - b.z);
        }

        public static Vector3D operator * (Vector3D a, double scale)
        {
            return new Vector3D(a.x * scale, a.y * scale, a.z * scale);
        }


        //overriding tostring method.
        public override string ToString()
        {
                return "(" + x + "," + y + "," + z + ")";
        }

        //destructor
        ~Vector3D() { Console.WriteLine("Vector3D object finally deleted"); } // "~" defines destructor
        //dont' ever need to create a destructors..


    }
}
//as you can see, this is like the struct.
//take everything that we have learned in structs
//if you are creating or instiating a new object, you have to use the word "new"