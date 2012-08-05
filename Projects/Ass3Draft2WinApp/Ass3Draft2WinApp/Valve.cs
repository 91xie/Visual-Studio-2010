using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ass3Draft2WinApp
{
 
    abstract class Valve
    {
        public string SerialNumber { get { return _SerialNumber; } }//private...
        public bool Status;
        public abstract double Flow { get; }
        private string _SerialNumber;
        
        public Valve(string SerialNumber, bool Status)
        {this._SerialNumber = SerialNumber;this.Status = Status;}

        public void TurnOn(){this.Status = true;}

        public void TurnOff(){this.Status = false;}

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine(" Flow Valve");

            s.WriteLine("Serial Number:= {0}", SerialNumber);
            string statusoutput = "n/a";
            if (Status == true)
                statusoutput = "On";
            else if (Status == false)
                statusoutput = "Off";
            s.WriteLine("   Status:= {0}", statusoutput);
            s.WriteLine("   Flow  := {0}", Flow);


            return s.ToString();
        }


    }
    class ConstantFlowValve : Valve
    {
        public int Subtype;//int 1,2,3 low, medium, high

        public override double Flow
        {
            get
            {
                if (Status == true)
                {
                    if (Subtype == 1){ return 10; }
                    else if (Subtype == 2){ return 21; }
                    else if (Subtype == 3){ return 29; }
                        
                }
                else if (Status == false)
                {return 0;}
                return 0;

            }

        }
        //flow rate you get from subtype
        public ConstantFlowValve(string SerialNumber, bool Status, int Subtype)
            : base(SerialNumber, Status)
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


    class VariableFlowValve : Valve
    {
        public int ValveSetting;
        public override double Flow{get{return ValveSetting * 3;}}
        public VariableFlowValve(string SerialNumber, bool Status, int ValveSetting)
            : base(SerialNumber, Status)
        {
            if (ValveSetting >= 1 && ValveSetting <= 10)
            {
                this.ValveSetting = ValveSetting;
            }

            else if (ValveSetting < 1)//make sure that it stays witin the range even if you put a no. outside of the range
            {this.ValveSetting = 1;}
            else if (ValveSetting > 10)//make sure that it stays witin the range even if you put a no. outside of the range
            {this.ValveSetting = 10;}

        }

        public void IncrementValveSetting()
        {
            if (this.ValveSetting >= 1 && this.ValveSetting <= 9)
                this.ValveSetting++;
            else if (this.ValveSetting >= 10)
                this.ValveSetting = 10;
        }

        public void DecrementValveSetting()
        {
            if (this.ValveSetting >= 2 && this.ValveSetting <= 10)
                this.ValveSetting--;
            else if (this.ValveSetting <= 1)
                this.ValveSetting = 1;
        }

        public override string ToString()//override to string method.
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Variable");
            s.Write(base.ToString());
            s.WriteLine("   Valve Setting:={0}", ValveSetting);
            return s.ToString();
        }

    }

}
