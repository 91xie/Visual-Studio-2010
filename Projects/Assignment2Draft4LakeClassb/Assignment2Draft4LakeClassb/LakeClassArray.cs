using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft4LakeClassb
{
    class LakeClassArray
    {
        public double [,] Array ;
        public string name;
        public double maxdepth;
        public double area;
        

            
        
        public LakeClassArray (double [,] Array, string name, double maxdepth, double area) //pretty much copies array into the arrayclass.
                {
                    this.Array = Array;
                    this.name = name;
                    this.maxdepth = maxdepth;
                    this.area = area;

                }

        public override string ToString()
        {
            return "Name:= " + name + "MaxDepth:= " + maxdepth + "Area:= " + area;
        }


        static public string Thermocline(LakeClassArray A)
        {
            //double n = (LakeNepressing[1, 2] - LakeNepressing[0, 2]) /( LakeNepressing[1, 1] - LakeNepressing[0, 1]);
            
            //return (b.T - a.T) / (b.D - a.D);

            double Slope, MaxSlope = 0;
            double ThermoD1 = 0, ThermoD2 = 0;

            int i = 1, j = i + 1;
            while (j <= A.Array.GetUpperBound(0))
            {
                Slope = Math.Abs((A.Array[j, 2] - A.Array[i, 2]) / (A.Array[j, 1] - A.Array[i, 1]));
                if (Slope > MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoD1 = A.Array[i, 1];
                    ThermoD2 = A.Array[j, 1];


                }

                else
                { }
                i++; j++;


            }
            //double [] outputslope = new double [2] {ThermoD1,ThermoD2};


            return "Epilimnion:= " + A.Array[0, 1] + "m - " + ThermoD1 + "m    Thermocline:= " + ThermoD1 + "m and " + ThermoD2 + "m   Hypoliminion:= " + ThermoD2 + "m and " + A.Array[A.Array.GetUpperBound(0), 1] + "m";


        }



    }
}
