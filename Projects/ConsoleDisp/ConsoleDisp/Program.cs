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
            Console.WindowHeight = 50;

            //you need to create the array
            //create the starting point
            //increment across the screen for each "x"
            //find the corresponding point on the graph to put the y.

            string [,] anarray = new string[30, 70];

            for (int i = 0; i <= anarray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= anarray.GetUpperBound(1); j++)
                {
                    anarray[i, j] = ".";
                }
            }

            //set 0,0 coordinate
            int x0 = 0, y0 = anarray.GetUpperBound(0)/2;
            double f = 1.0/15.0;

            for (int j = 0; j < 1000; j++)
            {

                string[,] anarray2 =  anarray;
                for (int i = 0; i <= anarray2.GetUpperBound(1); i++)
                {
                    int y = y0 + (int)Math.Round(10 * Math.Sin(2 * Math.PI * f * i*j));
                    /*if (Math.Abs(y) >= Math.Abs(anarray2.GetUpperBound(0) / 2))
                    {
                        y = (int)Math.Round(Math.Sign(y) * anarray2.GetUpperBound(0) * 0.5);
                    }
                    */

                    anarray2[y, i] = "x";

                }
                Console.Clear();
                ConsoleDraw.print(anarray2);
                for (int i = 0; i <= anarray.GetUpperBound(0); i++)
                {
                    for (int w = 0; w <= anarray.GetUpperBound(1); w++)
                    {
                        anarray[i, w] = ".";
                    }
                }

                
            }
            Console.ReadLine();
        }

        static void PlotSinWave(double f, double Amplitude)
        {
            
            string[,] page = new string[30, 30];

            int mid = page.GetUpperBound(0) / 2;

            

            for (int x = 0; x < page.GetUpperBound(1); x++)
            {
                double _x = x;
                double y = Math.Round(3.3);
                
            }

        }


        public class ConsoleDraw
        {
            public static void print(string[,] input)
            {
                for (int i = 0; i <= input.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= input.GetUpperBound(1); j++)
                    {
                        Console.Write(input[i, j]);
                    }
                    Console.WriteLine();
                }

            }

            public static void print(bool[,] input, char achar)
            {
                for (int i = 0; i <= input.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= input.GetUpperBound(1); j++)
                    {
                        if (input[i, j] == true)
                        { Console.Write(achar); }
                        else { Console.Write(' '); }
                    }
                    Console.WriteLine();
                }
            }

            public static string[,] RandomArray(int row, int col)
            {
                string [,] x = new string [row,col];

                string letters = "1234567890-=qwertyuiop[]asdfghjkl;'#zxcvbnm,.!£$$%^&*()_+QWERTYUIOP{}ASDFGHJKL:@~ZXCVBNM<>?|";

                Random myrand = new Random();

                

                for (int i = 0; i<row ; i++)
                {
                    for (int j = 0; j<col; j++)
                    {
                        x[i,j] = (letters[myrand.Next(letters.Length - 1)]).ToString();
                    }
                }

                return x;

            }



        }

    }


}
