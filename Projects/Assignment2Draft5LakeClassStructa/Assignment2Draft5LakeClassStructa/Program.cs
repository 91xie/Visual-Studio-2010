using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {

            ObservationStruct[] aLake = new ObservationStruct[]

            {
                new ObservationStruct(0,23,15),
                new ObservationStruct(1,23,14),
                new ObservationStruct(2,23,14),
                new ObservationStruct(3,22,14),
                new ObservationStruct(8,20,14),
                new ObservationStruct(9,20,15),
                new ObservationStruct(10,19,14),
                new ObservationStruct(12,12,7),
                new ObservationStruct(18,11,7),
                new ObservationStruct(23,10,7),
                new ObservationStruct(29,10,6),

            };


            ObservationStruct btest = new ObservationStruct(2, 3, 4);

            //LakeClass LakeNepressing = new LakeClass();


            //LakeNepressing.Name = "LakeNepressing";
            Console.WriteLine("aadfafasfasfda");
            //Console.WriteLine(LakeNepressing);
            Console.WriteLine(aLake[1]);
            Console.WriteLine(btest);
            Console.ReadLine();
        }


        struct ObservationStruct
        {
            public double Depth;
            public double Temp;
            public double Olevels;

            //constructor
            public ObservationStruct(double Depth, double Temp, double Olevels)
            {
                this.Depth = Depth;
                this.Temp = Temp;
                this.Olevels = Olevels;
            }

            public ObservationStruct(ObservationStruct a)
            {
                Depth = a.Depth;
                Temp = a.Temp;
                Olevels = a.Olevels;
            }
            //</constructors>
            //structs are value type objects so the values wouldn't change if you do stuff to do them unless you explicity do it.
            //the idea is to create a lake class that has all of the information about the lake in it.
            //so you could go LakeNepressing.Thermocline or LakeNepressing.MaxTemp to get your answers.
            //you could hardwire the information where by you arrange all of the information as an array.
            //as you have structs, this would be a 1D array to simplfy things.
            //you need to get information from the array and pass it to the class for processing.
            //you can't have public double array as you don't want to be able to access the entire array itself.
            //you should be able to access individual arrays if you want to.

            //comparison between class 3D vector and lake class.
            //the thing is, the public variables denoted at the beginning public x, y, z are free to access as you need to print out these values and do calculations with these values.
            //for lake class, for the array which you need to pass information from to the lake class, these values/structs/array index, you don't need to display them unless specified.
            //but either way, you want to be able to pass information to it... or a constructor is necessary to:
            //a. assign the values/
            //b. and create the name for the class OR be LakeNepressing.Name = and then assign it like that by writing it out or have string.Parse(Console.ReadLine())
            //I think that is what he was on about.




            public override string ToString()
            {

                return "" + Depth + "   " + Temp + "   " + Olevels;
            }






        }
    }
}
