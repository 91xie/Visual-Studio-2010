using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Draft3aLakeClass
{
    class LakeClass
    {
        //takes 3 bits of data information...
        double Area, Depth;


        public LakeClass(LakeClass aLake)
    {
        Area = aLake.Area;
        Depth = aLake.Depth;

    }


        public LakeClass(double Area, double Depth)
        {
            this.Area = Area;
            this.Depth = Depth;
        }

        public LakeClass()
        {
            // TODO: Complete member initialization
        }


    }
}
