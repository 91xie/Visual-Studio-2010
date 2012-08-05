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

            

            List<ObservationStruct []> ObservationStructList = new List <ObservationStruct[]>();
            
            ObservationStructList.Add
                (new ObservationStruct[] 
                {new ObservationStruct(0,23,15),
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
            });

            ObservationStructList.Add
                (new ObservationStruct[] 
                {
                new ObservationStruct(0,24,12),
                new ObservationStruct(0,24,12),
                new ObservationStruct(4,23,13),
                new ObservationStruct(6,20,10),
                new ObservationStruct(8,21,11),
                new ObservationStruct(10,17,9),
                new ObservationStruct(12,13,5),
                new ObservationStruct(14,13,4),
                new ObservationStruct(16,12,4),
                new ObservationStruct(18,12,4),
                new ObservationStruct(20,12,3),

                });
            ObservationStructList.Add
                (new ObservationStruct[]
                {
                new ObservationStruct(0,23,8),
                new ObservationStruct(3,24,8),
                new ObservationStruct(5,22,7),
                new ObservationStruct(8,15,4),
                new ObservationStruct(10,16,3),
                new ObservationStruct(13,15,3),
                new ObservationStruct(15,14,2),
                });

            ObservationStructList.Add
                (new ObservationStruct[]
                {
                new ObservationStruct(0,26,11),
                new ObservationStruct(1,25,11),
                new ObservationStruct(2,24,11),
                new ObservationStruct(4,24,10),
                new ObservationStruct(5,23,11),
                new ObservationStruct(8,20,10),
                new ObservationStruct(9,17,9),
                new ObservationStruct(11,17,9),
                new ObservationStruct(13,17,10),
            });

            List<LakeClass> LakeClassList = new List<LakeClass>();
            LakeClassList.Add(new LakeClass(ObservationStructList[0], "LakeNepressing", 2.3, 35));
            LakeClassList.Add(new LakeClass(ObservationStructList[1], "LakeHadley", 1.7, 24));
            LakeClassList.Add(new LakeClass(ObservationStructList[2], "Fish Lake", 1.1, 19));
            LakeClassList.Add(new LakeClass(ObservationStructList[3], "Ortonville Lake", 1.3, 15));



            foreach (LakeClass a in LakeClassList)
            { a.CompleteOutput(); }


            Console.WriteLine("No of lakes:= {0}", LakeClassList.Count);
            Console.WriteLine("");


            //////////////////////////////

            Console.ForegroundColor = ConsoleColor.Red;
            
            
            
            Console.ReadLine();
        }


        

   
    
    }

    

    struct ObservationStruct
    {


        public double Depth;
        public double Temp;
        public double Olevels;

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
        
        public override string ToString()
        {
            string Observationstructstring = System.String.Format("|{0,6}|{1,6}|{2,6}", Depth, Temp, Olevels);
            return Observationstructstring;
        }




    }
}
//create the lake class to represent the class object.
//lake: name, area, depth, observations
//or one could get a load of information and be able to spit out a new lakeclass object... kinda like a "return new LakeClass," this would be similar to returning a new complexclass