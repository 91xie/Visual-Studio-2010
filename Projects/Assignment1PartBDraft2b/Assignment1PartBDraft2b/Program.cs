//12-02-2011
//12:25

//bisection b, increment h, fixed a

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1PartBDraft2
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1, h, a;
            //starting values
            h = 4 + 0.001;
            a = (Math.PI) / 2 + 0.0;

            double Qx1, Qx2, Qxm, Qxm_10, xm, FinalAreaCheck, MinArea;
            MinArea = 20;
            int i;
            i = 0;
            
            b1 = 4.5;
            double bx1, bx2;
            double m;
            bx1 = b1;
            bx2 = b1;
            qstruct minarea = new qstruct(b1, h, a);
            MinArea = minarea.qstruct_b1_h_a_area(); //dumby start variable
            double QArea = 8;
            //at the moment, MinArea is fixed. MinArea needs to vary and must differ from QArea
            //you get MinArea from new QArea...

            /*
             * Calculate starting value for Q.
             * 
             * Increment h, fix a, find suitable value for b
             * Find QArea(h, b1, a)
             * Check if QArea < MinArea
             * if QArea is < MinArea -> Reassigns QArea = MinArea
             * 
             * Main Loop checks if QArea < MinArea. Danger of continously
             * 
             * 
             * 
             * 
             */
            double InitialCheckAfterh;

            while (QArea <= MinArea)
            {


                do
                {

                    bx1 = b1;
                    bx2 = b1;
                    h -= 0.001;


                    do
                    {
                        Console.WriteLine("STAGE 1 -Root Selection");


                        bx1 = bx1 + 0.1;
                        bx2 = bx2 - 0.1;
                        i++;

                        qstruct qx1 = new qstruct(bx1, h, a);
                        Qx1 = qx1.qstruct_b1_h_a_minus10();
                        qstruct qx2 = new qstruct(bx2, h, a);
                        Qx2 = qx2.qstruct_b1_h_a_minus10();
                        /*
                        Console.WriteLine("------------------");
                        Console.WriteLine("------------------");
                        Console.WriteLine("------------------");

                        Console.WriteLine("i:=" + i);
                        Console.WriteLine("bx1:=" + bx1);
                        Console.WriteLine("bx2:=" + bx2);
                        Console.WriteLine("Qx1:=" + Qx1);
                        Console.WriteLine("Qx2:=" + Qx2);
                        Console.WriteLine("Qx1*Qx2:=" + Qx1 * Qx2);
                        */

                        m = Qx1 * Qx2;
                    } while (m > 0 && m != 0);

                    double xmi = (bx1 + bx2) / 2;



                    Console.WriteLine("-----------------");
                    Console.WriteLine("NOT Qx1 * Qx2 > 0 || Qx1 * Qx2 == 0");


                    int i_counter1 = 0;


                    Console.WriteLine("STAGE 2 - BISECTION METHOD");
                    //bisection loop
                    do
                    {
                        i_counter1++;
                        qstruct qx1 = new qstruct(bx1, h, a);
                        Qx1 = qx1.qstruct_b1_h_a_minus10();
                        qstruct qx2 = new qstruct(bx2, h, a);
                        Qx2 = qx2.qstruct_b1_h_a_minus10();
                        xm = (bx1 + bx2) / 2;
                        qstruct qxm = new qstruct(xm, h, a);
                        Qxm = qxm.qstruct_b1_h_a_minus10();
                        qstruct qxm_10 = new qstruct(xm, h, a);
                        Qxm_10 = qxm_10.qstruct_b1_h_a();
                        qstruct qArea = new qstruct(xm, h, a);
                        QArea = qArea.qstruct_b1_h_a_area();
                        if (Qxm * Qx1 < 0)
                        {
                            bx2 = xm;

                        }
                        else if (Qxm * Qx2 < 0)
                        {
                            bx1 = xm;
                        }

                        //Console.Write("RunNo.=" + i_counter1);
                        //Console.WriteLine("xm =" + xm);






                    } while (i_counter1 < 50);


                    Console.WriteLine("");
                    Console.WriteLine("xm = " + xm);
                    Console.WriteLine("QArea:= " + QArea);
                    Console.WriteLine("");
                    Console.WriteLine("STAGE 3");

                    Console.WriteLine("qxm_10:=" + Qxm_10);

                    Console.WriteLine("b1:= " + xm);
                    Console.WriteLine("h:= " + h);
                    Console.WriteLine("a:= " + a);

                    /*
                    Console.WriteLine("");
                    b1 = xmi;
                    qstruct initialarea = new qstruct(xm, h, a);
                    InitialCheckAfterh = initialarea.qstruct_b1_h_a_area();
                    Console.WriteLine("xmi=" + xmi);
                    Console.WriteLine("Final Value of h:=" + h);
                    Console.WriteLine("Final Value of a:=" + a);
                    Console.WriteLine("AreaCheck after h increment:= " + InitialCheckAfterh);
                    Console.WriteLine("QArea:= " + QArea);
                    */

                    //continue if AreaCheck < QArea



                    b1 = xm;

                    if (QArea < MinArea)
                    { MinArea = QArea; }
                    else { }



                } while (QArea <= MinArea); //this is always going to be the case given tan90
                Console.WriteLine("MinArea Loop0 for b1 {0:F5} h {1:F5} a {2:F5} is {3:F5} m2", b1, h, a, MinArea);
                
                
                //=============================== second loop
                //bisection b, fix h, increment a

                bx1 = b1;
                bx2 = b1;

                qstruct minarea2 = new qstruct(b1, h, a);
                double MinArea2 = minarea2.qstruct_b1_h_a_area();


                do
                {
                    bx1 = b1;
                    bx2 = b1;
                    a -= 0.001;

                    do
                    {
                        Console.WriteLine("STAGE 1 A Root Selection");

                        bx1 = bx1 + 0.1;
                        bx2 = bx2 - 0.1;
                        qstruct qx1 = new qstruct(bx1, h, a);
                        Qx1 = qx1.qstruct_b1_h_a_minus10();
                        qstruct qx2 = new qstruct(bx2, h, a);
                        Qx2 = qx2.qstruct_b1_h_a_minus10();

                        m = Qx1 * Qx2;

                    } while (m > 0 && m != 0);

                    int i_counter1 = 0;

                    Console.WriteLine("Stage 2 A Bisection Method");
                    do
                    {
                        i_counter1++;
                        qstruct qx1 = new qstruct(bx1, h, a);
                        Qx1 = qx1.qstruct_b1_h_a_minus10();
                        qstruct qx2 = new qstruct(bx2, h, a);
                        Qx2 = qx2.qstruct_b1_h_a_minus10();
                        xm = (bx1 + bx2) / 2;
                        qstruct qxm = new qstruct(xm, h, a);
                        Qxm = qxm.qstruct_b1_h_a_minus10();
                        qstruct qxm_10 = new qstruct(xm, h, a);
                        Qxm_10 = qxm_10.qstruct_b1_h_a();
                        qstruct qArea = new qstruct(xm, h, a);
                        QArea = qArea.qstruct_b1_h_a_area();
                        if (Qxm * Qx1 < 0)
                        {
                            bx2 = xm;

                        }
                        else if (Qxm * Qx2 < 0)
                        {
                            bx1 = xm;
                        }

                        //Console.Write("RunNo.=" + i_counter1);
                        //Console.WriteLine("xm =" + xm);






                    } while (i_counter1 < 50);

                    Console.WriteLine("");
                    Console.WriteLine("xm = " + xm);
                    Console.WriteLine("QArea:= " + QArea);
                    Console.WriteLine("");
                    Console.WriteLine("STAGE 3 A");

                    Console.WriteLine("qxm_10:=" + Qxm_10);

                    Console.WriteLine("b1:= " + xm);
                    Console.WriteLine("h:= " + h);
                    Console.WriteLine("a:= " + a);

                    /*
                    Console.WriteLine("");
                    b1 = xmi;
                    qstruct initialarea = new qstruct(xm, h, a);
                    InitialCheckAfterh = initialarea.qstruct_b1_h_a_area();
                    Console.WriteLine("xmi=" + xmi);
                    Console.WriteLine("Final Value of h:=" + h);
                    Console.WriteLine("Final Value of a:=" + a);
                    Console.WriteLine("AreaCheck after h increment:= " + InitialCheckAfterh);
                    Console.WriteLine("QArea:= " + QArea);
                    */

                    //continue if AreaCheck < QArea



                    b1 = xm;

                    if (QArea < MinArea)
                    { MinArea = QArea; }
                    else { }



                } while (QArea <= MinArea); //this is always going to be the case given tan90
                Console.WriteLine("MinAreaA for b1 {0:F5} h {1:F5} a {2:F5} is {3:F5} m2", b1, h, a*(180/Math.PI), MinArea);
                Console.WriteLine("Q discharge := {0:F5}", Qxm+10);
            }

//=================
            //============================


            /*
                        FinalAreaCheck = QArea;
                        if (FinalAreaCheck < MinArea)
                        { MinArea = FinalAreaCheck; }
                        else
                        {}
                        */

            //}while(FinalAreaCheck < MinArea);
            //bisection loop</>

            //<loop>
            //increment h fix a;
            //bisection method again, compute according b.
            //compute area
            //if area is reducing, continue
            //else if area is increasing stop.
            //</loop>
            //fix 


            //do that loop for given fixed value of a,
            //increment a then start over again.
            //check and store max value.
            // if (Area < MinArea)
            // {MinArea = Area)
            // else
            //{Area=Area}










            Console.WriteLine("Press Enter to Quit. . .");
            Console.ReadLine();
        }



        //struct
        struct qstruct
        {
            public double b1, h, a;

            public qstruct(double b1, double h, double a)
            {
                this.b1 = b1;
                this.h = h;
                this.a = a;

            }

            public qstruct(qstruct x)
            {
                b1 = x.b1;
                h = x.h;
                a = x.a;

            }

            public double qstruct_b1_h_a()
            {

                double Q, A, R, P, s, k, g;
                double b2;

                g = 9.81;
                s = 0.00125;
                k = 0.015;

                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                return Q = -1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R));




            }

            public double qstruct_b1_h_a_minus10()
            {

                double Q, A, R, P, s, k, g;
                double b2;

                g = 9.81;
                s = 0.00125;
                k = 0.015;

                b2 = b1 - ((2 * h) / Math.Tan(a));
                A = 0.5 * (b1 + b2) * h;
                P = b2 + 2 * (h / Math.Sin(a));
                R = A / P;
                return Q = (-1 * A * Math.Sqrt(32 * R * s * g) * Math.Log10(k / (14.8 * R))) - 10;




            }


            public double qstruct_b1_h_a_area()
            {
                double b2, A;


                b2 = b1 - ((2 * h) / Math.Tan(a));
                return A = 0.5 * (b1 + b2) * h;


            }




        }

    }
}
