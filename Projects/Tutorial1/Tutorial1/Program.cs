using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial1
{
    class Program
    {
        static void Main(string[] args)
        {
            myClass x = new myClass(1, 2);
            myClass y = new myClass(3, 4);
            //when y = x; they both reference to the same object.
            //if you want to copy stuff using myClass, you can do it
            Console.WriteLine("1");
            Console.WriteLine(x);
            Console.WriteLine(y);

            y = x;


            Console.WriteLine("2");
            Console.WriteLine(x);
            Console.WriteLine(y);

            x.a = 5;

            Console.WriteLine("3");
            Console.WriteLine(x);
            Console.WriteLine(y);

            y.a = 1;
            Console.WriteLine("4");
            Console.WriteLine(x);
            Console.WriteLine(y);

            //now both x and y are both a values is equal to 5.

            Console.WriteLine("--------------------");
            //now if we have structs... we have a different story
            //don't want structs for large sets of data...
            //keeps copying and copying eventhough many of them have the same element.
            

            myStruct x1 = new myStruct(1,2);
            myStruct y1 = new myStruct(3, 4);


            Console.WriteLine("1");
            Console.WriteLine(x1);
            Console.WriteLine(y1);

            y1 = x1;


            Console.WriteLine("2");
            Console.WriteLine(x1);
            Console.WriteLine(y1);

            x1.a = 5;

            Console.WriteLine("3");
            Console.WriteLine(x1);
            Console.WriteLine(y1);
            Console.ReadLine();

            
            
        }
    }

    struct myStruct
    {
        public int a, b;

        public myStruct(int a, int b)
        {this.a = a; this.b = b;}

        public override string ToString()
        {
            return string.Format("a={0}, b={1}",a,b);
        }
    }

    class myClass
    {
        public int a, b;

        public myClass(int a, int b)
        {this.a = a; this.b = b;}

        public override string ToString()
        {
            return string.Format("a={0}, b={1}",a,b);
        }



    }
}
