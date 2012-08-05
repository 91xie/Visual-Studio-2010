using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 2");
            Console.WriteLine("Lake Classes");
            LakeClass n1 = new LakeClass(0, 23, 15);
            LakeClass n2 = new LakeClass(1, 23, 14);
            LakeClass n3 = new LakeClass(2, 23, 14);
            LakeClass n4 = new LakeClass(3, 22, 24);
            LakeClass n5 = new LakeClass(8, 20, 14);
            LakeClass n6 = new LakeClass(9, 20, 15);
            LakeClass n7 = new LakeClass(10, 19, 14);
            LakeClass n8 = new LakeClass(12, 12, 7);
            LakeClass n9 = new LakeClass(18, 11, 7);
            LakeClass n10 = new LakeClass(23, 10, 7);
            LakeClass n11 = new LakeClass(29, 10, 6);



            Console.WriteLine("n1 = {0,15}", n1);

            Console.Write("n2 = {0,15}", n2);
            Console.WriteLine("Abs Slope n1:n2= {0}", n1 / n2);

            Console.Write("n3 = {0,15}", n3);
            Console.WriteLine("Abs Slope n2:n3= {0}", n2 / n3);

            Console.Write("n4 = {0,15}", n4);
            Console.WriteLine("Abs Slope n3:n4= {0}", n3 / n4);

            Console.Write("n5 = {0,15}", n5);
            Console.WriteLine("Abs Slope n4:n5= {0}", n4 / n5);

            Console.Write("n6 = {0,15}", n6);
            Console.WriteLine("Abs Slope n5:n6= {0}", n5 / n6);

            Console.Write("n7 = {0,15}", n7);
            Console.WriteLine("Abs Slope n6:n7= {0}", n6 / n7);

            Console.Write("n8 = {0,15}", n8);
            Console.WriteLine("Abs Slope n7:n8= {0}", n7 / n8);

            Console.Write("n9 = {0,15}", n9);
            Console.WriteLine("Abs Slope n8:n9= {0}", n8 / n9);

            Console.Write("n10 = {0,15}", n10);
            Console.WriteLine("Abs Slope n9:10= {0}", n9 / n10);

            Console.Write("n11 = {0,15}", n11);
            Console.WriteLine("Abs Slope n12:n11= {0}", n10 / n11);
            
            Console.ReadLine();

        }
    }
}
