using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE1005_ArgumentPassing
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            * Argument Passing
            * 1. value type variabels
            * 2. reference type variables
            * 
            * by value passing
            * by reference passing
            * 
            * void m1 (int a) {...}
            * void m2 (ref int a) {...}
            * 
            * what's the difference between the two.
            * 1st one won't change the value of a
            * the second method one would.
            * 
            */

            MyStruct a = new MyStruct();


            int n = 4;
            Console.WriteLine("Before M1 call n = {0}", n);
            a.M1(n);
            Console.WriteLine(" After M1 call n = {0}", n);
            Console.WriteLine();

            Console.WriteLine("Before M2 call n = {0}", n);
            a.M2(ref n);
            Console.WriteLine(" After M2 call n = {0}", n);
            Console.WriteLine();

            int m = 3;
            Console.WriteLine("Before M3 call m = {0}", m);
            a.M3(out m);
            Console.WriteLine(" After M2 call m = {0}", m);

            Console.WriteLine();
            Console.WriteLine();

            int r;
            int i = 16, j = 4;
            int k = Math.DivRem(i, j, out r);

            Console.WriteLine("{0}/{1} = {2} remainder {3}", i, j, k, r);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(a.myM());
            Console.WriteLine(a.myM(3));
            Console.WriteLine(a.myM(3.2));
            Console.WriteLine(a.myM(4, -2));

            Console.WriteLine();
            Console.WriteLine();


            Console.ReadLine();
        }
    }


    struct MyStruct
    {

        public void M1(int a) { a *= 2; }//values here don't change, copies the value and works with it
        public void M2(ref int a) { a *= 2; } //refers to a but it DOES change the value of a when you are working with it.
        //if a=4, after M2, a=8
        //like two way traffic. return a new value and change the value that you put going into it.
        public void M3(out int a) { int b = 5; a = b * 2; }//doesn't matter what goes in.
        

        public int myM() { return 2; }
        public int myM(int i) { return i * 2; }
        public double myM(double i) { return i * 3; }
        public int myM(int i, int j) { return i * j; }
        //public double myM ( ) { return 2; }
        public double myM(double i, int j) { return i * j; }
        public double myM(int i, double j) { return i * j; }

    }
}
