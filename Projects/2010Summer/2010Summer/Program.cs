using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2010Summer
{
    class Program
    {
        static void Main(string[] args)
        {/*Question 1
Write a VB.NET procedure called “VectorsIdentical” that accepts two 1-D arrays of integers, compares them and returns a true or false result depending whether they are identical to each other or not.
Note: Vectors are identical if:
they have the same number of components;
each corresponding component pairs have identical values.*/

            int [] a = new int []{4,7,8};
            int[] b = new int[] { 4, 7, 8,7 };

            if (VectorsIdentical(a, b) == true)
            { Console.WriteLine("true"); }
            else { Console.WriteLine("false"); }

            Console.ReadLine();
        }

        static bool VectorsIdentical(int[] a, int[] b)
            //1. for this method, you need to return a bool (either true or false) which is why you write "bool" in the above the line. VectorIdentical is the name of the method static means that the method is first made when the program loads up.*
        {
            
            if (a.Count() != b.Count()){ return false; } //this is the first check to see if they are the same length.
                //the keyword "return" means that it would return that value and it would jump and skip everything else in the method and exit out of it.
            else//this is the 2nd check to see if all the components are equal
            {
                for (int i = 0; i < a.Count(); i++)
                {if (a[i] != b[i]) { return false; }}
            }

            return true;
        }
        

    }
}
