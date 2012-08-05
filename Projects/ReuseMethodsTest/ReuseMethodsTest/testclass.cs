using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReuseMethodsTest
{
    class testclass
    {
        public double x, y, z;

        public testclass (testclass a)
    {  
        a.x = x;
        a.y = y;
        a.z = z;
    } //constructor
        public testclass (double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;

        } // constructor
        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        } //override Tostring for printing out testclass objects.




    }
}
