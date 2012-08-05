using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double omega = 100*Math.PI;
            

            Console.ReadLine();

            
        }

        static double equation(double x)
        { return Signals.square((2 * Math.PI) / 5, x, 0) + 0.5; }
        
    }
    class Signals
    {
        public static double[,] ConvSum(function1 x, function1 h)
        {
            int n1 = 0, n2 = 100;//start and end points of n... get this from drawing out the graph
            int k1 = 0, k2 = n2;//start and end points ok... get range of values of k where x[k]!= 0;
            double[,] Y_n = new double[n2-n1+1, 2];
            double sum = 0;
            int i = 0;
            for (int n = n1; n <= n2; n++)
            {
                for (int k = k1; k <= n; k++)
                {
                    
                    sum += x(k)*h(n-k);
                    //EQUATION ^^^^^
                }
                Y_n[i, 0] = n; Y_n[i, 1] = sum;
                i++;
                Console.WriteLine("n{0} sum{1}", n, sum);
                sum = 0;
            }
            return Y_n;
        }
        public delegate double function1 (double x);
        public static double u(double a)
        { if (a >= 0) { return 1; } else { return 0; } }

        public static double r(double a)
        { { return a * u(a); } }

        public static double d(double a)
        { if (a == 0) { return 1; } else return 0; }

        public static double square(double w, double t, double phase)
        {
            if (Math.Sin(w * t + phase) > 0)
                return 0.5;
            else
                return -0.5;
        }

        public static Complex X(function1 xn, double k, double N)
        {
            double omega = (Math.PI * 2) / N;
            //returns X[k]
            Complex sum = Complex.newComplex();

            for (int n = 0; n <= N - 1; n++)
            {
                sum.Add(Complex.newComplexPolar(xn(n), -1 * k * n * omega));
            }

            return sum.ScaleBy(1/N);
            
        }
    }
   
    class polyterm
    {
        public double a, pow; string x;
        //set output test print.
        private static bool testprint = false;

        public polyterm()
        { this.a = 0.0; this.x = " "; this.pow = 0.0; }
        

        public polyterm(double a, string x, double pow)
        {this.a = a; this.x = x; this.pow = pow;}

        public double equateterm(double x)
        {return a * Math.Pow(x, pow);}
        //to multiply set the coefficient as a new polyterm.

        public static void ConsoleInterface1()
        {
            Console.Write("Input Equation");
            string equation = Console.ReadLine();
            Console.Write("Input Variables");
            string variables = Console.ReadLine();
            string[] splitvar = variables.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            polyterm[][] equ = polyterm.StringToEqu2(equation);


            Console.ForegroundColor = ConsoleColor.Red;
            double answer = polyterm.TotalPoly(equ, splitvar);
            Console.WriteLine(answer);
            
        }

        public static double FinalEqu1(string equation, string variables)
        {
            string[] splitvar = variables.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            polyterm[][] equ = polyterm.StringToEqu2(equation);


            Console.ForegroundColor = ConsoleColor.Red;
            return  polyterm.TotalPoly(equ, splitvar);
        }
        public static double equate1Var(List<polyterm> aList ,double x)
        {
            double sum = 0.0;
            foreach (polyterm a in aList)
            {sum += a.equateterm(x);}
            return sum;
        }

        public static double equate1Var(polyterm[] anArray, double x)
        {
            double sum = 0.0;
            foreach (polyterm a in anArray)
            { sum += a.equateterm(x); }
            return sum;
        }

        public static double equatePolyPlusPoly(polyterm[] anArray, string[] variables)
        {
            string[,] variables2 = new string [variables.Length, 2];
            char[] sep = new char[] { '=' , ' '};
            int i = 0;
            foreach (string avar in variables)
            {
                string[] splitavar1 = avar.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string term in splitavar1)
                {
                    if (IsDigit(term) == false)
                    { variables2[i, 0] = term; variables2[i, 1] = "0"; }
                    if (IsDigit(term) == true)
                    { variables2[i, 1] = term; break; }
                    
                }
                i++;

            }
            
            //check if input terms are present.
            

            for (i = 0; i <= variables2.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= anArray.GetUpperBound(0); j++)
                {
                    if (variables2[i, 0] == anArray[i].x)
                    {
                        break;
                    }
                    if (j == anArray.GetUpperBound(0)) { Console.WriteLine("Variable isn't present in Equation"); return 0; }
                }
            }

            i = 0;
            double sum = 0.0;
            foreach (polyterm aterm in anArray)
            {
                for (int j = 0; j <= variables2.GetUpperBound(0); j++)
                {
                    if (aterm.x == variables2[j, 0])
                    {
                        sum += aterm.equateterm(double.Parse(variables2[j, 1]));
                    }
                }
            }
            return sum;
        }


        public static double equatePolyXPoly(polyterm[] anArray, string[] variables)
        {
            string[,] variables2 = new string[variables.Length, 2];
            char[] sep = new char[] { '=', ' ' };
            int i = 0;
            foreach (string avar in variables)
            {
                string[] splitavar1 = avar.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string term in splitavar1)
                {
                    if (IsDigit(term) == false)
                    { variables2[i, 0] = term; variables2[i, 1] = ""; }
                    if (IsDigit(term) == true)
                    { variables2[i, 1] = term; break; }

                }
                i++;

            }

            if (testprint == true)
            {
                for (i = 0; i <= variables2.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= variables2.GetUpperBound(1); j++)
                    {
                        Console.Write("i[{0}]j[{1}]str[{2}]  ", i, j, variables2[i, j]);
                    }
                    Console.WriteLine();
                }
            }


            //check if input terms are present.



            for (i = 0; i <= variables2.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= anArray.GetUpperBound(0); j++)
                {
                    if (variables2[i, 0] == anArray[j].x)
                    {
                        
                        break;
                    }
                    
                }
            }

            i = 0;
            double mult = 1;
            foreach (polyterm aterm in anArray)
            {
                for (int j = 0; j <= variables2.GetUpperBound(0); j++)
                {
                    if (aterm.x == variables2[j, 0] || aterm.x == " ")
                    {
                        mult *= aterm.equateterm(double.Parse(variables2[j, 1]));
                        if (testprint == true) { Console.WriteLine("mult [{0}] aterm [{1}]", mult,aterm); }
                    }
                }
            }
            return mult;
        }

        public static double TotalPoly(polyterm[][] table, string[] variables)
        {
            double sum = 0.0;
            foreach (polyterm[] arow in table)
            { sum += equatePolyXPoly(arow, variables); }
            return sum;
        }


        public static polyterm[][] ListofArrayPolytoArrayArrayPoly(List<polyterm[]> table)
        {
            polyterm[][] array = new polyterm[table.Count][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = table[i];
            }
            return array;
        }

        public static double TotalPoly(List<polyterm []> aList, string[] variables)
        {
            polyterm[][] table = ListofArrayPolytoArrayArrayPoly(aList);
            double sum = 0;
            foreach (polyterm[] arow in table)
            { sum += equatePolyXPoly(arow, variables);  }
            return sum;
        }

        public static polyterm OneStringToMultPoly(string inputstring)
        {
            List<string> aList = new List<string>();
            
            bool inoORletter = IsDigit(inputstring[0]);
            bool jnoORletter = ChangeBool(inoORletter);
            int i = 0;
            int j = i;

                while (j <= inputstring.Length)
                {
                    
                    if (j == inputstring.Length-1 )
                    {
                        aList.Add(inputstring.Substring(i, inputstring.Length - i)); break;
                    }
                    j++;
                    
                    if (IsDigit(inputstring[i]) == inoORletter && IsDigit(inputstring[j]) == jnoORletter)
                    {
                        aList.Add(inputstring.Substring(i, j - i));
                        jnoORletter = ChangeBool(jnoORletter); inoORletter = ChangeBool(inoORletter); i = j;
                    }
                    
                }
                if (testprint == true)
                {
                    int printcount = 1;
                    foreach (string astring in aList)
                    {
                        Console.WriteLine("i[{0}] [{1}]", printcount, astring); printcount++;
                    }
                }
                
                double a=0.0, pow = 0.0; string x=" ";
                for (i = 0; i < aList.Count; i++)
                {
                    if (i == 0)
                    {
                        if (IsDigit(aList[i]) == true)
                        {a = double.Parse(aList[i]); }
                        else if (IsDigit(aList[i]) == false) x = aList[i];
                    }

                    else if (i > 0 && IsDigit(aList[i]) == true)
                    { pow = double.Parse(aList[i]); }

                    else if (i> 0 && IsDigit(aList[i]) == false)
                    {
                        x = aList[i];
                    }
                }
                if (x != " " && pow == 0.0)
                { pow = 1; }
                if (testprint == true)
                { Console.WriteLine("OneStringPoly a[{0}] x[{1}] pow[{2}]", a, x, pow); }
            
            return new polyterm(a,x,pow);
        }

        public static polyterm OneStringtoDivPoly(string inputstring)
        {
            polyterm aPoly = OneStringToMultPoly(inputstring);
            aPoly.a = 1 / aPoly.a; aPoly.pow *= -1;
            if (testprint == true) Console.WriteLine("OneStringtoDivPoly{0}",aPoly);
            return aPoly;
        }
        

        public static polyterm[] StringToMultPoly(string a)
        {
            string[] split1 = a.Split(new char[] { '*' }, System.StringSplitOptions.RemoveEmptyEntries);
            List<polyterm> aList = new List<polyterm>();

            for (int i = 0; i < split1.Length; i++)
            {
                aList.Add(OneStringToMultPoly(split1[i]));
            }

            polyterm[] anArray = new polyterm[aList.Count()];
            for (int i = 0; i < aList.Count(); i++)
            {
                anArray[i] = aList[i];
            }

            return anArray;

        }

        public static polyterm[] StringToMultDivPoly(string a)
        {
            bool isdivpres = false;
            foreach (char achar in a)
            {
                if (achar == '/')
                { isdivpres = true; }
            }
            if (isdivpres == false)
            { return StringToMultPoly(a); }

            char[] oper = new char[] { '*', '/' };
            string operlocation = "";

            foreach (char achar in a)
            {
                foreach (char ochar in oper)
                {
                    if (achar == ochar)
                    {operlocation += achar;}
                }
            }

            
            

            //now we have a location of repective operators.

            string[] split1 = a.Split(oper, System.StringSplitOptions.RemoveEmptyEntries);
            List<polyterm> aList = new List<polyterm>();
            for (int i = 0; i < split1.Length; i++)
            {
                if (i > 0)
                {
                    if (operlocation[i-1] == '*')
                    {
                        aList.Add(OneStringToMultPoly(split1[i]));
                        if (testprint == true) { Console.WriteLine(" [*] is used on [{0}]", split1[i]); }
                    }
                    else if (operlocation[i-1] == '/')
                    {
                        aList.Add(OneStringtoDivPoly(split1[i]));
                        if (testprint == true) { Console.WriteLine(" [/] is used on [{0}]", split1[i]); }
                    }

                }
                else
                {
                    aList.Add(OneStringToMultPoly(split1[i]));
                }
            }

            if (testprint == true)
            {
                foreach (polyterm ina in aList) { Console.WriteLine("[{0}]", ina); }
            }

            polyterm[] anArray = new polyterm[aList.Count()];
            for (int i = 0; i < aList.Count(); i++)
            {
                anArray[i] = aList[i]; //Console.Write("this"); Console.WriteLine(anArray[i]);
            }

            return anArray;

        }

        public static polyterm[][] StringToEqu(string a)
        {
            string[] split1 = a.Split(new char[] { ',', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            List<polyterm[]> aList = new List<polyterm[]>();
            for (int i = 0; i < split1.Length; i++)
            {
                aList.Add(StringToMultPoly(split1[i]));
            }

            return ListofArrayPolytoArrayArrayPoly(aList);
        }

        public static polyterm[][] StringToEqu2(string a)
        {
            string[] split1 = a.Split(new char[] { ',', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            List<polyterm[]> aList = new List<polyterm[]>();
            for (int i = 0; i < split1.Length; i++)
            {
                aList.Add(StringToMultDivPoly(split1[i]));
            }

            return ListofArrayPolytoArrayArrayPoly(aList);
        }




        public static bool ChangeBool(bool a)
        {
            if (a == true) return false;
            else return true;
        }


        public static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {if (char.IsDigit(achar) == false && achar != '-' && achar != '.') return false;}
            return true;
        }

        public static bool IsDigit(char achar)
        {
            if (char.IsDigit(achar) == false && achar != '-' && achar != '.') { return false; } 
            else if (char.IsDigit(achar) == true || achar == '-' || achar == '.') {return true;}
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}^{2}",a,x,pow);
        }

        //you can have an array of an array of polyterms. each array in the array would be multiplied with each other.

        
    }

    class polynomial
    {
        List<polyterm> equation;

        public polynomial(List<polyterm> equation)
        {
            this.equation = equation;//instantiate an equation by adding up all respective bits together.
            //add like powers together.
            //don't really need to add to the list.



        }


        public double equate(double x)
        {
            double sum = 0;
            foreach (polyterm apoly in this.equation)
            {
                sum += apoly.equateterm(x);
            }
            return sum;
        }
        

    }
    
    class Tests
    {
        
        public static void testplot1()
        {
            double w = Math.PI / 5;
            double[] ns = MathMethods.MatlabVector(0, 1, 100);
            double[] ys = new double[ns.Length];
            for (int i = 0; i < ns.Length; i++)
            {
                ys[i] = Signals.u(Math.Sin(w * ns[i]));
            }
            Matrix.Plot("PlotofX.m", "stem", "n", "y", ns, ys);


            double[,] xandy = Signals.ConvSum();

            double[] ns2 = new double[xandy.GetUpperBound(0) + 1];
            double[] ys2 = new double[xandy.GetUpperBound(0) + 1];
            for (int i = 0; i <= xandy.GetUpperBound(0); i++)
            {
                ns2[i] = xandy[i, 0];
                ys2[i] = xandy[i, 1];
            }

            Matrix.Plot("PlotofY.m", "stem", "n", "y", ns2, ys2);
            Console.ReadLine();
        }


        public static void EquPlot1()
        {
            string equation ="3x3/2";
            string var = "x";
            double[] xs = MathMethods.MatlabVector(0, 0.01, 10);
            double[] ys = new double[xs.Count()];

            for (int i = 0; i < ys.Count(); i++)
            {
                string varx = string.Format("{0} = {1}", var, xs[i]);
                ys[i] = polyterm.FinalEqu1(equation, varx);
            }

            Matrix.Plot("EquPlot1.m", "plot", "x", "y", xs, ys);
        }


        public static void Plot1()
        {
            double [] xs = MathMethods.MatlabVector(0, 0.01, 10*Math.PI);
            double[] ys = new double[xs.Count()];
            for (int i = 0; i < ys.Count(); i++)
            {
                ys[i] = PlotEq(xs[i]);
                Console.WriteLine("[{0}]({1,5:G2},{2,5:G2})", i, xs[i], ys[i]);
            }

            string xlabel = "x", ylabel = "y";
            string filename = "cosx.m";
            Console.WriteLine("{0}\t{1}\t{2}", xlabel, ylabel, filename);

            Matrix.Plot(filename,"plot", xlabel, ylabel, xs, ys);
        }

        public static double PlotEq(double x)
        { return Math.Cos(x);}

        public static void PolyTest5withDiv()
        {
            string a = "-3x2", b = "4y1";

            string ar = string.Format("{0},{1},{0}/{1}", a, b);
            Console.WriteLine(ar);
            polyterm[][] equ = polyterm.StringToEqu2(ar);
            

            Console.ForegroundColor = ConsoleColor.Red;
            double answer = polyterm.TotalPoly(equ, new string[] { "x=2", "y=2" });
            Console.WriteLine(answer);
        }
        public static void PolyTest4()
        {
            string a = "-3x2", b = "4y1";

            string ar = string.Format("{0},{1},{0}*{1}", a, b);
            Console.WriteLine(ar);
            polyterm[][] equ = polyterm.StringToEqu(ar);
            foreach (polyterm[] arow in equ)
            {
                foreach (polyterm apoly in arow)
                {
                    Console.Write("{0},", apoly);
                } Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            double answer = polyterm.TotalPoly(equ, new string[] { "x=2", "y=2" });
            Console.WriteLine(answer);

        }
        public static void PolyTestMult3()
        {
            polyterm[] multiplepolys = new polyterm[] { new polyterm(1, "y", 2)};
            string[] variables = new string[] { "z=2", "y=1" };
            Console.WriteLine(polyterm.equatePolyXPoly(multiplepolys, variables));
        }
        public static void PolyTest2()
        {
            polyterm[][] equation = new polyterm[][] { new polyterm[] { new polyterm(3, "x", 1), new polyterm(1, "y", 1) }, new polyterm[] { new polyterm(1, "x", 2), new polyterm(1, "y", 2) } };
            polyterm[] multiplepolys = new polyterm[] { new polyterm(1, "x", 2), new polyterm(1, "y", 2) };
            string[] variables = new string[] { "x=2", "y=2" };
            
            Console.WriteLine(polyterm.TotalPoly(equation, variables));
        }
        public static void PolyTest1()
        {
            string[] variables = new string[] { "x=5", "y=4" };
            polyterm[] anArray = new polyterm[] { new polyterm(1, "x", 1), new polyterm(1, "y", 2) };
            Console.WriteLine(polyterm.equatePolyPlusPoly(anArray, variables));
        }

        public static void TrapVolTest()
        {
            int m = 1000;
            double ax = -2, bx = 2, ay = -2, by = 2;
            double hx = (bx - ax) / m;
            double hy = (by - ay) / m;
            double[] xs = MathMethods.MatlabVector(ax, hx, bx);
            double[] ys = MathMethods.MatlabVector(ay, hy, by);
            double[] zs = new double[xs.Length];
            List<Vector3D> aList = new List<Vector3D>();
            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    zs[i] = MathMethods.fVol(xs[i], ys[j]);
                    aList.Add(new Vector3D(xs[i], ys[j], zs[i]));
                }
            }


            Console.WriteLine("done");

            
        }

        public static void DiffTest()
        {
            int hn = 15;
            double[] hs = new double[hn + 1];

            for (int i = 0; i < hs.Length; i++)
            { hs[i] = Math.Pow(10, -i); }



            double[] diffs = new double[hn + 1];
            double[] delta = new double[hn + 1];
            for (int i = 0; i < hs.Length; i++)
            {
                diffs[i] = MathMethods.Diff2Point(Math.PI / 3, hs[i]);
                delta[i] = Math.Abs(0.5 - diffs[i]);
            }


            double[,] totaltable = new double[hn + 1, 3];
            for (int i = 0; i < hs.Length; i++)
            {
                totaltable[i, 0] = hs[i];
                totaltable[i, 1] = diffs[i];
                totaltable[i, 2] = delta[i];
            }
            Console.WriteLine("1. hs 2. diffs 3. delta");
            Matrix.Print(totaltable);
        }
        public static void TrapTest()
        {
            double [] xs = MathMethods.MatlabVector(0, 0.05, 5);
            Matrix.Print(xs);
            double[] ys = new double[xs.Length];
            List<Vector3D> aList = new List<Vector3D>();
            int i = 0;
            foreach (double x in xs)
            {
                aList.Add(new Vector3D(xs[i], MathMethods.fSimpRule(xs[i]),0));
                i++;
            }

            Console.WriteLine("TrapRule {0} ",MathMethods.TrapRule(aList));
        }

    }


    //take a string 1,2,3 or [1 2 3] or (1 2 3)// ALL of them are 3D vectors anyway.
    class MathMethods
    {
        public static double LinearInterpolate(double x1, double y1, double x2, double y2, double xn)
        {
            return ((y2 - y1) / (x2 - x1)) * (xn - x1) + y1;
        }

        public static double UnitStep(double a)
        { if (a >= 0) { return 1; } else { return 0; } }

        public static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false && achar != '-' && achar != '.') return false;

            }
            return true;
        }
        


        //VOLUME ESTIMATION
        public static double fVol(double x, double y)
        {return x*x +3*x +2*y + x*y +5;}

        public static double VolEstSimpRule(double ax, double bx, double y, int m)
        {
            double h = (bx - ax) / (2 * m);
            double[] x = new double[2 * m + 1];
            x[0] = ax;

            for (int i = 1; i <= 2 * m; i++)
            { x[i] += x[i - 1] + h; }

            
            double sumfx1 = 0;
            for (int i = 1; i <= m; i++)
            { sumfx1 += fVol(x[2 * i - 1],y); }

            double sumfx2 = 0;

            for (int i = 1; i <= m - 1; i++)
            {
                sumfx2 += fVol(x[2 * i],y);
            }

            return (h / 3) * (fVol(ax, y) + 4 * sumfx1 + 2 * sumfx2 + fVol(bx,y));
        }


        public static double VolEst(double ax, double bx, double ay, double by, int m)
        {
            double h = (by - ay) / (2 * m);
            double[] y = new double[2 * m + 1];
            y[0] = ay;

            for (int i = 1; i <= 2 * m; i++)
            { y[i] += y[i - 1] + h; }
            //y matrix
            
            
            
            int j = 0;
            double sumVol = 0;
            foreach (double y1 in y)
            {
                sumVol+=h*VolEstSimpRule(ax, bx, y1, m);
                j++;
            }

            return sumVol;
        }

        public static double VolEstAv(double ax, double bx, double ay, double by, int m)
        {
            double run1 = VolEst(ax, bx, ay, by, m);
            double run2 = VolEst(ay, by, ax, bx, m);
            return (run1 + run2)/2;
        }

        
        public static double VolEstTrapRule(List<Vector3D> aList)
        {
            //just consider x's and z's;

            //each x needs to be distinct.
            double[,] xys = new double[aList.Count, 2];
            double[] xs = new double[aList.Count];
            int i = 0;

            foreach (Vector3D a in aList)
            { xs[i] = a.x; i++; }

            Array.Sort(xs);



            i = 0;
            foreach (double x in xs)
            { xys[i, 0] = x; i++; }


            for (i = 1; i < xs.Length; i++)
            {
                if (xs[i] == xs[i - 1])
                {
                    Console.WriteLine("x's coordinates are not all unique");
                    return 0;
                }
            }



            for (i = 0; i < aList.Count; i++)
            {
                for (int j = 0; j < aList.Count; j++)
                {
                    if (xys[i, 0] == aList[j].x)
                    { xys[i, 1] = aList[j].z; }
                }
            }


            double sum = 0;

            for (i = 0; i < xys.GetUpperBound(0); i++)
            { sum += (xys[i + 1, 0] - xys[i, 0]) * ((xys[i, 1] + xys[i + 1, 1]) / 2); }

            return sum;
        }

        //VOLUME ESTIMATIONXXXX






        //DIFFERENTIAL

        static double fDiff(double x)
        {return Math.Sin(x);}

        public static double Diff2Point(double x, double h)
        {return (fDiff(x + h) - fDiff(x - h)) / (2*h);}

        //DIFFERENTIALXXXXXXX

        //BISECTION.......
        static double fBisection(double x)
        {return Math.Exp(-x) - (x);}

        static bool BisectionValid(double a, double b)
        {
            if (fBisection(a) * fBisection(b) < 0) return true;
            else return false;
        }

        public static double BisectionMethod(double x1, double x2, double eps)
        {
            double a = x1; double b = x2;
            //starting values for x1 and x2... only works if they are on opposite side of the equation. you also need an equation.
            double m=0, fm;

            fm = 1000000;
                

            while (fm> eps)
            {
                    {
                        m = (a + b) / 2;
                        fm = fBisection(m);
                        if (fBisection(a) * fm < 0) { b = m; }
                        else if (fBisection(b) * fm < 0) { a = m; }
                    }
                    
            }
                
                return m;

        }
        
        public static string BisectionConsoleWriteLine (double x1, double x2, double eps)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("x1=({0}) x2=({1}) iterations=({2})", x1, x2, eps);
            if (BisectionValid(x1, x2) == true)
            {
                s.WriteLine("Bisection Valid = TRUE");
                s.WriteLine("m=({0})", BisectionMethod(x1, x2, eps));
            }
            else { s.WriteLine("Bisection Valid = FALSE"); }
            return s.ToString();
        }
        //BISECTIONXXXXXXXXXXX

        //ITERATIONS.......
        static double fIteration(double x)
        {//
            //compute squareroot of 3...
            return (0.5) * (3 / x + x);
        }

        public static double IterationMethod(double startvalue, int iterations)
        {
            double x = startvalue;
            //assuming that it is lipschitz whatever...
            for (int i = 0 ; i < iterations; i++)
            {
                Console.WriteLine("i({0}) x({1})", i, x);
                x = fIteration(x);
                
            }
            return x;
            
        }
        
        //ITERATIONSXXXXXXXXXX


        //SimpsonsRule

        public static double fSimpRule(double t)//put equation here.
        { return 4 * t * t * t - 15 * t * t + 2 * t + 5; }

        public static double SimpRule(double a, double b, int m)
        {
            double h = (b - a) / (2 * m);
            double[] x = new double[2*m+1];
            x[0] = a;
            
            for (int i = 1; i <= 2*m; i++)
            {x[i] += x[i - 1] + h;}

            double sumfx1 = 0;
            for (int i = 1; i <= m; i++)
            { sumfx1 += fSimpRule(x[2 * i - 1]); }

            double sumfx2 = 0;

            for (int i = 1; i <= m - 1; i++)
            {
                sumfx2 += fSimpRule(x[2 * i]);
            }

            



            return (h / 3) * (fSimpRule(a) + 4 * sumfx1 + 2 * sumfx2 + fSimpRule(b));
        }

        public static double[] MatlabVector(double a, double delta, double b)
        {
            List<double> aList = new List < double> ();

            double x = a;
            aList.Add(x);
            while (x < b -delta)
            {
                x += delta;
                aList.Add(x);
            }

            double[] output = new double[aList.Count];
            int i = 0;
            foreach (double ax in aList)
            {
                output[i] = ax;
                i++;
            }
            return output;
        }
        //SimpRulexxxxxxxxxx

        //TrapRule

        public static double TrapRule(List<Vector3D> aList)
        {
            //just consider x's and y's;

            //each x needs to be distinct.
            double[,] xys = new double[aList.Count,2];
            double[] xs = new double[aList.Count];
            int i = 0;
            
            foreach (Vector3D a in aList)
            { xs[i] = a.x; i++; }

            Array.Sort(xs);



            i = 0;
            foreach (double x in xs)
            { xys[i, 0] = x; i++; }
            

            for (i = 1; i < xs.Length; i++)
            {
                if (xs[i] == xs[i - 1])
                {
                    Console.WriteLine("x's coordinates are not all unique");
                    return 0;
                }
            }

            

            for (i = 0; i < aList.Count; i++)
            {
                for (int j = 0; j < aList.Count; j++)
                {
                    if (xys[i, 0] == aList[j].x)
                    {xys[i, 1] = aList[j].y;}
                }
            }

            
            double sum = 0;
            
            for (i = 0; i < xys.GetUpperBound(0); i++)
            { sum += (xys[i + 1,0] - xys[i,0]) * ((xys[i,1] + xys[i+1,1]) / 2); }

            return sum;
        }

        //TrapRULEXXX



     }//

    class Vector3D
    {

        public double x, y, z;
        // Constructors
        public Vector3D() { x = 0; y = 0; z = 0; }
        public Vector3D(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        public Vector3D(Vector3D a) { x = a.x; y = a.y; z = a.z; }
        public Vector3D(double[] a) { x = a[0]; y = a[1]; z = a[2]; }
        public Vector3D(string a)
        {
            x = 0; y = 0; z = 0;
            char[] sep = new char[] { ',', ' ' };
            string[] segments = a.Split(sep);

            List<string> segments2 = new List<string>();
            foreach (string ofsegments in segments)
            {
                if (ofsegments != "")
                {
                    segments2.Add(ofsegments);
                }
            }



            List<double> listofstringno = new List<double>();
            for (int i = 0; i < segments2.Count; i++)
            {
                if (IsDigit(segments2[i]))
                {
                    listofstringno.Add(double.Parse(segments2[i]));
                }
            }

            x = listofstringno[0]; y = listofstringno[1]; z = listofstringno[2];

        }


        // readonly properties
        public double Magnitude { get { return Math.Sqrt(x * x + y * y + z * z); } }
        public Vector3D UnitVector { get { return new Vector3D(this / this.Magnitude); } }

        // Instance Methods
        public double DotProduct(Vector3D a) { return a.x * x + a.y * y + a.z * z; }
        public Vector3D CrossProduct(Vector3D b)
        {
            double p = y * b.z - z * b.y;
            double q = z * b.x - x * b.z;
            double r = x * b.y - y * b.x;
            return new Vector3D(p, q, r);
        }
        public void ScaleBy(double scale) { x /= scale; y /= scale; z /= scale; }

        // Static methods
        public static double DotProduct(Vector3D a, Vector3D b) { return a.DotProduct(b); }
        public static Vector3D CrossProduct(Vector3D a, Vector3D b) { return a.CrossProduct(b); }

        // Overloaded operators
        public static Vector3D operator +(Vector3D a, Vector3D b)
        { return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z); }

        public static Vector3D operator -(Vector3D a, Vector3D b)
        { return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z); }

        public static Vector3D operator *(Vector3D a, double scale)
        { return new Vector3D(a.x * scale, a.y * scale, a.z * scale); }

        public static Vector3D operator *(double scale, Vector3D a)
        { return new Vector3D(a.x * scale, a.y * scale, a.z * scale); }

        public static Vector3D operator /(Vector3D a, double divisor)
        { return new Vector3D(a.x / divisor, a.y / divisor, a.z / divisor); }

        public static List<Vector3D> StringToListofVector(string a)
        {
            List<Vector3D> ListofVector = new List<Vector3D>();
            char[] seperators = new char[] { ',', '(', ')', ' ', '\n' };

            string[] w = a.Split(seperators);
            List<string> l1 = new List<string>();

            for (int i = 0; i < w.Count(); i++)
            { if (w[i] != "" && IsDigit(w[i]) == true) { l1.Add(w[i]); } }

            for (int i = 0; i * 3 + 2 < l1.Count(); i++)
            {
                double x, y, z;
                x = double.Parse(l1[(i * 3)]);
                y = double.Parse(l1[(i * 3) + 1]);
                z = double.Parse(l1[(i * 3) + 2]);

                ListofVector.Add(new Vector3D(x, y, z));


            }

            return ListofVector;
        }

        private static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false && achar!= '-' && achar!='.') return false;

            }
            return true;
        }

        // Overriden methods
        public override string ToString() { return "(" + x + ", " + y + ", " + z + ")"; }

        public static string ListToString(List<Vector3D> a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            for (int i = 0; i < a.Count; i++)
            {
                s.WriteLine(a[i]);
            }
            return s.ToString();
        }



        // Destructor
        ~Vector3D() { Console.WriteLine("Vector3D object finally deleted"); }
    }

    class Complex
    {
        static List<Complex> ListofComplex = new List<Complex>();
        
        public double x, y;
        public double mod { get { return Math.Sqrt(x * x + y * y); } }
        public double arg { get { return Math.Atan(y / x); } }

        
        Complex()
        { this.x = 0; this.y = 0; }
        Complex(double x, double y)
        { this.x = x; this.y = y; }
        Complex(double[] a)
        { this.x = a[0]; this.y = a[1]; }
        Complex(Complex a)
        { this.x = a.x; this.y = a.y; }

        public static Complex newComplexPolar(double mod, double arg)
        {Complex a = new Complex(mod * Math.Cos(arg), mod * Math.Sin(arg));ListofComplex.Add(a); return a;}
        public static Complex newComplex(double x, double y)
        {Complex a = new Complex(x, y);ListofComplex.Add(a);return a;}
        public static Complex newComplex(double[] a)
        { Complex aa = new Complex(a); ListofComplex.Add(aa); return aa; }
        public static Complex newComplex(Complex a)
        { Complex b = new Complex(a); ListofComplex.Add(b); return b; }
        public static Complex newComplex()
        { Complex a = new Complex(); ListofComplex.Add(a); return a; }
        


        public static void PrintAllComplex()
        {
            foreach (Complex a in ListofComplex)
            { Console.WriteLine(a); }
        }

        public Complex Add(Complex a)
        { return new Complex(a.x + this.x, a.y + this.y);}
        public static Complex Add(Complex a, Complex b)
        { return new Complex(a.x + b.x, a.y + b.y); }

        public Complex Subtract(Complex a)
        { return new Complex(this.x - a.x, this.y - a.y); }
        public static Complex Subtract(Complex a, Complex b)
        { return new Complex(a.x - b.x, a.y - b.y); }

        public Complex Conjugate()
        { Complex a = new Complex(this);  a.y *= -1; return a; }
        public static Complex Conjugate(Complex a)
        { return new Complex(a.x, -1 * a.y); }

        public double Modulus()
        { return Math.Sqrt(x * x + y * y); }
        public static double Modulus(Complex a)
        { return Math.Sqrt(a.x * a.x + a.y * a.y); }

        public double Arg()
        { return Math.Atan(this.y / this.x); }
        public static double Arg(Complex a)
        { return Math.Atan(a.y / a.x); }

        public Complex Multiply(Complex a)
        {return new Complex(this.x * a.x - this.y * a.y, this.x * a.y + this.y * a.x);}
        public static Complex Multiply(Complex a, Complex b)
        { return new Complex(a.x * b.x - a.y * b.y, a.x * b.y + a.y * b.x); }

        public Complex Divide(Complex a)
        {
            Complex ans1 = this.Multiply(a);
            double denominator = 1 / (a.x * a.x + a.y * a.y);
            ans1.x *= denominator; ans1.y *= -1.0*denominator;
            return ans1;
        }
        public static Complex Divide(Complex a, Complex b)
        {
            Complex ans1 = a.Multiply(b);
            double denominator = 1 / (b.x * b.x + b.y * b.y);
            ans1.x *= denominator; ans1.y *= -1.0*denominator;
            return ans1;
        }
        public Complex Inverse()
        { return new Complex(1.0, 0).Divide(this); }
        public static Complex Inverse(Complex a)
        { return a.Inverse(); }
        public Complex ScaleBy(double a)
        { return new Complex(this.x * a, this.y * a); }
        public static Complex ScaleBy(Complex a, double x)
        { return a.ScaleBy(x); }

        public override string ToString()
        {
            if (this.y > 0)
            { return string.Format("{0} + {1}i", this.x, this.y); }
            else
            { return string.Format("{0} {1}i", this.x, this.y); }
        }

    }

    class Matlab
    {
        
    }

    class Matrix
    {

        public static double[,] Jacobi(double[,] A, double[,] B, double tol)
        {
            if (StrictlyDiagonalDom(A) == false)
            { Console.WriteLine("Not Strictly Diagonal Dominant"); return null; }

            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            double[,] L = LowerTriangle(A);
            double[,] U = UpperTriangle(A);
            double[,] D = Diagonal(A);



            for (int i = 0; i <= rowsinA; i++)
            {
                D[i, i] = 1 / D[i, i];
            }
            int xnewrows = rowsinA + 1;
            double[,] xnew = OnesMat(xnewrows, 1);
            double[,] xold = xnew;
            bool accuracyreached = false;

            while (accuracyreached == false)
            {
                accuracyreached = true;
                xnew = AddMat(ScaleMat(MulMat(MulMat(D, AddMat(L, U)), xnew), -1), MulMat(D, B));

                for (int i = 0; i < xnewrows; i++)
                {
                    if (Math.Abs(xnew[i, 0] - xold[i, 0]) > tol)
                    { accuracyreached = false; break; }

                }
                xold = xnew;
            }





            return xnew;
        }

        public static double[,] OnesMat(int i, int j)
        {
            double[,] xx = new double[i, j];
            for (int r = 0; r < i; r++)
            {
                for (int c = 0; c < j; c++)
                {
                    xx[r, c] = 1;
                }
            }
            return xx;
        }


        public static double[,] ScaleMat(double[,] A, double Scale)
        {
            for (int i = 0; i <= A.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= A.GetUpperBound(1); j++)
                {
                    A[i, j] *= Scale;
                }
            }
            return A;
        }

        public static bool StrictlyDiagonalDom(double[,] A)
        {
            double sum = 0;
            double diag = 0;
            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            for (int i = 0; i <= rowsinA; i++)
            {
                for (int j = 0; j <= columnsinA; j++)
                {

                    if (i != j)
                    {
                        sum += Math.Abs(A[i, j]);
                    }
                    else { diag = Math.Abs(A[i, j]); }
                }

                if (diag < sum) { return false; }
                sum = 0;

            }

            return true;

        }

        public static bool DiagonalDom(double[,] A)
        {
            double sum = 0;
            double diag = 0;
            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            for (int i = 0; i <= rowsinA; i++)
            {
                for (int j = 0; j <= columnsinA; j++)
                {

                    if (i != j)
                    {
                        sum += Math.Abs(A[i, j]);
                    }
                    else { diag = Math.Abs(A[i, j]); }
                }

                if (diag <= sum) { return false; }
                sum = 0;

            }

            return true;

        }

        public static double[,] Diagonal(double[,] A)
        {
            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            double[,] aDiagonal = new double[rowsinA + 1, columnsinA + 1];
            for (int i = 0; i <= rowsinA; i++)
            {
                aDiagonal[i, i] = A[i, i];
            }

            return aDiagonal;
        }


        public static double[,] LowerTriangle(double[,] A)
        {
            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            double[,] aLower = new double[rowsinA + 1, columnsinA + 1];
            for (int i = 1; i <= rowsinA; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    aLower[i, j] = A[i, j];
                }
            }

            return aLower;
        }

        public static double[,] UpperTriangle(double[,] A)
        {
            int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
            double[,] anUpper = new double[rowsinA + 1, columnsinA + 1];
            for (int i = 0; i < rowsinA; i++)
            {
                for (int j = i + 1; j <= columnsinA; j++)
                {
                    anUpper[i, j] = A[i, j];
                }
            }
            return anUpper;

        }

        public static double[,] Inverse(double[,] A)
        {
            if (A.GetUpperBound(0) != A.GetUpperBound(1))
            { return null; }
            int rowsinA = A.GetUpperBound(0);
            double[,] I = IdentityMat(rowsinA + 1);
            double[,] augAB = Gauss_Alg(A, I);
            BackSub(augAB);

            double[,] InvA = (Copy(augAB, 0, augAB.GetUpperBound(0), augAB.GetUpperBound(1) - augAB.GetUpperBound(0), augAB.GetUpperBound(1)));


            return InvA;

        }

        public static double[,] Copy(double[,] A, int i1, int i2, int j1, int j2)
        {
            int rowsinPaste = i2 - i1 + 1, columnsinPaste = j2 - j1 + 1;
            double[,] Paste = new double[rowsinPaste, columnsinPaste];
            for (int i = 0; i < rowsinPaste; i++)
            {
                for (int j = 0; j < columnsinPaste; j++)
                {
                    Paste[i, j] = A[i + i1, j + j1];
                }
            }
            return Paste;
        }

        public static void consoleinterface()
        {
            string select = "";
            for (; ; )
            {
                List<double[]> Listof1DA = new List<double[]>();
                List<double[]> Listof1DB = new List<double[]>();
                Console.WriteLine("Ax=B");
                Console.WriteLine("Input A:");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") break;
                    Listof1DA.Add(StringToMatrix(select));

                }

                select = "";
                Console.WriteLine("Input: B");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") { break; }
                    Listof1DB.Add(StringToMatrix(select));
                }

                double[,] A1 = List1DArrayto2DArray(Listof1DA);
                double[,] B1 = List1DArrayto2DArray(Listof1DB);

                Console.WriteLine("A:");
                Print(A1);
                Console.WriteLine("B:");
                Print(B1);

                Console.WriteLine("augAB:");


                double[,] augAB = Aug_AB(A1, B1);
                Print(augAB);
                double[,] ans = new double[A1.GetUpperBound(1), 1];

                if (A1.GetUpperBound(0) == A1.GetUpperBound(1))
                {
                    ans = Gauss_BackSub_Sol(A1, B1);
                }
                else
                {
                    ans = Least_Square(A1, B1);
                }
                Console.WriteLine("x:");
                Print(ans);

                Console.WriteLine();
                Console.WriteLine("Clear Window and New Run...");

                select = Console.ReadLine();
                if (select == "quit")
                { break; }

            }

        }



        public static bool IsDigit(string a)
        {
            if (a.Count() == 0) { return false; }
            foreach (char achar in a)
            {
                if (char.IsDigit(achar) == false && achar != '.' && achar != '-') return false;

                //achar != '.'|| achar!='0'
            }
            return true;
        }

        public static double[] StringToMatrix(string a)
        {
            char[] seperators = new char[] { '(', ',', ' ', ')' };
            string[] a1 = a.Split(seperators);
            List<double> a2 = new List<double>();

            foreach (string x in a1)
            {
                if (IsDigit(x) == true) { a2.Add(double.Parse(x)); }
            }
            double[] a3 = new double[a2.Count];
            for (int i = 0; i < a2.Count; i++) { a3[i] = a2[i]; }
            return a3;

        }


        public static double[,] List1DArrayto2DArray(List<double[]> a)
        {
            double[,] last = new double[a.Count, a[0].Count()];
            if (a[0].Count() > 1)
            {
                int check = a[0].Count();
                for (int i = 0; i < a.Count(); i++)
                {
                    if (a[i].Count() != check)
                    { Console.WriteLine("dimensions don't match"); return null; }
                    for (int j = 0; j < a[i].Count(); j++)
                    {
                        last[i, j] = a[i][j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < a.Count(); i++)
                {
                    last[i, 0] = a[i][0];
                }
            }
            return last;

        }

        public static double[,] Least_Square(double[,] A, double[,] B)
        {
            int rowsA = A.GetUpperBound(0), colsA = A.GetUpperBound(1);
            double [,] A_ = Matrix.MulMat(Matrix.Transpose(A),A);
            double[,] B_ = Matrix.MulMat(Matrix.Transpose(A), B);
            return Gauss_BackSub_Sol(A, B);
        }


        public static double[,] Transpose(double [,] A)
        {
            double[,] A_ = new double[A.GetUpperBound(1)+1, A.GetUpperBound(0)+1];
            for (int i = 0; i <= A_.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= A_.GetUpperBound(1); j++)
                {
                    A_[i, j] = A[j, i];
                }
            }
            return A_;

        }

        public static double[,] Gauss_Alg(double[,] A, double[,] B)
        {
            double[,] augAB = Aug_AB(A, B);
            int rowsinaugAB = augAB.GetUpperBound(0);
            int columnsinaugAB = augAB.GetUpperBound(1);

            for (int p = 0; p <= (augAB.GetUpperBound(0) - 1); p++)
            {
                //
                bool swapablerows = false;
                if (augAB[p, p] == 0)///////////////
                {
                    //if the pivot is equal to zero.
                    //if there is a value underneath the pivot not equal to zero, swappablerows are available.
                    //the rows are then swapped and continued.
                    for (int i = p; i <= augAB.GetUpperBound(0); i++)
                    {
                        if (augAB[i, p] != 0)
                        {
                            RowSwap(augAB, p, i); swapablerows = true;
                            break;
                        }

                    }
                    if (swapablerows == false) { Console.WriteLine("A not Invertible"); return null; }
                    //what happens if everything in a row is equal to zero? then there is no solution or that row in solution x_n  is equal to zero?
                }


                for (int i = p; i <= augAB.GetUpperBound(0); i++)
                { if (augAB[i, p] != 0) { RowScale(augAB, i, 1 / (augAB[i, p])); } }


                for (int i = p + 1; i <= augAB.GetUpperBound(0); i++)
                { if (augAB[i, p] != 0) { RowSub(augAB, p, i, i); } }

            }


            if (augAB[rowsinaugAB, rowsinaugAB] != 0)
            { RowScale(augAB, rowsinaugAB, 1 / augAB[rowsinaugAB, rowsinaugAB]); }


            return augAB;
        }

        public static double[,] BackSub(double[,] augAB)
        {
            for (int pp = augAB.GetUpperBound(0); pp > 0; pp--)
            {

                //you've got current row, now subtract current row from previous row.//not working across the entire row

                for (int pp2 = pp - 1; pp2 >= 0; pp2--)
                {
                    double scaler = augAB[pp2, pp];

                    if (scaler == 0) { continue; }
                    RowScale(augAB, pp, scaler);

                    RowSub(augAB, pp2, pp, pp2);

                    RowScale(augAB, pp, 1 / scaler);

                }

            }
            return augAB;
        }

        public static double[,] Gauss_BackSub_Sol(double[,] A, double[,] B)
        {

            double[,] augAB = Gauss_Alg(A, B);
            BackSub(augAB);
            double[,] sol = new double[augAB.GetUpperBound(0) + 1, 1];
            int lastcolumnofaugab = augAB.GetUpperBound(1), lastrowofaugab = augAB.GetUpperBound(0);

            for (int i = 0; i <= lastrowofaugab; i++)
            {
                sol[i, 0] = augAB[i, lastcolumnofaugab];
            }

            return sol;
        }




        public static void Print(double[] a)
        {
            foreach (double x in a) { Console.Write("{0,10:G5}", x); }
        }

        public static double[,] RowScale(double[,] A, int i, double scale)
        {
            int columnsofA = A.GetUpperBound(1);
            for (int j = 0; j <= columnsofA; j++)
            { A[i, j] *= scale; }

            return A;
        }

        //swaprows.
        public static double[,] RowSwap(double[,] A, int i1, int i2)
        {
            int columnsofA = A.GetUpperBound(1);
            double[] row1 = new double[columnsofA + 1];
            double[] row2 = new double[columnsofA + 1];
            for (int j = 0; j <= columnsofA; j++)
            {
                row1[j] = A[i1, j]; row2[j] = A[i2, j];
            }

            for (int j = 0; j <= columnsofA; j++)
            {
                A[i2, j] = row1[j]; A[i1, j] = row2[j];
            }

            return A;
        }

        public static double[] RowExtract(double[,] A, int i1)
        {
            int columnsofA = A.GetUpperBound(1);
            double[] row1 = new double[columnsofA + 1];
            for (int j = 0; j <= columnsofA; j++)
            {
                row1[j] = A[i1, j];
            }
            return row1;
        }

        public static double[,] RowCopyInto(double[,] A, double[] row1, int i1)
        {
            int columnsofA = A.GetUpperBound(1);

            for (int j = 0; j <= columnsofA; j++)
            {
                A[i1, j] = row1[j];
            }

            return A;
        }

        public static double[,] RowAdd(double[,] A, int i1, int i2, int i12)
        {
            int columnsofA = A.GetUpperBound(1);
            double[] row12 = new double[columnsofA + 1];

            for (int j = 0; j <= columnsofA; j++)
            {
                row12[j] = A[i1, j] + A[i2, j];
            }

            for (int j = 0; j <= columnsofA; j++)
            {
                A[i12, j] = row12[j];
            }

            return A;
        }

        public static double[,] RowSub(double[,] A, int i1, int i2, int i12)
        {
            int columnsofA = A.GetUpperBound(1);
            double[] row12 = new double[columnsofA + 1];

            for (int j = 0; j <= columnsofA; j++)
            {
                row12[j] = A[i1, j] - A[i2, j];
            }

            for (int j = 0; j <= columnsofA; j++)
            {
                A[i12, j] = row12[j];
            }

            return A;
        }

        public static double[,] Aug_AB(double[,] A, double[,] B)
        {
            double[,] augM = new double[A.GetUpperBound(0) + 1, A.GetUpperBound(1) + B.GetUpperBound(1) + 2];
            int rowsofAug = augM.GetUpperBound(0), columnsofAug = augM.GetUpperBound(1);
            int rowsofA = A.GetUpperBound(0), columnsofA = A.GetUpperBound(1);


            for (int i = 0; i <= rowsofAug; i++)
            {

                int j = 0;

                for (j = 0; j <= A.GetUpperBound(1); j++)
                    augM[i, j] = A[i, j];

                for (j = 0; j <= B.GetUpperBound(1); j++)
                    augM[i, j + A.GetUpperBound(1) + 1] = B[i, j];


            }

            return augM;

        }

        public static string matrixToString(double[,] a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();

            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer <= a.GetUpperBound(0))
            {
                while (columnincrementer <= a.GetUpperBound(1))
                {
                    s.Write("{0,10:G5}", a[rowincrementer, columnincrementer]);
                    columnincrementer++;
                }
                columnincrementer = 0;
                s.WriteLine();
                rowincrementer++;
            }

            return s.ToString();
        }

        public static void Print(double[,] a)
        {
            //System.IO.StringWriter s = new System.IO.StringWriter();

            int rowincrementer = 0, columnincrementer = 0;
            while (rowincrementer <= a.GetUpperBound(0))
            {
                while (columnincrementer <= a.GetUpperBound(1))
                {
                    Console.Write("{0,11:G5}", a[rowincrementer, columnincrementer]);
                    columnincrementer++;
                }
                columnincrementer = 0;
                Console.WriteLine();

                rowincrementer++;
            }

            Console.WriteLine();
        }

        public static double[,] MulMat(double[,] A, double[,] B)
        {

            int p = A.GetUpperBound(1);
            int q = B.GetUpperBound(0);
            if (p != q) return null;

            int n = A.GetUpperBound(0);
            int m = B.GetUpperBound(1);
            double[,] C = new double[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k <= p; k++)
                        C[i, j] += A[i, k] * B[k, j];
                }
            }
            return C;
        }

        public static double[,] AddMat(double[,] A, double[,] B)
        {
            int rowsofA = A.GetUpperBound(0), columnsofA = A.GetUpperBound(1);
            int rowsofB = B.GetUpperBound(0), columnsofB = B.GetUpperBound(1);
            if ((rowsofA != rowsofB) || (columnsofA != columnsofB))
            { return null; }

            double[,] AddAB = new double[rowsofA + 1, columnsofA + 1];

            for (int i = 0; i <= rowsofA; i++)
            {
                for (int j = 0; j <= columnsofA; j++)
                {
                    AddAB[i, j] = A[i, j] + B[i, j];
                }

            }

            return AddAB;

        }

        public static double[,] SubMat(double[,] A, double[,] B)
        {
            int rowsofA = A.GetUpperBound(0), columnsofA = A.GetUpperBound(1);
            int rowsofB = B.GetUpperBound(0), columnsofB = B.GetUpperBound(1);
            if ((rowsofA != rowsofB) || (columnsofA != columnsofB))
            { return null; }

            double[,] AddAB = new double[rowsofA + 1, columnsofA + 1];

            for (int i = 0; i <= rowsofA; i++)
            {
                for (int j = 0; j <= columnsofA; j++)
                {
                    AddAB[i, j] = A[i, j] - B[i, j];
                }

            }

            return AddAB;

        }

        public static double[,] IdentityMat(int p)
        {
            double[,] Id = new double[p, p];
            for (int i = 0; i < p; i++)
            {
                Id[i, i] = 1;
            }
            return Id;
        }

        public static void Plot(string filename, string plot_or_stem, string xlabel, string ylabel, double[] x, double[] y)
        {
            System.IO.StreamWriter s = new System.IO.StreamWriter(filename);
            s.Write(" {0} = [ ", xlabel);
            foreach (double ax in x)
            { s.Write("{0} ", ax); }
            s.WriteLine("];");

            s.Write(" {0} = [ ", ylabel);
            foreach (double ay in y)
            { s.Write("{0} ", ay); }
            s.WriteLine("];");

            s.WriteLine("figure;");
            s.WriteLine("{0}({1},{2});", plot_or_stem, xlabel, ylabel);
            s.WriteLine("xlabel('{0}'); ylabel('{1}')", xlabel, ylabel);

            s.Close();

        }

        

        
    }
    
}
    