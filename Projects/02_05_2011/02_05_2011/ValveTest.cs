using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_05_2011
{
    abstract class ValveTest
    {
        public string Name { get { return _Name; } }
        private string _Name;
        public bool status;
        abstract public double Flow { get; }

        public ValveTest(string Name, bool status)
        { _Name = Name; this.status = status; }

        public void TurnOn()
        { this.status = true; }

        public void TurnOff()
        { this.status = false; }

        public override string ToString()
        {
            string s = string.Format("Name {0}", Name);
            if (this.status == true)
            { s += "Status is On"; }
            else { s += "Status is Off"; }
                
            return s;
        }

    }

    class ConstantValve : ValveTest
    {
        public int Subtype;
        public override double Flow //overriding an abstract method
        {
            get
            {
                if (status == true)
                {
                    if (Subtype == 1) { return 10; }
                    if (Subtype == 2) { return 21; }
                    if (Subtype == 3) { return 29; }
                    else { return 0; }
                }
                else { return 0; }
            }
            


        }

        public ConstantValve(string Name, bool status, int Subtype): base(Name, status)//inheriting base class.

        { this.Subtype = Subtype; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Constant");
            s.Write(base.ToString());

            string SubtypeOutputString = "n/a";
            if (Subtype == 1)
            { SubtypeOutputString = "Low"; }
            else if (Subtype == 2)
            { SubtypeOutputString = "Medium"; }
            else if (Subtype == 3)
            { SubtypeOutputString = "High"; }
            s.WriteLine("   Subtype:={0}", SubtypeOutputString);


            return s.ToString();
        }
    }

    
}
