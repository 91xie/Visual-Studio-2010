using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] frame = new string[25, 25];


            for (int i = 0; i <= frame.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= frame.GetUpperBound(1); j++)
                {
                    frame[i, j] = " ";
                }
            }

            for (int i = 0; i <= frame.GetUpperBound(0); i+=2 )
            {
                for (int j = 0; j <= frame.GetUpperBound(1); j++)
                {
                    frame[i, j] = "-";
                }
            }

            for (int i = 1; i <= frame.GetUpperBound(0); i += 2)
            {
                for (int j = 0; j <= frame.GetUpperBound(1); j += 2)
                {
                    frame[i, j] = "|";
                }
            }

            frameprint(frame);

            Console.ReadLine();

        }

        static void frameprint(string[,] a)
        {
            for (int i = 0; i <= a.GetUpperBound(0); i ++)
            {
                for (int j = 0; j <= a.GetUpperBound(0); j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }

        class Checkers
        {
            static string[,] frame { get { return frameset(); } }


            static string[,] frameset()
            {
                string[,] xframe = new string[25, 25];


                for (int i = 0; i <= xframe.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= xframe.GetUpperBound(1); j++)
                    {
                        xframe[i, j] = " ";
                    }
                }

                for (int i = 0; i <= xframe.GetUpperBound(0); i += 2)
                {
                    for (int j = 0; j <= xframe.GetUpperBound(1); j++)
                    {
                        xframe[i, j] = "-";
                    }
                }

                for (int i = 1; i <= xframe.GetUpperBound(0); i += 2)
                {
                    for (int j = 0; j <= xframe.GetUpperBound(1); j += 2)
                    {
                        xframe[i, j] = "|";
                    }
                }
                return xframe;
            }


        }

        class Piece
        {
            char Color; //black for 0, red for 1;
            double [] Position; //Position. [1,1] is top left hand corner.
            char type; // p awn k ing

            public Piece(char Color, double[] Position, char type)
            { this.Color = Color; this.Position = Position; this.type = type; }

            public void PiecePrint(Piece a)
            {
                if (a.Color == 'b')
                { Console.ForegroundColor = ConsoleColor.Green; }
                else
                { Console.ForegroundColor = ConsoleColor.Red; }

                Console.WriteLine(type);
                Console.ResetColor();
            }

        }
    }
}
