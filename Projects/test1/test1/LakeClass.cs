using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test1
{
    class LakeClass
    {
        public ObservationStruct [] Array ;
        public string name;
        public double maxdepth;
        public double area;
        

        public LakeClass(ObservationStruct[] Array, string name, double area, double maxdepth)
        { this.Array = Array; this.name = name; this.maxdepth = maxdepth; this.area = area;}

        public override string ToString()
        { return "Name:= " + name + " MaxDepth:= " + maxdepth + "m Area:= " + area + "km^2"; }

        public static double MaxTemp(LakeClass A)
        {
            double maxtemp = 0;
            int counter=0;
            while (counter <=A.Array.GetUpperBound(0))
            {
                if(A.Array[counter].Temp > maxtemp)
                {
                    maxtemp = A.Array[counter].Temp;
                }
                counter++;
            };
            return maxtemp;
        }

        public static double MinTemp(LakeClass A)
        {
            double mintemp = 100;
            int counter = 0;
            while (counter <= A.Array.GetUpperBound(0)) 
            {if (A.Array[counter].Temp < mintemp) 
            {
                mintemp = A.Array[counter].Temp;
            }
            counter++;
            }
            return mintemp;
        }

        public void MaxandMinTemp()
        {Console.WriteLine("MaxTemp:= {0}   MinTemp:= {1}", LakeClass.MaxTemp(this), LakeClass.MinTemp(this));}

        private static int [] privateThermocline (LakeClass A)
        {
            double Slope, MaxSlope = 0;
            double deltaSlope = 0.2; //slope range.
            double ThermoD1 = 0, ThermoD2 = 0; //starting dummie values;
            int i = 0, j = i+1;
            int tval1 = 0, tval2 = 0;
            while (j<= A.Array.GetUpperBound(0))
            {
                Slope = Math.Abs((A.Array[j].Temp - A.Array[i].Temp)/(A.Array[j].Depth - A.Array[i].Depth));
                if (Slope > MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoD1 = A.Array[i].Depth;
                    tval1 = i;
                    ThermoD2 = A.Array[j].Depth;
                    tval2 = j;
                }
                else if ((Slope <= (MaxSlope + deltaSlope)) && (Slope >= (MaxSlope - deltaSlope)))
                {
                    ThermoD2 = A.Array[j].Depth;
                }
                else{}

                i++;j++;


            }


            int [] Outputthermoarrayvalues = new int[] {tval1,tval2};
            return Outputthermoarrayvalues;
        }
 
        private static double[] privateO2levels(LakeClass A)
        {
            int[] Tvals = LakeClass.privateThermocline(A);


            int counter;
            double o2sumEpi = 0, o2sumpHypo = 0, o2averageEpi = 0, o2averageHypo = 0;

            counter = 0;
            while (counter <= Tvals[0])
            {
                o2sumEpi += A.Array[counter].Olevels;
                counter++;
            };
            o2averageEpi = o2sumEpi / counter;

            counter = Tvals[1];
            while (counter <= A.Array.GetUpperBound(0))
            {
                o2sumpHypo += A.Array[counter].Olevels;
                counter++;
            };
            o2averageHypo = o2sumpHypo / (A.Array.GetUpperBound(0) - Tvals[0]);
       
            double[] outputarray = new double [] {o2averageEpi, o2averageHypo};
            return outputarray;
        }

        public static bool privateAllowableO2(LakeClass A)
        {
            double mino2 = 5;
            bool allowableo2test=true;
            
            if (LakeClass.privateO2levels(A)[1] >= mino2)
            { allowableo2test = true; }
            else if (LakeClass.privateO2levels(A)[1] < mino2)
            { allowableo2test = false; }

            return allowableo2test;    
        }


        public void Thermocline()
        {
            int[] Tvals = LakeClass.privateThermocline(this);
            Console.WriteLine("Epilimnion:= {0}m - {1}m   Thermocline:= {1}m - {2}m   Hypoliminion:= {2}m - {3}m", this.Array[0].Depth, this.Array[Tvals[0]].Depth, this.Array[Tvals[1]].Depth, this.Array[this.Array.GetUpperBound(0)].Depth); 
        }

        private void O2levels()
        {
            int[] Tvals = LakeClass.privateThermocline(this);
            Console.WriteLine("Average O^2 levels Epi is:= {0:F3}   Average O^2 levels Hyp is:= {1:F3}", LakeClass.privateO2levels(this)[0], LakeClass.privateO2levels(this)[1]);    
        }

        public void AllowableO2()
        {
            if (LakeClass.privateAllowableO2(this) == true)
            { Console.WriteLine("Minimal allowable O^2 levels true"); }
            else if (LakeClass.privateAllowableO2(this) == false)
            { Console.WriteLine("Minimal allowable O^2 levels false"); }
        }

        public void ObservationOutput()
        {
            int i = 0;
            string lb1 = "Depth", lb2 = "Temp", lb3 = "O^2";
            Console.WriteLine("");
            Console.WriteLine("|{0,6}|{1,6}|{2,6}", lb1, lb2, lb3);
            while (i < 21)
            {
                Console.Write("-");
                i++;
            }
            i = 0;
            Console.WriteLine("");
            while (i <= this.Array.GetUpperBound(0))
            {
                Console.WriteLine(this.Array[i]);
                i++;
            }
            Console.WriteLine("");
        }
        
        public void CompleteOutput()
        {
            Console.WriteLine(this);
            this.ObservationOutput();
            this.Thermocline();
            this.O2levels();
            this.AllowableO2();
            this.MaxandMinTemp();
            Console.WriteLine();
            
        }
    }
}
