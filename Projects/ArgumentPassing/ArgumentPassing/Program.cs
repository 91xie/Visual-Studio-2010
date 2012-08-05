using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgumentPassing
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
             * 1st one changes the value of a
             * the second method one won't
             * 
             */

            int[] n = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("the array n:");
            
            TestPassing.printArray(n);
            TestPassing.M4(n);
            
            Console.WriteLine("the array n:");
            TestPassing.printArray(n);


            Console.WriteLine("the array n:");

            TestPassing.printArray(n);
            TestPassing.M5(ref n); // you explicity use ref so you know that this object can be deleted or changed.

            Console.WriteLine("the array n:");
            TestPassing.printArray(n);

            Console.ReadLine();
            
        }
    }

    class TestPassing
    {
        public static void M4(int[] a) //this is a by value call. but the values are changed regardless because arrays are reference.
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= 2;
            a = null;  //if you are not protecting the values, you are protecting the memory locations.
            //you could still print out a again. the values are changed but a is still protected. the very fact that you can still print this out proves this.


        }

        public static void M5(ref int[] a) //this is a by value call. but the values are changed regardless because arrays are reference.
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= 2;
            a = null;  

        } //from m5 you could return a new array.

        //here a copies the reference from n. whatever gets done to a, it does the same stuff to n.
       
        public static void printArray(int[] a)
        {
            if (a == null)
            { Console.WriteLine("no array sent to method!"); return; }

            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();

        }


    }
}
