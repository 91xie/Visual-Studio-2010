using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNoClass
{
    class ComplexClass
    {
        public double x, y;

        public ComplexClass(double Real, double Imaginary)
        {
            this.x = Real;
            this.y = Imaginary;
        }

        public ComplexClass(ComplexClass a)
        {
            x = a.x;
            y = a.y;
        }

        public static double Magnitude(ComplexClass a)
        { return Math.Sqrt(a.x * a.x + a.y * a.y); }

        public static double ArgumentRadians(ComplexClass a)
        { return Math.Atan(a.y / a.x); }

        public static double ArgumentDegrees(ComplexClass a)
        { return (Math.Atan(a.y/a.x))* (180 / Math.PI); }

        public static ComplexClass operator + (ComplexClass a, ComplexClass b)
        {
            double x, y;
            x = a.x + b.x;
            y = b.x + b.y;
            return new ComplexClass(x, y);
        }

        public static ComplexClass operator - (ComplexClass a, ComplexClass b)
        {
            double x, y;
            x = a.x - b.x;
            y = a.y - b.y;
            return new ComplexClass(x, y);
        }

        public static ComplexClass operator *(ComplexClass a, ComplexClass b)
        {
            double x, y;
            x = a.x * b.x - a.y * b.y;
            y = a.x * b.y + a.y * b.x;
            return new ComplexClass(x, y);
        }

        public static ComplexClass Compliment(ComplexClass a)
        {
            double x, y;
            x = a.x;
            y = -a.y;
            return new ComplexClass(x, y);
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }

    }
}
