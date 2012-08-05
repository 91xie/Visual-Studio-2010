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
            Console.WriteLine ("StructsLectureTest2 Date: 03/02/2011");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");



            int r;
            int i = 18, j = 4;
            int k = Math.DivRem(i, j, out r);
            Console.WriteLine("{0}/{1} = {2} remainder {3}", i, j, k, r); //Console writes i/j = k remainder r

            //Method Overloading Page 28
            //Several versions of the same method may exist ie more than one themod with the samee identifier.
            //they are distinguished by the number and or type of arguments in the argument list
            // - the method's signature
            //void m1 () {}

            //allow you declare several different methods with the same name but differs by its signature.
            //if the signature is idfferent, the program knows which of method to call depending on the viarable which are pased to it.
            // eg. void m1 (){..}
            // void m1 (int i) {...}
            //notice that that the second method is different.
            //defined by the no of parameters and the types of parameters.
            //basically different versions of the same method.
            //as long as it can uniquely identify the different parameters, it will work.
            
            
            

            MyStruct a = new MyStruct();


            Console.WriteLine(a.myM());
            Console.WriteLine(a.myM(3));
            Console.WriteLine(a.myM(3.2));

            //strut Constructors - Introduction
            //structs, being value types, may be declared and the fields can be accessed without any explicit instantiaon being carried out.
            //compare with the creation of a rnado object in the 2nd section had to use the new keyword.
            //all fields in a struct object have to be initalised before they are accessed.
            //this is done in one of two ways:
            //-use the new keyword
            //-intialise each field after declaring the object.
            //see following examples

            //new keyword, sets all fields to default values.
            // or give themvalues explicity.

            //Constructors
            //declared by your method. it is like a method but not quite a method.
            //because it is like a method, it takes parameters and needs parameters.
            //constructor for vector.
            //problem ,i want to create a new vector and be able to give it new starting values.
            //and not type a.x =, a.y = etc.

            Vector3D a;
            a.x = 1;
            a.y = 2;
            a.z = 3; 
            Console.WriteLine("a:=" + a);
            
            


            //Excersize: develop a struct called "ComplexNo" to encapsulate all the functionality of a complex number
            //Functionality: addition, multiplication, conjugate
            

        }

        struct MyStruct
        {
            public void M1(int a) { a *= 2; }
            public void M2(ref int a) { a *= 2; }
            public void M3 (out int a) {int b = 5; a = b*2;}

            //Method overload pg 28
            public int myM () { return 2;}
            public int myM (int i) { return i *2;}
            public int myM (double i) { return (int)i * 3;} // can cast, pass it a double and get an int out. or turn a double into an int
            public int myM (int i, int j) {return i*j;}
            
            
        
        
        }

        struct myStruct // page 30 
        {
            public int a, b;
            public override string ToString() { return a + "&" + b; }
        }

        struct Vector3D
        {

            public double x, y, z;
            public Vector3D (double a, double b, double c)
            {x =a; y=b; z=c;}

            public Vector3D (Vector3D a)
            {
                x= a.x;
                y = a.y;
                z =a.z;


            }



        }













    }

    }

