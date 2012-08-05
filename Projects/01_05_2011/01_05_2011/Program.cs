using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_05_2011
{
    class Program
    {
        static void Main(string[] args)
        {
            //write a program that could create a load of vector3D objects
            List<Vector3D> Vector3DList = new List<Vector3D>();

            //loop

            Console.WriteLine("Vector3D");
            string selectionstring = "1. Create New Vector3D 2. View 3. Methods 4. Exit";
            Console.WriteLine(selectionstring);
            int selector = int.Parse(Console.ReadLine());
            while (selector != 4)
            {
                while (selector < 1 || selector > 4)
                {
                    Console.WriteLine(selectionstring);
                    selector = int.Parse(Console.ReadLine());
                }

                if (selector == 1){CreateNewVector3D(Vector3DList);}


                if (selector == 2){ViewAll(Vector3DList);}

                if (selector == 3)
                {
                    Console.WriteLine("Select Method");
                    Console.WriteLine("1. + 2. - 3. Dot 4. Cross 5. NormalVector");

                    Console.WriteLine("Select Vector Index"); ViewAll(Vector3DList);
                    Console.Write("Select Vector"); int vectorselector1 = int.Parse(Console.ReadLine());
                    while (vectorselector1 > Vector3DList.Count() || vectorselector1 <0)
                    {Console.Write("Select Vector");vectorselector1 = int.Parse(Console.ReadLine());}
                    
                }


                Console.WriteLine(selectionstring);
                selector = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("press enter to quit");
            Console.ReadLine();

        }


        static void CreateNewVector3D(List<Vector3D> a)
        {
            Console.WriteLine("You have selected create new vector3D");
            double x, y, z;
            Console.Write("x= "); x = double.Parse(Console.ReadLine());
            Console.Write("y= "); y = double.Parse(Console.ReadLine());
            Console.Write("z= "); z = double.Parse(Console.ReadLine());
            Vector3D w = new Vector3D(x, y, z);
            a.Add(w);
            Console.WriteLine(w);
        }
        static void ViewAll(List<Vector3D> a)
        {
            int i = 0;
            while (i < a.Count())
            { Console.WriteLine("{0}. {1}", i, a[i]); i++; }
        }
    }

    class Vector3D
    {
        public double x, y, z;

        public Vector3D(double x, double y, double z)
        { this.x = x; this.y = y; this.z = z; }

        public Vector3D(Vector3D a)
        { x = a.x; y = a.y; z = a.z; }

        public Vector3D()
        { this.x = 0; this.y = 0; this.z = 0; }

        public Vector3D(double[] a)
        { x = a[0]; y = a[1]; z = a[2]; }

        

        public Vector3D Add(Vector3D a)
        {return new Vector3D(x + a.x, y + a.y, z + a.z);}

        public Vector3D Sub(Vector3D a)
        { return new Vector3D(x - a.x, y -a.y, z - a.z); }

        public double Dot(Vector3D a)
        { return x * a.x + y * a.y + z * a.z; }

        public Vector3D Cross(Vector3D a)
        { return new Vector3D(y * a.z - z * a.y, z * a.x - x * a.z, x * a.y - y * a.x); }



        public double Argument()
        { return Math.Sqrt(x * x + y * y + z * z); }

        public Vector3D UnitVector()
        { return new Vector3D(x / this.Argument(), y / this.Argument(), z / this.Argument()); }

        public Vector3D ScaleBy(double Scale)
        { return new Vector3D(x * Scale, y * Scale, z * Scale); }

        public Vector3D UnitNormalVector(Vector3D a)
        { return new Vector3D (this.Cross(a)).UnitVector(); }

        public override string ToString()
        { string s = string.Format("({0},{1},{2})", x, y, z); return s; }



    }

    class ComplexNo
    {
    }

}
