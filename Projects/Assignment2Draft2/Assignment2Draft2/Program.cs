using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * PartA:
             * You must represent this data as an array of Observation objects. (well... these are objects type double which could be observed.
             * Need to create an observation struct (contains the depth, temp and oxygen).
             * Has no methods, just a constructor (to assign stuff). Take a set of values and puts it into the struct.
             * 
             * Each lake as an observation array, name area and depth represented as "member data" in the Lake objectd.
             * 
             * 3 member methods in the lake class to return:
             * 
             * 1. Thermocline
             * 2. Average oxygen concentration above and bloe wthe thermocline.
             *      Method must return values as an array.
             * 3. Whether oxygen concentration in the hypoliminion is lower than the minimum allowable concentration.
             *      this method returns a boolean.
             *      
             * Must Write 2 static methods in the Lake class.
             * 
             * 1.   Minimum Temp
             * 2.   Max Temp
             * 
             * Must have two static members;
             * 1. Number of lakes. your constructors muset manage this member.
             * 2. minimum allowable average oxygen concentration in a layer a constant , 5mg/L
             * 
             * Last, ReadOnly Properties for the name, area, depth and a static readonly property for the number of lakes
             * 
             * LakeTest class
             * 1. Create the four lakes and all their member data.
             *      Lake objects must be placed in an "List<T>" object.
             *      
             * 2. For each lake:
             *      a. invokes the readonly properties and prints out the lake name, area and depth.
             *      b. invokes all five computation methods on each lake andwrites out their return values. you will have to unpack the return values to print them when they are in an array of list.
             * 
             * 3. outputs the static data member, number of lakes.
             * 
             */

            double[,] LakeNepressing = new double[11,4]

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

//Equation for Slope

            double n = (LakeNepressing[1, 2] - LakeNepressing[0, 2]) /( LakeNepressing[1, 1] - LakeNepressing[0, 1]);

            //automation of slope calculator.

            /*
             * start off with counter = 0;
             * increment counter per run.
             * as run progresses.
             * 
             * 
             * 
             */

            int i = 0;
            int j = i + 1;
            double Slope;
            double MaxSlope = 0;//dumbee starting values
            
            
            
            double ThermoclineD1=0, ThermoclineD2=0;//dumbee starting values

            double Slope2 = 0;
            string slope2string = "";

            string Label0 = "Run", Label1 = "D(m)", Label2 = "T(C)", Label3 = "O2", Label4 = "Slope";

            Console.WriteLine("Lake Nepressing");
            Console.WriteLine("");
            Console.WriteLine("[{0,6} [{1,6} [{2,6} [{3,6} [{4,6}", Label0, Label1, Label2, Label3, Label4);
            //Console.WriteLine("[{0,5}][{1,5}][{2,5}][{3,5}]", LakeNepressing[0, 0], LakeNepressing[0, 1], LakeNepressing[0, 2], LakeNepressing[0, 3]);
            LakeStruct a = new LakeStruct(LakeNepressing[i, 0], LakeNepressing[i, 1], LakeNepressing[i, 2], LakeNepressing[i, 3]);
            Console.WriteLine(a);
            LakeStruct b = new LakeStruct(LakeNepressing[j, 0], LakeNepressing[j, 1], LakeNepressing[j, 2], LakeNepressing[j, 3]);

            Console.WriteLine(b);
            while (j <= LakeNepressing.GetUpperBound(0))
            {
                /*
                Slope = (LakeNepressing[j, 2] - LakeNepressing[i, 2]) / (LakeNepressing[j, 1] - LakeNepressing[i, 1]);
                Console.Write("[{0,5}][{1,5}][{2,5}][{3,5}]", LakeNepressing[j, 0], LakeNepressing[j, 1], LakeNepressing[j, 2], LakeNepressing[j, 3]);
                
                Console.WriteLine("[{0,6:F3}]", Slope);
                

                Console.WriteLine("xxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxx");
                 * */

                a.R = i; a.D = LakeNepressing[i, 1]; a.T = LakeNepressing[i, 2]; a.O = LakeNepressing[i, 3];
                b.R = j; b.D = LakeNepressing[j, 1]; b.T = LakeNepressing[j, 2]; b.O = LakeNepressing[j, 3];
                

                Slope = LakeStruct.Slope(a, b);
                Console.Write(b);
                Console.WriteLine("\t {0,5:F3}", Slope);

                //Selection process is also needed.
                
                
                
                if (Slope < MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoclineD1 = LakeNepressing[i, 1]; ThermoclineD2 = LakeNepressing[j, 1];
                    
                }
                else
                { };

                slope2string = LakeStruct.SlopeSelectorInc(a, b);
                Console.WriteLine(slope2string);
                
                i++;  j++;//move down the rows.
                //at the moment it increases R no.s but doesn't do anything else with the other numbers.

            }
            Console.WriteLine("");
            Console.WriteLine("Epilimniom  is between depths [{0,2}]m and [{1,2}]m", LakeNepressing[0, 1], ThermoclineD1);
            Console.WriteLine("Thermocline is between depths [{0,2}]m and [{1,2}]m", ThermoclineD1, ThermoclineD2);
            Console.WriteLine("Hypolimnion is between depths [{0,2}]m and [{1,2}]m", ThermoclineD2, LakeNepressing[LakeNepressing.GetUpperBound(0), 1]);
            
            





            Console.ReadLine();

            //Selection process is also needed.
            
            //BRAINSTORMING
            /*
             * Need to make this work using class and lecturere asked us to create a lake class
             * the lake class could take 4 arguments, {R,D,T,O} (R=Run No. , D = depth, T = temperature, O = O2 levels)
             * 
             * Method which could involved insitiating/creating a new LakeClass object for every Run No.
             * This would be a get and set type of a thing, get the values from the matrix, assign the values from the array/matrix to the the the 4 arguments and then output a new LakeClass object.
             * Ony problem with that is that you need to some how come up with a way to automate the naming process.
             * 
             * Method which may not involve instiatiating anything.
             * Do the assigning process in loops in main and pass those values onto a struct/class for calculations and methods. - a rolling struct/class.
             * avoids the troubles of needing to name out each run.
             * 
             * Create a new class with a form of an array so you could go "LakeNepressing.Thermocline" and get the thermocline.
             * That would be on of the processes and methods that don't take any arguments.
             * 
             */
        }

        struct LakeStruct
        {
            public double R, D, T, O;

            //constructor
            public LakeStruct(double R, double D, double T, double O)
            {
                this.R = R;
                this.D = D;
                this.T = T;
                this.O = O;
            }

            public LakeStruct (LakeStruct a)
            {
                R = a.R;
                D = a.D;
                T = a.T;
                O = a.O;
            }
            //Methods

            public static double Slope(LakeStruct a, LakeStruct b)
            {
                return (b.T - a.T) / (b.D - a.D);
            }

            public static string SlopeSelectorInc(LakeStruct a, LakeStruct b)
            {
                double Slope = (b.T - a.T) / (b.D - a.D);
                double MaxSlope = 0, ThermoclineD1, ThermoclineD2;
                ThermoclineD1 = 0; ThermoclineD2 = 0; 
                if (Slope < MaxSlope)
                {
                    MaxSlope = Slope;
                    ThermoclineD1 = a.D; ThermoclineD2 = b.D;
                    
                }
                else
                { };
                return "D1 " + ThermoclineD1 + " D2 " + ThermoclineD2;

                
            }

            public override string ToString()
            {
                return R + "\t" + D + "\t" + T + "\t" + O;
            }

        }

    }
}
