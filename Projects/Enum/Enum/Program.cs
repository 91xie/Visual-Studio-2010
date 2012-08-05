using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enum
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Valve
    {
        public enum SubTypes
        {HIGH, MEDIUM, LOW }

        SubTypes _Subtype;
        public SubTypes Subtype { get { return _Subtype; } }
        public Valve(SubTypes Subtype) { _Subtype = Subtype; }

        public double Flow
        {
            get
            {
                if (_Subtype == SubTypes.HIGH)
                { return 29; }
                else if (_Subtype == SubTypes.MEDIUM)
                { return 21; }
                else
                { return 10; }
            }
        }
    }
}
