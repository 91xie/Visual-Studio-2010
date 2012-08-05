using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Ass1_Draft1
{
    class Program
    {
        static void Main(string[] args)
        {//try adding in j values for which run you would be using...
            double pf = 1000, pp = 1100, mu = 0.0012;
            double D = 0.01 * 0.001;
            List<ParticleSettling> ListofParticleSettling = new List<ParticleSettling>();
            for (int i = 0; i < 10; i++)
            {
                if (i!=0)
                {D = D*2;}
                for(int j = 1; j<=3; j++)
                {
                    double u=0;
                    if (j==1){u=ParticleSettling.StokesU(D,pp,pf,mu);}
                    else if (j==2){u=ParticleSettling.TransitionalU(pf,pp,D,mu);}
                    else if (j==3){u=ParticleSettling.NewtonianU(D,pp,pf);}
                    //create new, if input type is equal to the output type than you would save that.
                    ParticleSettling aParticle = new ParticleSettling(D, pf, pp, mu, u);
                    
                    
                    if (j == aParticle.FlowType)
                    { ListofParticleSettling.Add(aParticle); }
                }
            }

            ParticleSettling.PartAPrintOutlabel(ListofParticleSettling, 2);


            //create a table of viscosity values for given values of D and u
            //viscosity values are present in Re, Stokes and Tran flows.
            //same values for desnity of fluid and particle

            Console.ForegroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            List<D_u_mu_Flow> ListofD_u_mu = new List<D_u_mu_Flow>();

            D = 0.1 * 0.001;
            double uD = 0.01* 0.001;
            double ijmu;
            double Re_ijmu;
            for (int i = 1; i <= 5; i++)
            {
                if (i != 1) { D *= 2; }

                for (int j = 1; j <= 15; j++)
                {
                    if (j != 1) { uD *= 2; }
                    //store D, u, mu at the end of this loop...

                    //compute values and check loop.
                    ijmu = ParticleSettling.mu_Stokes(D, pp, pf, uD);
                    Re_ijmu = ParticleSettling.Reynolds(D, uD, pf, ijmu);
                    if (Re_ijmu >= 0 && Re_ijmu <= 0.2)
                    {
                        ListofD_u_mu.Add(new D_u_mu_Flow(D, uD, Re_ijmu, 1));
                    }
                    else
                    {
                        ijmu = ParticleSettling.mu_Transitional(pp, pf, D, uD);
                        Re_ijmu = ParticleSettling.Reynolds(D, uD, pf, ijmu);
                        if (Re_ijmu <= 500)//
                        {
                            ListofD_u_mu.Add(new D_u_mu_Flow(D, uD, ijmu,2));
                        }
                    }

                    
                }

                uD = 0.01 * 00.1;
            }

            Console.WriteLine("CompleteList");
            Console.WriteLine(D_u_mu_Flow.OutputList1(ListofD_u_mu));

            List<D_u_mu_Flow> ListofStokes = new List<D_u_mu_Flow>();
            List<D_u_mu_Flow> ListofTran = new List<D_u_mu_Flow>();

            foreach (D_u_mu_Flow x in ListofD_u_mu)
            {
                if (x.Flowtype == 1)
                { ListofStokes.Add(x); }
                else { ListofTran.Add(x); }
            }

            Console.WriteLine("ListofStokes");
            Console.WriteLine(D_u_mu_Flow.OutputList1(ListofStokes));

            Console.WriteLine("ListofTran");
            Console.WriteLine(D_u_mu_Flow.OutputList1(ListofTran));


            

            //////////////////////////////////
            /////////////////////////////////

            /*

            List<D_u_mu_Flow> List2ofD_u_mu_Flow_Stokes = new List<D_u_mu_Flow>();
            List<D_u_mu_Flow> List2ofD_u_mu_Flow_Tran = new List<D_u_mu_Flow>();

            D = 0.1 * 0.001;
            uD = 0.01 * 0.001;
            ijmu = 0;
            Re_ijmu = 0;

            for (int i = 1; i <= 5; i++)
            {
                if (i != 1) { D *= 2; }
                for (int j = 1; j <= 15; j++)
                {
                    if (j != 1) { uD *= 2; }
                    double Remu = ParticleSettling.mu_Reynolds(D, uD, pf, 0);//
                    double Rem2 = ParticleSettling.mu_Reynolds(D, uD, pf, 0.2);
                    List2ofD_u_mu_Flow_Stokes.Add(new D_u_mu_Flow(D, uD, Remu, 1));
                    List2ofD_u_mu_Flow_Stokes.Add(new D_u_mu_Flow(D, uD, Rem2, 1));
                    double Rem3 = ParticleSettling.mu_Reynolds(D, uD, pf, 500);
                    List2ofD_u_mu_Flow_Tran.Add(new D_u_mu_Flow(D, uD, Rem2, 2));
                    List2ofD_u_mu_Flow_Tran.Add(new D_u_mu_Flow(D, uD, Rem3, 2));

                    //two Revalues per calculation.
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("ListofStokes");
            Console.WriteLine(D_u_mu_Flow.OutputList1(List2ofD_u_mu_Flow_Stokes));

            Console.WriteLine("ListofTran");
            Console.WriteLine(D_u_mu_Flow.OutputList1(List2ofD_u_mu_Flow_Tran));

             */
            ////////////////////////////////
            ////////////////////////////////
            Console.ReadLine();
        }

        struct D_u_mu_Flow
        {
            public double D, u, mu; public int Flowtype;
            public D_u_mu_Flow(double D, double u, double mu, int Flowtype)
            { this.D = D; this.u = u; this.mu = mu; this.Flowtype = Flowtype; }

            public string Output1()
            {
                string answer = string.Format("{0,12:G5}|{1,12:G5}|{2,12:G5}|", D, u, mu);
                if (this.Flowtype == 1)
                { answer += "Stokes"; }
                else if (this.Flowtype == 2)
                {answer += "Transitional";}
                return answer;
            }

            public static string OutputList1(List<D_u_mu_Flow> Listx)
            {
                System.IO.StringWriter s = new System.IO.StringWriter();
                string lD = "D", lu = "u" , lmu = "mu", lFlowType="FlowType";
                s.WriteLine("{0,12}|{1,12}|{2,12}|{3,12}", lD, lu, lmu, lFlowType);
                foreach (D_u_mu_Flow x in Listx)
                {
                    s.WriteLine(x.Output1());
                }
                return s.ToString();
            }
        }


        class ParticleSettling
        {
            //input test flow type...
            public double D, pf, pp, mu,u;
            public int FlowType { get { return _FlowType; } } private int _FlowType; //1. Stokes, 2. Transitional, 3. Newtonian
            public double xReynolds { get { return _xReynolds; } } private double _xReynolds;
            public double tu { get { return _tu; } } private double _tu;
            public double [] ReRange
            { get 
            {
                if (this._FlowType == 1)
                {
                    return new double[] { 0, 0.2 };
                }
                else if (this._FlowType == 2)
                {
                    return new double[] { 0.2, 500 };
                }
                else
                { return new double[] { 500 }; }
            
            } 
            }

            static double g = 9.81;

            public ParticleSettling(double D, double pf, double pp, double mu, double u)
            {
                this.D = D; this.pf = pf; this.pp = pp; this.mu = mu; this.u = u;
                this._xReynolds = Reynolds(D, u, pf, mu);
                if (this._xReynolds <= 0.2)
                { _FlowType = 1; _tu = StokesU(D, pp, pf, mu); }
                else if (this._xReynolds > 0.2 && this._xReynolds <= 500)
                { _FlowType = 2; _tu = TransitionalU(pf, pp, D, mu); }
                else if (this._xReynolds > 500)
                { _FlowType = 3; _tu = NewtonianU(D, pp, pf); }
                


            }

            public static double Reynolds(double D, double u, double pf, double mu)
            {
                return (D * u * pf) / mu;
            }

            public static double StokesU(double D, double pp, double pf, double mu)
            {
                return (g*D*D*(pp-pf))/(18*mu);
            }

            public static double TransitionalU(double pf, double pp, double D, double mu)
            {
                return (Math.Pow((g*(pp - pf)),0.779)*Math.Pow(D,1.338))/(13.6*Math.Pow(pf,0.221)*Math.Pow(mu,-0.559));
            }

            public static double NewtonianU(double D, double pp, double pf)
            {
                return 1.74*Math.Pow(  (g*D*(pp-pf)/(pf)   ), 0.5);
            }

            public static void PartAPrintOutlabel(List<ParticleSettling> ListofParticleSettling, int i)
            {

                if (i == 1)
                {
                    foreach (ParticleSettling x in ListofParticleSettling)
                    {
                        Console.Write(x.PartA(i));
                    }
                }
                else if (i == 2)
                {
                    string lD = "D", lu = "u", lxReynolds = "Re", lFlow = "FlowType";

                    Console.WriteLine("[{0,12}][{1,12}][{2,12}][{3,12}]", lD, lu, lxReynolds, lFlow);
                    foreach (ParticleSettling x in ListofParticleSettling)
                    {
                        Console.Write(x.PartA(i));
                    }

                }
            }


            public static double mu_Stokes(double D, double pp, double pf, double u)
            { return (g * D * D * (pp - pf)) / (18 * u); }

            public static double mu_Transitional(double pp, double pf, double D, double u)
            { return Math.Pow((Math.Pow((g * (pp - pf)), 0.779) * Math.Pow(D, 1.388)) / (13.6 *u* Math.Pow(pf, 0.221)),-0.559); }

            public static double mu_Reynolds(double D, double u, double pf, double Re)
            { return (D * u * pf) / (Re); }
            
            public string PartA(int i)
            {
                //1. label, 2. no label
                System.IO.StringWriter s = new System.IO.StringWriter();
                if( i == 1)
                {
                
                s.Write("D:[{0,12}] u:[{1,12}] Re:[{2,12}]", D, u, xReynolds);
                if (FlowType==1) {s.WriteLine("FlowType: Stokes");}
                else if (FlowType == 2) { s.WriteLine("FlowType: Transitional"); }
                else if (FlowType == 3) { s.WriteLine("FlowType: Newtonian"); }
                }


                else if (i==2)
                {
                    
                    s.Write("[{0,12}][{1,12:G5}][{2,12:G5}]", D, u, xReynolds);
                    
                if (FlowType==1) {s.WriteLine(          "[Stokes      ]");}
                else if (FlowType == 2) { s.WriteLine(  "[Transitional]"); }
                else if (FlowType == 3) { s.WriteLine(  "[Newtonian   ]"); }
                }
                return s.ToString();
            }

            
        }
        
    }
}
