using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random AnotherRand = new Random();
            
            
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            
            int lines = 10000;
            int width = Console.LargestWindowWidth-1;
            string[] theMatrix = new string[width];
            double[] colorcodes = new double[width];
            


            double whitedisp = 50;
            //set up intial random no.s
            //sets intial random colors per letter.

            Random MyRand = new Random();


            for (int i = 0; i < theMatrix.Length; i++) //inital values.
            { theMatrix[i] = MyRand.Next(10).ToString(); }

            for (int i = 0; i < width; i++)//sets initial colors.
            {
                double colorno = MyRand.Next(4);
                if (colorno == 3)
                {
                    double anotherwhite = MyRand.Next(100);
                    if (anotherwhite < whitedisp)
                    {
                        colorno = MyRand.Next(3);
                    }
                }
                color(colorno);
                colorcodes[i] = colorno;
                Console.Write(theMatrix[i]);
            }


            for (int j = 0; j < lines; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    
                    double currentcolorcode = colorcodes[i];
                    double randomselector = MyRand.Next(100);

                    if (currentcolorcode == 3)
                    {
                        double colorno = MyRand.Next(3);
                        color(colorno);
                        colorcodes[i] = colorno;
                    }
                    else
                    {
                        if (randomselector > 90)
                        {
                            double colorno = MyRand.Next(4);
                            if (colorno == 3)
                            {
                                double anotherwhite = MyRand.Next(100);
                                if (anotherwhite < whitedisp)
                                {
                                    colorno = MyRand.Next(3);
                                }
                            }
                            color(colorno);
                            colorcodes[i] = colorno;


                        }
                        else
                        {
                            color(colorcodes[i]);
                        }
                    }



                    Console.Write(MyRand.Next(10));
                }
                Console.WriteLine();
            }


             

            


            Console.ReadLine();
            //have one row of string console writeline each row. after every loop you have to change the loop...
            


        }

        static char GetLetter()
        {
            Random _random = new Random();
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = _random.Next(26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }

        static void color(double colorno)
        {
            if (colorno == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (colorno == 1) Console.ForegroundColor = ConsoleColor.Green;
            else if (colorno == 2) Console.ForegroundColor = ConsoleColor.Black;
            else if (colorno == 3) Console.ForegroundColor = ConsoleColor.White;
            
        }
    }
}
