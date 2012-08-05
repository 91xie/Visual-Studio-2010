using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrussDraft1
{
    class Program
    {
        static void Main(string[] args)
        {
            List <GeneralTrusses> ListofTrusses = new List <GeneralTrusses>();

            
            Console.WriteLine("TrussProgram...");
            
            double[] answer = new double[] { };

            Console.Write("1) Add Truss 2) Calculate 3) Clear 4) Display All 5) Exit ... ");
            int selector = int.Parse(Console.ReadLine());
            while (selector != 5)
            {
                if (selector ==1)//Add Truss
                {
                    double x, y, kN;
                    Console.WriteLine("Direction (x,y)  Tension/Compression/Unknown +/-/0 (kN)");
                    Console.Write("x: "); x = double.Parse(Console.ReadLine());
                    Console.Write("y: "); y = double.Parse(Console.ReadLine());
                    Console.Write("kN:"); kN = double.Parse(Console.ReadLine());
                    ListofTrusses.Add(new GeneralTrusses(x, y, kN));
                    Console.Clear();
                    Console.WriteLine("ListofTrusses");
                    Console.WriteLine(GeneralTrusses.ListToString(ListofTrusses));
                    
                }
                else if (selector ==2)//Calculate
                {
                    Console.Clear();
                    Console.WriteLine("Calculate...");
                    answer = GeneralTrusses.SolutionTrussOutput(ListofTrusses);
            
                }
                else if (selector == 3)//Clear
                {
                    Console.Clear();
                    ListofTrusses.Clear();
                }
                else if (selector == 4)//Display all
                {
                    Console.Clear();
                    Console.WriteLine(GeneralTrusses.ListToString(ListofTrusses));
                }


                Console.Write("1) Add Truss 2) Calculate 3) Clear 4) Display All 5) Exit ... ");
                selector = int.Parse(Console.ReadLine());
            }


        }

        //Make an interface...
        //declare how many items on the list. OR have an option to ask you if you want to add another truss or not.
        //input information
        //
        public static string  Array1DToString (double [] a)
        {
            string output = "(";
            for (int i = 0; i < a.Length; i++)
            {
                output += string.Format( "{0:f2}", a[i]); if (i < a.Length - 1) { output += ","; } else { output += ")"; }
            }

            return output;
        }
        
        
        struct Force
        {
            public double i, j;
            public Force(double i, double j)
            { this.i = i; this.j = j; }

            public double Magnitude(Force a)
            {
                return Math.Sqrt(i * i + j * j);
            }
            public override string ToString()
            {
                return string.Format("i: {0} j:{1} Magnitude:{2}",i,j, Magnitude(this));
            }
        }

        class GeneralTrusses
        {
            //tension is +, compression is -
            public double x, y, tension_compression; private double alpha;
            private Force _ResultantForce;public Force ResultantForce { get { return _ResultantForce; } }
            private bool _known_unknown;public bool known_unknown {get {return _known_unknown;}}

            private static double SignSelector (double x_y, double cos_sin_alpha)
            {
                cos_sin_alpha = Math.Abs(cos_sin_alpha);
                if (x_y < 0)
                    cos_sin_alpha *= -1;
                else if (x_y == 0)
                    cos_sin_alpha = 0;

                return cos_sin_alpha;
            }
            public GeneralTrusses(double x, double y, double tension_compression)
            {//two types--- 0 tension_compression is unknown
                this.x = x;
                this.y = y;
                this.tension_compression = tension_compression;
                this.alpha = Math.Atan(y / x);
                if (tension_compression != 0)
                {
                    
                    this._known_unknown = true;
                    this._ResultantForce = new Force(tension_compression * Math.Cos(this.alpha), tension_compression * Math.Sin(this.alpha));


                }
                else
                {
                    this._known_unknown = false;
                    //if postive
                    //doesn't handle zeros; if term is non zero, use this method.
                    //if it is zero, ignore?
                    this._ResultantForce = new Force(SignSelector(x,Math.Cos(alpha)), SignSelector(y,Math.Sin(alpha)));
                }
            }

            public static double ComponentAdditioninList(List<GeneralTrusses> a, char componentselector, bool known_unknown_selector)
            {
                double answer = 0;

                if (componentselector == "i"[0])
                {
                    for (int i = 0; i < a.Count; i++)
                    { if (known_unknown_selector == a[i].known_unknown) { answer += a[i].ResultantForce.i; } }
                }
                else if (componentselector == "j"[0])
                {
                    for (int i = 0; i < a.Count; i++)
                    { if (known_unknown_selector == a[i].known_unknown) { answer += a[i].ResultantForce.j; } }
                }

                return answer;
            }

            public static string ListToString(List<GeneralTrusses> a)
            {
                System.IO.StringWriter s = new System.IO.StringWriter();
                for (int i = 0; i < a.Count; i++)
                { s.WriteLine("IndexNo:{0} {1}", i, a[i]); }
                return s.ToString();
            }

            public static double[] _1DKnownOutputs(List<GeneralTrusses> a)//both i and j and known
            {
                double answerx = ComponentAdditioninList(a, "i"[0], true);
                double answery = ComponentAdditioninList(a, "j"[0], true);
                return new double[] { answerx, answery };
            }

            public static double[,] _2DUnknownOutput(List<GeneralTrusses> a)
            {
                double[,] answer = new double[2, 2] {{0,0},{0,0} };
                //you don't add the unknowns.
                //for each component, do this check, if check is true proceed with putting bits into various places.
                int columnselector = 0;
                int noofruns = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].known_unknown == false && noofruns<2)
                    {
                        GeneralTrusses CurrentTruss = a[i];
                        answer[0,columnselector] = a[i]._ResultantForce.i;
                        answer[1, columnselector] = a[i]._ResultantForce.j;
                        columnselector++;
                        noofruns++;
                    }
                    
                }
                return answer;
            }
            //got your 2D, 1D, now return a 1D array of answers and write method to output that.

            public static double[] SolutionTrussOutput(List<GeneralTrusses> z)
            {

                double[] _1DSolutions = _1DKnownOutputs(z); double[,] _2DUnknown = _2DUnknownOutput(z);
                double x=0, y=0, a, b, c, i, j, k;
                a = _2DUnknown[0, 0]; b = _2DUnknown[0, 1]; c = _1DSolutions[0]*-1;
                i = _2DUnknown[1, 0]; j = _2DUnknown[1, 1]; k = _1DSolutions[1]*-1;
                Console.WriteLine("({0,3:f2},{1,3:f2})(x)={2}", a, b, c);
                Console.WriteLine("({0,3:f2},{1,3:f2})(y)={2}", i, j, k);
                
                y = (c * i - a * k) / (b * i - a * j);
                if (a != 0)
                    x = (c - b * y) / a;
                else
                    x = (k - j * y) / i;
                //reset values with x and y.
                double[] answer = new double[] { x, y };
                double[] indexarray = new double[] { 0, 0 };
                int answerinc = 0;
                Console.WriteLine("Before...");
                Console.WriteLine(ListToString(z));
                //put forces back in.
                for (int ii = 0; ii < z.Count && answerinc < 2; ii++)
                {
                    if (z[ii]._known_unknown == false)
                    {
                        z[ii]._known_unknown = true;
                        double currentforce = answer[answerinc];
                        z[ii].tension_compression = currentforce;
                        z[ii]._ResultantForce.i = currentforce * Math.Cos(z[ii].alpha);
                        z[ii]._ResultantForce.j = currentforce * Math.Sin(z[ii].alpha);


                        indexarray[answerinc] = ii;
                        answerinc++;
                    }
                }
                //Equation output
                
                Console.WriteLine("SolutionTrussOutput is Run");
                Console.WriteLine(ListToString(z));
                Console.WriteLine("Indexs {0} {1}", Array1DToString(indexarray),Array1DToString(answer));
                return new double[] { x, y };
            }

          
            public override string ToString()
            {
                return string.Format("(x,y) ({0,6:f2},{1,6:f2}) |Force: {2,6:f2}N (i,j) ({3,6:f2},{4,6:f2})", x,y,tension_compression,ResultantForce.i,ResultantForce.j);
            }

        }
    }
}
