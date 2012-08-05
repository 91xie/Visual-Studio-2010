using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaussianElimination_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Tests.AppMain();
            
            
            Console.ReadLine();


        }

        


        class Tests
        {
            public static void AppMain()
            {
                string options = "1. Gaussian  2. Jacobi   3. Inverse... ";
                Console.WriteLine("\tLinear Systems Solver");
                string selector = "";

                Console.WriteLine("-Type 'quit' to quit");
                Console.WriteLine("-Enter information as follows\n\nInput A:");

                Console.Write(" 1 2 3              <<Press Enter to go onto a new line\n 2 6 10 \n 3 14 28\ndone");
                Console.WriteLine("                <<Type 'done' at the end to finish declaring a matrix\n");

                Console.WriteLine("Input B:");
                Console.WriteLine("1\n0\n-8\ndone\n");
                Console.WriteLine("Select Method");
                Console.Write(options);

                selector = Console.ReadLine();
                while (selector != "quit")
                {
                    if (selector == "1")
                    { Tests.Gauss_consoleinterface(); }
                    else if (selector == "2")
                    { Tests.Jacobi_consoleinterface(); }
                    else if (selector == "3")
                    { Tests.Inverse_consoleinterface(); }

                    Console.WriteLine("Select Method");
                    Console.Write(options);

                    selector = Console.ReadLine();

                }
                Console.WriteLine("Bye bye!");
            }

            public static void InverseTest1()
            {
                double[,] A = new double[,] { { 1, 2, 3 }, { 2, 13, 10 }, { 3, 14, 28 } };
                Matrix.matrix2DPrint(A);
                Matrix.matrix2DPrint(Matrix.Diagonal(A));
                Matrix.matrix2DPrint(Matrix.Inverse(Matrix.Diagonal(A)));
                Matrix.matrix2DPrint(Matrix.MulMat(Matrix.Diagonal(A), Matrix.Inverse(Matrix.Diagonal(A))));

                
            }


            public static void GaussTest1()
            {



                
                double[,] A = new double[,] { { 1, 2, 3 }, { 2, 6, 10 }, { 3, 14, 28 } };
                double[,] B = new double[,] { { 1 }, { 0 }, { -8 } };
                /*
                double[,] A = new double[,] { { 2, -1, 0 }, { -1, 2, -1 }, { 0, -1, 2 } };
                double[,] B = new double[,] { { 1 }, { 6 }, { -3 } };
*/
                Console.WriteLine("A:");
                Matrix.matrix2DPrint(A);
                Console.WriteLine("B:");
                Matrix.matrix2DPrint(B);

                Console.WriteLine("augAB:");
                double[,] augAB = Matrix.Aug_AB(A, B);
                Matrix.matrix2DPrint(augAB);
                double[,] ans = Matrix.Gauss_BackSub_Sol(A, B);
                Console.WriteLine("x:");
                Matrix.matrix2DPrint(ans);


            }

            public static void JacobiTest1()
            {
                double[,] A = new double[,] { { 2, -1, 0 }, { -1, 2, -1 }, { 0, -1, 2 } };
                double[,] B = new double[,] { { 1 }, { 6 }, { -3 } };

                Console.WriteLine("A:");
                Matrix.matrix2DPrint(A);
                Console.WriteLine("B:");
                Matrix.matrix2DPrint(B);
                Console.WriteLine("augAB:");
                double[,] augAB = Matrix.Aug_AB(A, B);

                double [,] ans = Matrix.Jacobi(A, B,0.00001);
                Console.WriteLine("x:");
                Matrix.matrix2DPrint(ans);
            }



            public static void Inverse_consoleinterface()
            {
                Console.WriteLine("Inverse Method ... ");
                string select = "";

                List<double[]> Listof1DA = new List<double[]>();

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") break;
                    if (select == "quit") return;
                    Listof1DA.Add(Matrix.StringToMatrix(select));

                }
                double[,] A1 = Matrix.List1DArrayto2DArray(Listof1DA);
                if (A1.GetUpperBound(0) != A1.GetUpperBound(1))
                {
                    Console.WriteLine("A1 is not a square matrix"); return;
                }
                select = "";

                Console.WriteLine("A:");
                Matrix.matrix2DPrint(A1);

                double[,] ainverse = Matrix.Inverse(A1);
                Matrix.matrix2DPrint(ainverse);

                Console.Write("Press Enter to continue ... "); Console.ReadLine();
            }

            public static void Gauss_consoleinterface()
            {
                System.IO.StreamWriter theFile = new System.IO.StreamWriter("Output.txt");
                Console.WriteLine("Gauss Method ... ");
                string select = "";
                
                    List<double[]> Listof1DA = new List<double[]>();
                    List<double[]> Listof1DB = new List<double[]>();
                    Console.WriteLine("Ax=B");
                    Console.WriteLine("Input A:");

                    for (; ; )
                    {
                        select = Console.ReadLine();
                        if (select == "done") break;
                        if (select == "quit") { theFile.Close(); return; }
                        Listof1DA.Add(Matrix.StringToMatrix(select));

                    }
                    double[,] A1 = Matrix.List1DArrayto2DArray(Listof1DA);
                    if (A1.GetUpperBound(0) != A1.GetUpperBound(1))
                    {
                        Console.WriteLine("A1 is not a square matrix"); return;
                    }    

                    select = "";
                    Console.WriteLine("Input: B");

                    for (; ; )
                    {
                        select = Console.ReadLine();
                        if (select == "done") { break; }
                        if (select == "quit") return;
                        Listof1DB.Add(Matrix.StringToMatrix(select));
                    }

                    
                    double[,] B1 = Matrix.List1DArrayto2DArray(Listof1DB);

                    if (B1.GetUpperBound(0) != A1.GetUpperBound(0))
                    { Console.WriteLine("A and B dimensions don't match"); }

                    Console.WriteLine("A:"); theFile.WriteLine("A:");
                    Matrix.matrix2DPrint(A1); theFile.WriteLine(Matrix.matrixToString(A1));
                    Console.WriteLine("B:"); theFile.WriteLine("B:");
                    Matrix.matrix2DPrint(B1); theFile.WriteLine(Matrix.matrixToString(B1));

                    Console.WriteLine("augAB:"); 
                    double[,] augAB = Matrix.Aug_AB(A1, B1);
                    Matrix.matrix2DPrint(augAB);
                    double[,] ans = Matrix.Gauss_BackSub_Sol(A1, B1);
                    Console.WriteLine("x:"); theFile.WriteLine("x:");
                    Matrix.matrix2DPrint(ans); theFile.WriteLine(Matrix.matrixToString(ans));

                    Console.WriteLine();
                    Console.WriteLine("Continue...");

                    select = Console.ReadLine();
                    theFile.Close();
                    

            }

            public static void Jacobi_consoleinterface()
            {
                Console.WriteLine("Jacobi Method ... ");
                string select = "";
                
                    List<double[]> Listof1DA = new List<double[]>();
                    List<double[]> Listof1DB = new List<double[]>();
                    Console.WriteLine("Ax=B");
                    Console.WriteLine("Input A:");

                    for (; ; )
                    {
                        select = Console.ReadLine();
                        if (select == "done") break; if (select == "quit") return;
                        Listof1DA.Add(Matrix.StringToMatrix(select));

                    }

                    double[,] A1 = Matrix.List1DArrayto2DArray(Listof1DA);

                    if (Matrix.StrictlyDiagonalDom(A1) == false)
                    { Console.WriteLine("Matrix is not strictly diagonal dominant");  return; }

                    select = "";
                    Console.WriteLine("Input: B");

                    for (; ; )
                    {
                        select = Console.ReadLine();
                        if (select == "done") { break; } if (select == "quit") return;
                        Listof1DB.Add(Matrix.StringToMatrix(select));
                    }

                    Console.WriteLine("Input: Tol");
                    double tol = double.Parse(Console.ReadLine());
                    
                    double[,] B1 = Matrix.List1DArrayto2DArray(Listof1DB);

                    Console.WriteLine("A:");
                    Matrix.matrix2DPrint(A1);
                    Console.WriteLine("B:");
                    Matrix.matrix2DPrint(B1);

                    Console.WriteLine("augAB:");
                    double[,] augAB = Matrix.Aug_AB(A1, B1);
                    Matrix.matrix2DPrint(augAB);


                    double[,] ans = Matrix.Jacobi(A1,B1,tol);
                    Console.WriteLine("x:");
                    Matrix.matrix2DPrint(ans);

                    Console.WriteLine();
                    Console.WriteLine("Continue ...");

                    select = Console.ReadLine();
                    

                
            }

            public static void Auto_Gauss_Jacobi()
            {
                double tol = 0.00001;
                Console.WriteLine("Auto ... \nSelects Fasts Method to Solve with a tol of {0} ",tol);
                string select = "";

                List<double[]> Listof1DA = new List<double[]>();
                List<double[]> Listof1DB = new List<double[]>();
                Console.WriteLine("Ax=B");
                Console.WriteLine("Input A:");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") break; if (select == "quit") return;
                    Listof1DA.Add(Matrix.StringToMatrix(select));

                }

                double[,] A1 = Matrix.List1DArrayto2DArray(Listof1DA);

                if (Matrix.StrictlyDiagonalDom(A1) == false)
                { Console.WriteLine("Matrix is not strictly diagonal dominant"); return; }

                select = "";
                Console.WriteLine("Input: B");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") { break; } if (select == "quit") return;
                    Listof1DB.Add(Matrix.StringToMatrix(select));
                }

                double[,] B1 = Matrix.List1DArrayto2DArray(Listof1DB);

                Console.WriteLine("A:");
                Matrix.matrix2DPrint(A1);
                Console.WriteLine("B:");
                Matrix.matrix2DPrint(B1);
                Console.WriteLine("augAB:");
                Matrix.matrix2DPrint(Matrix.Aug_AB(A1,B1));
                
                Console.WriteLine("x:");

                if (Matrix.StrictlyDiagonalDom(A1) == true)
                {
                    
                    Matrix.matrix2DPrint(Matrix.Jacobi(A1, B1, tol));
                }
                else
                {
                    Matrix.matrix2DPrint(Matrix.Gauss_BackSub_Sol(A1,B1));
                }

                



            }

            public static List<double [,]>  consoleMatrixAB()
            {
                Console.WriteLine("Gauss Method ... ");
                string select = "";

                List<double[]> Listof1DA = new List<double[]>();
                List<double[]> Listof1DB = new List<double[]>();
                Console.WriteLine("Ax=B");
                Console.WriteLine("Input A:");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") break;
                    if (select == "quit") return null;
                    Listof1DA.Add(Matrix.StringToMatrix(select));

                }
                double[,] A1 = Matrix.List1DArrayto2DArray(Listof1DA);
                if (A1.GetUpperBound(0) != A1.GetUpperBound(1))
                {
                    Console.WriteLine("A1 is not a square matrix"); return null;
                }

                select = "";
                Console.WriteLine("Input: B");

                for (; ; )
                {
                    select = Console.ReadLine();
                    if (select == "done") { break; }
                    if (select == "quit") return null;
                    Listof1DB.Add(Matrix.StringToMatrix(select));
                }


                double[,] B1 = Matrix.List1DArrayto2DArray(Listof1DB);

                if (B1.GetUpperBound(0) != A1.GetUpperBound(0))
                { Console.WriteLine("A and B dimensions don't match"); }

                Console.WriteLine("A:");
                Matrix.matrix2DPrint(A1);
                Console.WriteLine("B:");
                Matrix.matrix2DPrint(B1);

                List<double[,]> ListofAB = new List<double[,]>();
                ListofAB.Add(A1);
                ListofAB.Add(B1);
                return ListofAB;

            }

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
                double [,] xold = xnew;
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
                double [,] xx = new double [i, j];
                for (int r = 0; r < i; r++)
                {
                    for (int c = 0 ; c< j; c++)
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
                        else { diag = Math.Abs( A[i,j]); }
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
                        else { diag =Math.Abs( A[i, j]); }
                    }

                    if (diag <= sum) { return false; }
                    sum = 0;

                }

                return true;

            }

            public static double[,] Diagonal(double[,] A)
            {
                int rowsinA = A.GetUpperBound(0), columnsinA = A.GetUpperBound(1);
                double [,] aDiagonal = new double [rowsinA+1 , columnsinA +1];
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
                
                double [,] InvA =  (Copy(augAB,   0  ,augAB.GetUpperBound(0),  augAB.GetUpperBound(1)- augAB.GetUpperBound(0)   , augAB.GetUpperBound(1)));


                return InvA;

            }

            public static double[,] Copy(double[,] A, int i1, int i2, int j1, int j2)
            {
                int rowsinPaste = i2 - i1 + 1, columnsinPaste = j2 - j1 + 1;
                double[,] Paste = new double[rowsinPaste,  columnsinPaste];
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
                    matrix2DPrint(A1);
                    Console.WriteLine("B:");
                    matrix2DPrint(B1);

                    Console.WriteLine("augAB:");
                    double[,] augAB = Aug_AB(A1, B1);
                    matrix2DPrint(augAB);
                    double[,] ans = Gauss_BackSub_Sol(A1, B1);
                    Console.WriteLine("x:");
                    matrix2DPrint(ans);

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
            //rowscale double [,] A, int i, double scale

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
                    { if (augAB[i, p] != 0) { RowScale(augAB, i, 1 / (augAB[i, p]));  } }


                    for (int i = p + 1; i <= augAB.GetUpperBound(0); i++)
                    { if (augAB[i, p] != 0) { RowSub(augAB, p, i, i);  } }

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

                    for (int pp2 = pp-1; pp2 >= 0; pp2--)
                    {
                        double scaler = augAB[pp2 , pp];

                        if (scaler == 0) { continue; }
                        RowScale(augAB, pp, scaler);

                        RowSub(augAB, pp2 , pp, pp2 );

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




            public static void matrix1DPrint(double[] a)
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
                double[] row1 = new double[columnsofA+1];
                double[] row2 = new double[columnsofA+1];
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
                double[] row1 = new double[columnsofA+1];
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
                        
                            for ( j = 0; j <= A.GetUpperBound(1); j++)
                            augM[i, j] = A[i, j];
                        
                            for (j = 0; j <= B.GetUpperBound(1); j++)
                            augM[i, j+A.GetUpperBound(1)+1] = B[i, j];
                        
                    
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

            public static void matrix2DPrint(double[,] a)
            {
                //System.IO.StringWriter s = new System.IO.StringWriter();

                int rowincrementer = 0, columnincrementer = 0;
                while (rowincrementer <= a.GetUpperBound(0))
                {
                    while (columnincrementer <= a.GetUpperBound(1))
                    {
                        Console.Write("{0,10:G5}", a[rowincrementer, columnincrementer]);
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
                if ((rowsofA != rowsofB )|| (columnsofA != columnsofB))
                { return null; }

                double[,] AddAB = new double[rowsofA+1, columnsofA+1];

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
        }
    }
}
