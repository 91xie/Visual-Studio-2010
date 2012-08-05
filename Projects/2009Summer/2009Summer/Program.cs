using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2009Summer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 3, 4, 5 };
            Console.WriteLine(DotProduct(a, b));
            Console.ReadLine();

        }

        static double DotProduct (int [] a, int [] b)
        {//note this program doesn't really deal with arrays which are of different lengths. you could try some fail safe thing for it. like RETURNing the answer as infinitiy or something IF the lengths aren't equal.
            double answer = 0;
            for (int i = 0; i < a.Count(); i++)
            {answer += a[i]*b[i]; }
            return answer;

        }

    }

}
