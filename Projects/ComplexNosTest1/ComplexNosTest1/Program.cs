using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNosTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ComplexNoTest1");
            ComplexNo a = new ComplexNo(1, 2);
            Console.WriteLine("a= " + a);
            Console.WriteLine("|a|= " + a.Magnitude());
            ComplexNo b = new ComplexNo(3, 4);
            ComplexNo c = a.Addition(b);
            Console.WriteLine("a + b = c = " + c);

            double arg = a.Argument();
            Console.WriteLine("<a =" + arg);


            Console.WriteLine("Quit");
            Console.ReadLine();


        }

        struct ComplexNo
        {
            public double x, y;

            public ComplexNo (double x, double y)
        {
            this.x=x;
            this.y=y;
        }
            
            

            public ComplexNo (ComplexNo a)
            {
                x = a.x;
                y = a.y;
                
            }

            public double Magnitude()
            {
                return Math.Sqrt(x * x + y * y);
                
            }

            public ComplexNo Addition(ComplexNo b)
            {
                ComplexNo c = new ComplexNo();
                c.x = x + b.x;
                c.y = y + b.y;
                
                return c;


            }

            public double Argument()
        {
            return (Math.Tan(y/x))*(180/(Math.PI)); 
        }

            public override string ToString()
            {
                return x + "," + y + "i";
            }

        }
    }
}
