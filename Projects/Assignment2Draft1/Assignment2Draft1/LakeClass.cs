using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft1
{
    class LakeClass
    {
        public double D, T, O;
        //D for depth, T for temperature, O for oxygen.

        //constructors
        public LakeClass (double D, double T, double O)
        {
            this.D = D;
            this.T = T;
            this.O = O;
        }

        public LakeClass(LakeClass a)
        {
            D = a.D;
            T = a.T;
            O = a.O;
        }

        //Slope Calculator

        public static double operator / (LakeClass a, LakeClass b)
        {
            return Math.Abs((a.T - b.T) / (a.D - b.D));
        }


        //Override ToString method
        public override string  ToString()
        {
            return "(" + D + "," + T + "," + O + ")";
        }
    }
}
