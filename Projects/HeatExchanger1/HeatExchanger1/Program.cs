using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeatExchanger1
{
    class Program
    {
        struct Variable
        {
            public string Name; public double value;
            public Variable(string Name, double value)
            { this.Name = Name; this.value = value; }

            public override string ToString()
            {
                return Name + "   " + value;
            }
        }
        static void Main(string[] args)
        {
            //SHELL = WATER
            //TUBE = OIL

            List<Variable> aList = new List<Variable>();

            double _ktStainlessSteel = 19.0;
            double Tciwater = 50.0, Thioil = 220.0, Thooil = 176.0;
            double mcwater = (59100.0) / (60.0 * 60.0), mhoil = (284000.0) / (60.0 * 60.0);
            Console.WriteLine(mhoil);
            double pcwater = 950.0, phoil = 880.0;
            double ccwater = 4200.0, choil = 2220.0;
            double mucwater = 0.0003, muhoil = 0.003;
            double kcwater = 0.65, khoil = 0.1;
            //choose tube length step 7/8
            double _LPathLength = FeetToMetre(24);
            double _Uoass = 300;
            double _pt, _lbRatio = 0.45, _lb, _As, _vs;
                
            
            for (; ; )
            {
                Console.WriteLine("_Uoass = {0}", _Uoass);
                //step 1
                Console.WriteLine("Current _L pathlength, = {0}", _LPathLength);
                

                double Tco = ((choil * mhoil * (Thioil - Thooil)) / (mcwater * ccwater)) + Tciwater;

                Console.Write("Step1 ");
                Console.WriteLine("Tco = {0}", Tco);
                //step 2

                double _deltaTm = deltaTm(Thioil, Thooil, Tciwater, Tco);
                Console.Write("Step2 ");
                Console.WriteLine("detlaTm: {0}", _deltaTm);
                //step3

                Console.WriteLine("Step3");
                double _R = R(Thioil, Thooil, Tciwater, Tco);
                Console.WriteLine("_R = {0}", _R);
                double _S = S(Thioil, Tciwater, Tco);
                Console.WriteLine("_S = {0}", _S);

                double _Ft = 0.85;
                Console.WriteLine("Ft = {0}", _Ft);


                //Step 4/5
                double _Q = Q(mhoil, choil, Thioil, Thooil);
                Console.WriteLine("Q = {0}", _Q);


                double LowestpercU = 100000000000;
                double BestU = 0;
                double BestCalU = 0;



                Console.WriteLine("Uoass = {0}", _Uoass);

                double _A = _Q / (_Uoass * _deltaTm * _Ft);
                
                Console.WriteLine("Step 4/5");
                Console.WriteLine("_A = {0}", _A);
                //Console.ReadLine();
                //Step 6
                double _di = 0.01575, _do = 0.01905;
                double _ri = _di / 2, _ro = _do / 2;
                Console.WriteLine("Step 6");
                Console.WriteLine("di {0} do {1} ri {2} ro {3}", _di, _do, _ri, _ro);

                //step 7/8 CHOOSE TUBE LENGTH
                Console.WriteLine("Step 7/8");
                //choose tube length;

                 //12 feet
                Console.WriteLine("L = {0} m", _LPathLength);
                //determine Areas of ONE tube
                double _Ail = Math.PI * _di * _LPathLength;
                double _Aol = Math.PI * _do * _LPathLength;
                Console.WriteLine("Ai = {0}, Ao = {1} Internal and external areas of one tube", _Ail, _Aol);
                //divide total area by area of the tube.
                Console.WriteLine("Step 9");
                double N1 = Math.Ceiling(_A / _Aol);//no of tubes for one pass
                double N2 = N1 * 0.25; // this is so like cutting the lengths in 2 and thus you would need double the pieces to have the same length.
                
                Console.WriteLine("N1 of tubes in total = {0}", N1);
                Console.WriteLine("N2 of paths = {0}", N2);

                //Step 10 check velocity

                Console.WriteLine("Step10");
                double _Aic = Math.PI * _ri * _ri;
                Console.WriteLine("ri {0}", _ri);
                double _Qioil = mhoil / phoil;
                double _vhoil = _Qioil / (N2 * _Aic);

                Console.WriteLine("InnerTube Area{0}, VolumetricFlowrate {1}, Velocity of oil = {2},", _Aic, _Qioil, _vhoil);
                if (_vhoil <= 2 && _vhoil >= 1)
                {
                    Console.WriteLine("Velocity OK"); Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Velocity NOT OK"); 
                    //Console.ReadLine();

                    if (_LPathLength <= FeetToMetre(24)+0.1 && _LPathLength>= FeetToMetre(24) -0.1)
                    {
                        //_Uoass += 50;
                       // _LPathLength = FeetToMetre(8);
                        //Console.WriteLine("_Uoass has been increased to {0},", _Uoass);
                       // Console.WriteLine("_L has been reset to         {0},", _LPathLength);
                        //continue;
                    }
                    if (_LPathLength > FeetToMetre(8)-0.01 && _vhoil > 2)
                    { _LPathLength = _LPathLength - FeetToMetre(4); 
                    }
                    else if (_LPathLength < FeetToMetre(24) && _vhoil < 1)
                    { _LPathLength = _LPathLength + FeetToMetre(4); 
                    }
                    
                    Console.WriteLine("L has been changed to {0}", _LPathLength);
                    //Console.ReadLine();
                    continue;
                    
                }

                //Step 11 Determine Bundle Diameter
                double _K1 = 0.249, _n1 = 2.207;
                double _Db = _do * Math.Pow((N2 / _K1), 1.0 / (_n1));

                Console.WriteLine("Step 11");
                Console.WriteLine("K1 = {0} _n1 = {1} _Db = {2} Bundle Diameter", _K1, _n1, _Db);


                //Step 12 shell diameter
                //for utube
                double _Ds = 1.01 * _Db + 0.008;
                Console.WriteLine("Step 14 Shell Diameter");
                Console.WriteLine("_ShellDiameter = {0}", _Ds);

                //Step 13 Determine tube side heat transfer co
                double _Ret = Re(phoil, _vhoil, _di, muhoil);
                Console.WriteLine("Step 13");
                Console.WriteLine("phoil = {0}, _vhoil ={1} , _di = {2}, muhoil ={3}", phoil, _vhoil, _di, muhoil);
                Console.WriteLine("_Ret = {0}", _Ret);
                Console.WriteLine("L/D = {0} _L / _di", _LPathLength / _di);
                double _Prt = Prt(muhoil, choil, khoil);
                Console.WriteLine("_Prt = {0}", _Prt);
                double _jhi = 0.0035;
                Console.Write("INPUT jhi(Re,L/D) [0.0022] = . . . ");
                //_jhi = double.Parse(Console.ReadLine());

                double _Nut = _jhi * Math.Pow(_Ret, 0.8) * Math.Pow(_Prt, 1.0 / 3.0) * Math.Pow(1.1, 0.14);//muhoil / mucwater
                Console.WriteLine("_jhi = {0}, _Prt = {1}, _Nut= {2}", _jhi, _Prt, _Nut);
                // Nu is also equal to (hL/k)j
                //h = k*Nu/di
                double _ht = (khoil * _Nut) / _di;
                Console.WriteLine("_ht = {0} h for oil  (between 56-681", _ht);



                //oil in the tube
                for (; ; )
                {
                    //Step 14 Shell Side heat transfer Cof
                    Console.WriteLine("Step 14");
                    _pt = 1.25 * _do;
                    
                    _lb = _Ds * _lbRatio; //between 0.3 and 0.6// lb baffle spacing
                    _As = ((_pt - _do) * _Ds * _lbRatio) / (_pt);

                    _vs = mcwater / (pcwater * _As);
                    Console.WriteLine("_lbRatio = {0}", _lbRatio);
                    Console.WriteLine("_vs = {0}", _vs);
                    
                    if (_vs >= 0.3 && _vs <= 1)
                    { Console.WriteLine("Velocity shell is OK"); Console.ReadLine(); break; }
                    else 
                    { 
                        Console.WriteLine("Velocity shell not OK"); Console.ReadLine();
                        if (_vs < 0.3&& _lb<=1)
                        {
                            _lbRatio -= 0.01;
                        }
                        else if (_vs > 1 && _lb >= 0.2)
                        {
                            _lbRatio += 0.01;
                        }
                        else { Console.WriteLine("lbRatio and Velocity out of both ranges..."); Console.ReadLine(); break; }

                    }
                     
                    
                }

                double _Gs = mcwater / _As;
                double _de = (1.1 / _do) * ((_pt * _pt) - (0.917 * _do * _do));
                double _Res = Re(_Gs, _de, mucwater);
                double _BaffleCut = 0.35;
                Console.Write("Bafflecut(0.3) = ");
                //_BaffleCut = double.Parse(Console.ReadLine());
                Console.WriteLine("pt = {0}\n Shelldiameter = {1}\n As = {2}\n Gs = {3}\n de = {4}\n _Res = {5}\n _BaffleCut = {6}", _pt, _Ds, _As, _Gs, _de, _Res, _BaffleCut);
                double _jn = 0.0075;
                Console.Write("INPUT _jn [0.0075] for Re 5000, Bafflecut 30 = . . .");
                //_jn = double.Parse(Console.ReadLine());

                double _Prs = Prt(mucwater, ccwater, kcwater);

                double _Nus = _jn * _Res * Math.Pow(_Prs, 1.0 / 3.0) * Math.Pow(1.0, 0.14);//muhoil / mucwater
                double _hs = (kcwater * _Nus) / _de;

                Console.WriteLine("_Prs = {0}\n Nus = {1}\n _hs = {2} between 1703.479-11000", _Prs, _Nus, _hs);


                //Step 15 Calculate U
                Console.WriteLine("Step 15 Calculate U");


                //Typical ht and hs values
                double _Rfi = 0.0005, _Rfo = 0.000088;
                //_ht = 10000; _hs  =3000;
                //_Rfi = 0; _Rfo = 0;
                double _Uo = Math.Pow((_do / (_ht * _di)) + (_do * Math.Log(_do / _di)) / (2 * _ktStainlessSteel) + 1 / _hs + (_Rfi*_do)/_di + _Rfo, -1);
                //_Uo = Math.Pow((_do / (_ht * _di)) + (_do * Math.Log(_do / _di)) / (2 * _ktStainlessSteel) + 1 / _hs, -1);
                //Math.Pow((_do / (_ht * _di)) + (_do * Math.Log(_do / _di)) / (2 * _ktStainlessSteel) + 1 / _hs + (_do) / (_hfi * _di) + 1 / _hfo, -1);
                Console.WriteLine("_Uo = {0}", _Uo);
                Console.WriteLine("_Uoass = {0}", _Uoass);
                Console.WriteLine("_A = {0}", _A);
                double calQ = _Uo * _A  *_deltaTm;
                Console.WriteLine("_calQ = {0}", calQ);
                Console.WriteLine("_hi = {0}\n _ho {1}", _ht, _hs);
                double CurrentPercent = Math.Abs(_Uo - _Uoass);

                Console.WriteLine("Continue?");
                string astring = Console.ReadLine();
                Console.Write("_L in feet to start ({0}) ... ?",MetreToFeet( _LPathLength));
                _LPathLength = FeetToMetre(double.Parse(Console.ReadLine()));
                if (astring == "n" || astring == "N")
                { break; }
                else { _Uoass = _Uo; }
            }
            //use solver to get values for hi, ho which are get you the wanted U.
            /*    
            if (CurrentPercent <= LowestpercU)
                {
                    LowestpercU = CurrentPercent;
                    BestU = _Uoass;
                    BestCalU = _Uo;
                }
            */

                


            
            /*
            Console.WriteLine("BestUoass [{0}]", BestU);
            Console.WriteLine("LowestPer [{0}]", LowestpercU);
            Console.WriteLine("BestCalU [{0}]", BestCalU);
            
             * */
                Console.ReadLine();
            
        }

        static double deltaTm(double Thi, double Tho, double Tci, double Tco)
        {
            double ThoTci = Tho - Tci;
            double ThiTco = Thi - Tco;

            double answer = (ThoTci - ThiTco) / (Math.Log(ThoTci / ThiTco));
            
            return answer;
            

        }

        static double Q(double m, double c, double Ti, double To)
        { return Math.Abs(m * c * (Ti - To)); }

        static double R(double Thi, double Tho, double Tci, double Tco)
        {
            return (Thi - Tho) / (Tco - Tci);
        }


        static double MetreToFeet(double mt)
        {
            return mt * 3.280839895;
        }
        static double S(double Thi, double Tci, double Tco)
        {
            return (Tco - Tci) / (Thi - Tci);
        }

        static double FeetToMetre(double ft)
        { return ft * .3048; }

        static double Ft(double Thi, double Tho, double Tci, double Tco)
        {
            double Topline;
            double BottomLine;
            double _R = R(Thi, Tho, Tci, Tco);
            double _S = S(Thi, Tci, Tco);

            if (_R == 1)
            {
                Topline = Math.Sqrt(_R * _R + 1) * Math.Log((1 - _S) / (1 - _R * _S));
                BottomLine = (_R - 1) * Math.Log((2 - _S * (_R + 1 - Math.Sqrt(_R * _R + 1))) / (2 - _S * (_R + 1 + Math.Sqrt(_R * _R + 1))));

                return Topline / BottomLine;
            }
            else
            {
                Topline = Math.Sqrt(2 * _S) / (1 - _S);
                BottomLine = Math.Log((2 - _S * (2 - Math.Sqrt(2))) / (2 - _S * (2 + Math.Sqrt(2))));
                return Topline / BottomLine;
            }
        }

        static double Rconx(double x, double k, double A)
        {//conduction for given area
            return x / (k * A);
        }

        static double Re(double p, double v, double d, double mu)
        {
            return (p * v * d) / mu;
        }

        static double Re(double G, double d, double mu)
        {
            return (G * d) / mu;

        }

        static double Nut(double h, double d, double k)
        { return (h * d) / k; }

        static double Prt(double mu, double Cp, double k)
        {
            return (mu * Cp) / k;
        }
    

    }

    
}
