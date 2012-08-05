using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft3aLakeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LakeClass Creation");

            /*
             * Objectives - Create a lake class
             * turn the lake class into an array
             * simple lake class could just take arguments regarding its basic data first.
             * 
             * passing data from the array to the class.
             * 
             * 
             * write methods for that array
             */

            //LakeClass LakeNepressing = new LakeClass();
            
            //don't mind the fecking class just yet.
            //surely one could write a static method for calculating the thermocline... only problem is, not sure how one would be able to include everything into one tidy package.
            //classess according to him are only meant to take 3 arguments.

            double[,] LakeNepressing = new double[,]

            {
                {0,0,23,15},
                {1,1,23,14},
                {2,2,23,14},
                {3,3,22,14},
                {4,8,20,14},
                {5,9,20,15},
                {6,10,19,14},
                {7,12,12,7},
                {8,18,11,7},
                {9,23,10,7},
                {10,29,10,6},



            };

            int i = 0;
            int j = i + 1;
            double Slope;
            double MaxSlope = 0;//dumbee starting values

            double ThermoclineD1 = 0, ThermoclineD2 = 0;//dumbee starting values

            string Label0 = "Run", Label1 = "D(m)", Label2 = "T(C)", Label3 = "O2", Label4 = "Slope";

            Console.WriteLine("Lake Nepressing");
            Console.WriteLine("");
            Console.WriteLine("[{0,5}][{1,5}][{2,5}][{3,5}][{4,6}]", Label0, Label1, Label2, Label3, Label4);
            Console.WriteLine("[{0,5}][{1,5}][{2,5}][{3,5}]", LakeNepressing[0, 0], LakeNepressing[0, 1], LakeNepressing[0, 2], LakeNepressing[0, 3]);

            while (j <= LakeNepressing.GetUpperBound(0))
            {
                Slope = (LakeNepressing[j, 2] - LakeNepressing[i, 2]) / (LakeNepressing[j, 1] - LakeNepressing[i, 1]);
                Console.Write("[{0,5}][{1,5}][{2,5}][{3,5}]", LakeNepressing[j, 0], LakeNepressing[j, 1], LakeNepressing[j, 2], LakeNepressing[j, 3]);

                Console.WriteLine("[{0,6:F3}]", Slope);
                //Selection process is also needed.
                if (Slope < MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoclineD1 = LakeNepressing[i, 1]; ThermoclineD2 = LakeNepressing[j, 1];
                    //Console.WriteLine("Thermocline is between depths [{0}]m and [{1}]m", LakeNepressing[i,1], LakeNepressing[j,1]);

                }
                else
                { };


                i++; j++;//move down the rows.


            }

            


            /////////////////////
            double[,] FishLake = new double[,]
            {
                {0,0,23,8},
                {1,3,24,8},
                {2,5,22,7},
                {3,8,15,4},
                {4,10,16,3},
                {5,13,15,3},
                {6,15,14,2},

            
            };
            i = 0;
            j = i + 1;
            
            MaxSlope = 0;//dumbee starting values

            ThermoclineD1 = 0; ThermoclineD2 = 0;//dumbee starting values

            
            Console.WriteLine("Fish Lake");
            Console.WriteLine("");
            Console.WriteLine("[{0,5}][{1,5}][{2,5}][{3,5}][{4,6}]", Label0, Label1, Label2, Label3, Label4);
            Console.WriteLine("[{0,5}][{1,5}][{2,5}][{3,5}]", FishLake[0, 0], FishLake[0, 1], FishLake[0, 2], FishLake[0, 3]);

            while (j <= FishLake.GetUpperBound(0))
            {
                Slope = Math.Abs((FishLake[j, 2] - FishLake[i, 2]) / (FishLake[j, 1] - FishLake[i, 1]));
                Console.Write("[{0,5}][{1,5}][{2,5}][{3,5}]", FishLake[j, 0], FishLake[j, 1], FishLake[j, 2], FishLake[j, 3]);

                Console.WriteLine("[{0,6:F3}]", Slope);
                //Selection process is also needed.
                if (Slope > MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoclineD1 = FishLake[i, 1]; ThermoclineD2 = FishLake[j, 1];
                    //Console.WriteLine("Thermocline is between depths [{0}]m and [{1}]m", LakeNepressing[i,1], LakeNepressing[j,1]);

                }
                else
                { };


                i++; j++;//move down the rows.


            }

            Console.WriteLine("");

            Console.WriteLine("Lake Nepressing");
            Console.WriteLine(Thermocline(LakeNepressing));
            Console.WriteLine("FishLake");
            Console.WriteLine(Thermocline(FishLake));

            
            
            
            Console.ReadLine();

            
            

        }

        static string Thermocline (double[,] A)
        {
            //double n = (LakeNepressing[1, 2] - LakeNepressing[0, 2]) /( LakeNepressing[1, 1] - LakeNepressing[0, 1]);

            //return (b.T - a.T) / (b.D - a.D);

            double Slope, MaxSlope = 0;
            double ThermoD1=0, ThermoD2=0;

            int i = 0, j = i + 1;
            while (j <= A.GetUpperBound(0))
            {
                Slope = Math.Abs((A[j,2] - A[i,2]) / (A[j,1] - A[i,1]));
                if (Slope > MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoD1 = A[i, 1];
                    ThermoD2 = A[j, 1];
                    

                }

                else
                {}
                i++; j++;

                
            }
            //double [] outputslope = new double [2] {ThermoD1,ThermoD2};


            return "Epilimnion:= " + A[0,1] + "m - " + ThermoD1 + "m    Thermocline:= " + ThermoD1 + "m and " +  ThermoD2 + "m   Hypoliminion:= " + ThermoD2 + "m and " + A[A.GetUpperBound(0),1] +"m" ;
            

        }


        //Re-write to just have double ThermoD1 -> returns just A[i,1] and not i so don't know how to get j without getting i.
        //Write another method to get double ThermoD2 from ThermoD1
        //Write double Epi and double Hypo method from that.
        //only other way is to re calculate everything which would be slower...
        //or just have everything in the one output.
    }
}
