using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft4LakeClassb
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] LakeNepressing = new double[,]

            {
                {0,0,2.3,35},
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

            LakeClassArray LakeNepressingA = new LakeClassArray(LakeNepressing, "LakeNepressing", 30, 45);

            
            Console.WriteLine(LakeClassArray.Thermocline(LakeNepressingA));
            Console.WriteLine(LakeNepressingA);


            double[,] FishLake = new double[,]
            {
                {0,0,1.1,19},
                {0,0,23,8},
                {1,3,24,8},
                {2,5,22,7},
                {3,8,15,4},
                {4,10,16,3},
                {5,13,15,3},
                {6,15,14,2},

            
            };

            LakeClassArray FishLakeA = new LakeClassArray(FishLake, "FishLake", 15, 2.3);

            Console.WriteLine(LakeClassArray.Thermocline(FishLakeA));
            Console.WriteLine(FishLakeA);
            Console.ReadLine();

        }
        
        struct ObservationStruct
        {
            public double Depth;
            public double Temp;
            public double Olevels;

            //constructor
            public ObservationStruct (double Depth, double Temp, double Olevels)
            {
                this.Depth = Depth;
                this.Temp = Temp;
                this.Olevels = Olevels;
            }

            public ObservationStruct(ObservationStruct a)
            {
                Depth = a.Depth ;
                Temp = a.Temp ;
                Olevels = a.Olevels; 
            }
            //</constructors>


            
          
                
                
         
        }
         

        }
    }

    //observation struct. takes values from the lakenepressing and passes it onto respective bits.
    //class could have different variables. area and maxdepth are fixed... you assign them those values and just leave it. Don't need to do anything with those values.
    //you could get static methods to do all the calculations eventhough that is not what is prescribed...
    //its just a case of turning static methods into classes in methods.
    

    //his description of an observation struct is that you have a new struct object for every observation (for you, every row)
    

