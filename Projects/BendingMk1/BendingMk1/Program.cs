using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BendingMk1
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro(); 
            string selector = Console.ReadLine();
            if (selector == "1")
            {
                ManualInputConsole1();
            }
            else if (selector == "2")
            {
                TextInputConsole1();
            }
            else if (selector == "3")
            {
                DefaultInput();
            }
            


            
        }


        static void Intro()
        {
            Console.WriteLine("Bending App");
            Console.WriteLine("How to Use:");
            Console.WriteLine("Draw your structure on a piece of paper.");
            Console.WriteLine("Divide up your structure into seperate rectangular components and index each");
            Console.WriteLine("Input your info for each index component in the format as follows below . . .");
            Console.WriteLine("(x , y , cx , cy)");
            Console.WriteLine("x = width of a rectcomponent, y = the height.\ncx = coordinate for center of gravity in x, cy = center of gravity in y");
            Console.WriteLine("Input each ( x, y, cx, cy), press enter to go onto a new line to add a new component");
            Console.WriteLine("When you are finished, type 'done'");
            Console.WriteLine("Type 'quit' to quit");
            Console.WriteLine();
            Console.Write("1. Manual Input 2. File Input 3. DefaultFile -> DefaultOutput . . . ");
        }
        
        static void TextInputConsole1()
        {
            List<CompRect> ListofCompRect = new List<CompRect>();
            List<CompSystem> ListofCompSystem = new List<CompSystem>();
            
            Console.Write("Title of input file . . . (don't forget .txt or .csv) ");

            string name = Console.ReadLine();
            Console.Write("Title of output file . . . (default is .txt) ");
            string outputname = Console.ReadLine();

            System.IO.StreamReader theFile = new System.IO.StreamReader(name);
            System.IO.StreamWriter OutPut = new System.IO.StreamWriter(outputname + ".txt");

            string readline = "";
            Console.WriteLine("Input");
            OutPut.WriteLine("Input");

            while (!theFile.EndOfStream)
            {
                readline = theFile.ReadLine();
                Console.WriteLine(readline);
                OutPut.WriteLine(readline);
                if (readline == "done") { break; } else if (readline == "") { continue; }
                
                ListofCompRect.Add(new CompRect(readline));
            }
            CompSystem CurrentSystem = new CompSystem(ListofCompRect);

            Console.WriteLine("----------------------");
            Console.WriteLine(CurrentSystem.ToString());
            Console.WriteLine("Press Enter to Output and quit");

            OutPut.WriteLine("-----------------------");
            OutPut.WriteLine(CurrentSystem.ToString());             
            

            readline = Console.ReadLine();
            theFile.Close();
            OutPut.Close();
        }

        static void ManualInputConsole1()
        {

            List<CompRect> ListofCompRect = new List<CompRect>();
            List<CompSystem> ListofCompSystem = new List<CompSystem>();

            Console.Write("Title of output file . . . ");
            string name = Console.ReadLine();

            System.IO.StreamWriter theFile = new System.IO.StreamWriter(name + ".txt");
            theFile.WriteLine("Your Input");

            string readline = "";


            ListofCompRect.Clear();
            for (; ; )
            {
                readline = Console.ReadLine();
                if (readline == "done") { break; } else if (readline == "") { continue; }
                theFile.WriteLine(readline);
                ListofCompRect.Add(new CompRect(readline));
            }

            Console.WriteLine("----------------------");
            theFile.WriteLine("----------------------");

            ListofCompSystem.Add(new CompSystem(ListofCompRect));

            Console.WriteLine(ListofCompSystem.Last().ToString());
            theFile.WriteLine(ListofCompSystem.Last().ToString());

            Console.WriteLine("Press Enter to Output and quit");
            readline = Console.ReadLine();
            theFile.Close();
            
 
        }

        static void DefaultInput()
        {

            List<CompRect> ListofCompRect = new List<CompRect>();
            List<CompSystem> ListofCompSystem = new List<CompSystem>();

            

            System.IO.StreamReader theFile = new System.IO.StreamReader("DefaultInput.txt");
            System.IO.StreamWriter OutPut = new System.IO.StreamWriter("DefaultOutput.txt");

            string readline = "";
            Console.WriteLine("Input");
            OutPut.WriteLine("Input\n b, h, cx, cy");
            int count = 1;
            while (!theFile.EndOfStream)
            {
                readline = theFile.ReadLine();
                Console.WriteLine(readline);
                OutPut.Write("[{0}]", count);
                count++;
                OutPut.WriteLine(readline);
                if (readline == "done") { break; } else if (readline == "") { continue; }

                ListofCompRect.Add(new CompRect(readline));
            }
            CompSystem CurrentSystem = new CompSystem(ListofCompRect);

            Console.WriteLine("----------------------");
            Console.WriteLine(CurrentSystem.ToString());
            Console.WriteLine("Press Enter to Output and quit");

            OutPut.WriteLine("-----------------------");
            OutPut.WriteLine(CurrentSystem.ToString());


            readline = Console.ReadLine();
            theFile.Close();
            OutPut.Close();
        }
    }

    


    class CompSystem
    {
        public List<CompRect> ListofComp;
        public double cx_, cy_; //centers of gravity.
        public double Ixtot, Iytot; //moments of inertia.
        public double hsystem, bsystem;
        
        
        
        public CompSystem(List<CompRect> ListofComp)
        {
            Ixtot = 0; Iytot = 0; cx_ = 0; cy_ = 0;
            this.ListofComp = ListofComp;
            double[] cgarray = CGfromListofcomprect(ListofComp);
            cx_ = cgarray[0]; cy_ = cgarray[1];
            for(int i = 0 ; i<ListofComp.Count;i++)
            {
                CompRect x = ListofComp[i];
                x.rx = x.cx - cx_; x.ry = x.cy - cy_;
                x.Arx2 = x.A * x.ry * x.ry;
                x.Ary2 = x.A * x.ry * x.ry;
                x.Ix_ = x.Ixloc + x.A * x.ry * x.ry;
                x.Iy_ = x.Iyloc + x.A * x.rx * x.rx;
                ListofComp[i] = x;
            }

            Ixtot = SumIx_(ListofComp);
            Iytot = SumIy_(ListofComp);
            hsystem = 0; bsystem = 0;
            foreach (CompRect x in ListofComp)
            { hsystem += x.h; bsystem += x.b; }

        }


        static public double SumIx_(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Ix_; }
            return answer;
        }

        static public double SumIy_(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Iy_; }
            return answer;
        }

        static double[] CGfromListofcomprect(List<CompRect> listofcomprect)
        {
            double sumCxA = 0, sumA = 0, sumCyA = 0;
            foreach (CompRect x in listofcomprect)
            { sumCxA += x.A * (x.cx ); sumCyA += x.A * (x.cy ); sumA += x.A; }
            double CGx = sumCxA / sumA, CGy = sumCyA / sumA;
            double[] ans = new double[] { CGx, CGy };
            return ans;
        }

        public double Bending_Sig__M_I_y(double M, double y)
        {return (M * y) / Ixtot;}

        public double Bending_MaxSig__M_I_y(double M)
        {
            double cglow = cy_; double cghigh = hsystem - cy_;
            double y;
            if (cghigh >= cglow)
            { y = cghigh; }
            else
            { y = cglow; }
                return (M*y)/Ixtot;
        }


        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            //fix h system
            s.WriteLine("Height: {0:G5}[m] Breadth: {1:G5}[m]", hsystem, bsystem);
            s.WriteLine("Ixtot : {0:G5}[m^4] Iytot  : {1:G5}[m^4]", Ixtot, Iytot);
            s.WriteLine("C.G.  :({0:G5},{1:G5})[m]", cx_, cy_);
            int i = 0;
            foreach (CompRect x in ListofComp)
            { i++; s.WriteLine("INDEX : [{0}]", i); s.WriteLine(); s.WriteLine(x); s.WriteLine("--------------------------------------"); }

            return s.ToString();
        }
       

    }

    struct CompRect
    {
        public double b, h;
        public double cx, cy;//centre coordinate
        public double A;
        public double Ixloc;
        public double Iyloc;
        public double Arx2; public double Ary2;
        public double Ix_, Iy_;
        public double rx, ry;//radius direction from CG of system.

        //public double Ix_, Iy_;

        public CompRect (double b, double h, double cx, double cy)
        {

            this.b = b; this.h = h; this.cx = cx; this.cy = cy;
            A = b * h; 
            Ixloc = (b*h*h*h)/12;
            Iyloc = (b*b*b*h)/12;
            rx = 0; ry = 0;
            Arx2 = 0; 
            Ary2 = 0;
            Ix_ = 0; Iy_ = 0;

        }

        public CompRect(string a)
        {
            //(0.03, 0.08, 0.25, 0.04)
            char[] seperators = new char[] { ',', '(', ')', '[', ']', ' ' };
            
            string[] w = a.Split(seperators);
            List<string> l1 = new List<string>();

            for (int i = 0; i < w.Count(); i++)
            { if (w[i] != "" && IsDigit(w[i]) == true) { l1.Add(w[i]); } }

            
            
            this.b = double.Parse(l1[0]); this.h = double.Parse(l1[1]); this.cx = double.Parse(l1[2]); this.cy = double.Parse(l1[3]);
            A = b * h;
            Ixloc = (b * h * h * h) / 12;
            Iyloc = (b * b * b * h) / 12;
            rx = 0; ry = 0;
            Arx2 = 0;
            Ary2 = 0;
            Ix_ = 0; Iy_ = 0;
             
            
        }

        private static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false && achar != '.') return false;
                
                //achar != '.'|| achar!='0'
            }
            return true;
        }

        static public double SumIxLoc(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Ixloc; }
            return answer;
        }

        static public double SumIyLoc(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Iyloc; }
            return answer;
        }

        /*
        
        */
        static public double SumIx_(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Ix_; }
            return answer;
        }

        static public double SumIy_(List<CompRect> a)
        {
            double answer = 0;
            foreach (CompRect x in a)
            { answer += x.Iy_; }
            return answer;
        }


        // one option is that you takes a list of array of 2 numbers and do the compute the centres respectively and returns a new list of listcomprec
        static List<CompRect> ListofDimensionsToListCompRect(List<double[]> Listofdouble)
        {
            List<CompRect> ReturnList = new List<CompRect>();
            //want them to be of a certain order? top to bottom.
            double h = 0; foreach (double[] x in Listofdouble) { h += x[1]; ReturnList.Add(new CompRect(x[0], x[1], 0, 0)); }
            //top would be half of h
            //write one for cg.

            return ReturnList;
        }


        public override string  ToString()
{
    System.IO.StringWriter s = new System.IO.StringWriter();
    s.WriteLine("(b,h)=({0:G5},{1:G5})[m] ", b, h);
    s.WriteLine("(cx,cy)=({0:G5},{1:G5})[m]", cx, cy);
    s.WriteLine("(rx,ry)=({0:G5},{1:G5})[m]", rx, ry);
    s.WriteLine("A:     {0:E5}[m^2] = b*h", A);
    s.WriteLine("Ix:    {0:E5}[m^4] = (b*h^3)/12", Ixloc);
    s.WriteLine("Iy:    {0:E5}[m^4] = (b^3*h)/12", Iyloc);
    s.WriteLine("Arx2:  {0:E5}[m^4] = A*rx^2", Arx2);
    s.WriteLine("Ary2:  {0:E5}[m^4] = A*ry^2", Ary2);
    s.WriteLine("Ix_:  {0:E5}[m^4] = Ix + A*ry^2", Ix_);
    s.WriteLine("Iy_:  {0:E5}[m^4] = Iy + A*rx^2", Iy_);
    
    return s.ToString();
    
}
        

    }
}
