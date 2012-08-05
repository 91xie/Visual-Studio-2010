using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_05_11_ComplexNo
{
    class Program
    {
        static void Main(string[] args)
        {
            //complex no.

            ComplexNo a = new ComplexNo(2, 6);
            ComplexNo b = new ComplexNo(4, 1);

            Console.WriteLine(a.Scaleby(.5));
            Console.WriteLine(a.Division(b));
            
            Console.ReadLine();
        }
    }

    class ComplexNo
    {
        double x, y;

        public ComplexNo(double x, double y)
        { this.x = x; this.y = y; }
        public ComplexNo()
        { this.x = 0; this.y = 0; }
        public ComplexNo(ComplexNo a)
        { this.x = a.x; this.y = a.y; }

        //methods

        public ComplexNo Addition(ComplexNo b)
        { return new ComplexNo(this.x + b.x, this.x + b.y); }

        public ComplexNo Subtraction(ComplexNo b)
        { return new ComplexNo(this.x - b.x, this.y - b.y); }


        public ComplexNo Multiplication(ComplexNo b)
        {return new ComplexNo(((this.x*b.x) - ( this.y*b.y)),((this.x * b.y) + (b.x*this.y)));}

        public ComplexNo Conjugate()
        { return new ComplexNo(this.x, -this.y); }

        public ComplexNo Scaleby (double Scaler)
        { return new ComplexNo(this.x * Scaler, this.y * Scaler); }

        public double Magnitude()
        { return Math.Sqrt(this.x * this.x + this.y * this.y); }

        public ComplexNo Division(ComplexNo b)
        {
            
            return new ComplexNo ((this.Multiplication(b.Conjugate())).Scaleby(1/(b.x*b.x + b.y*b.y)));
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            if (this.y > 0)
            { s.Write("{0} +{1}i", x, y); }
            else
            { s.Write("{0} {1}i", x, y); }
            return s.ToString();
        }
    }
}
