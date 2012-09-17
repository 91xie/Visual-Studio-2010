using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "C:/Users/Patrick Xie/Documents/Visual Studio 2010/Projects/Maze1/aMaze1.txt";
            csvdraw aPage = new csvdraw(filepath, 30, 30);

            Console.WriteLine("abreak");

            aPage.DrawaRectangle(5, 5, 15, 15, 1, "o");

            aPage.drawpage(",");
            aPage.savepage(filepath);
            Console.ReadLine();
            //now i need to create functions to draw lines and shapes
            /*
             File opening, make sure that works correctly.
             * check each write method
             * call a method which checks if what you want to write is within bounds,
             
             
             */
        }

        static void MazeReader(string filepathofmaze)
        {
            System.IO.StreamReader myReader = new System.IO.StreamReader(filepathofmaze);
            List<string[]> aList = new List<string[]>();
            int maxwidth = 0;
            while (!myReader.EndOfStream)
            {
                string s = myReader.ReadLine();

                string[] aLine = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                aList.Add(aLine);
                if (aLine.Length > maxwidth) { maxwidth = aLine.Length; }
            }
            //now you have all the lines and all of the items.

            string[,] aMat = new string[aList.Count, maxwidth];

            for (int i = 0; i <= aMat.GetUpperBound(0); i++) //i is the line, j is the column
            {
                string[] aLine = aList[i];

                for (int j = 0; j < aLine.Length; j++)
                {
                    aMat[i, j] = aLine[j];
                }
            }

            //aMat is filled in a this point
            /*
            for (int i = 0; i <= aMat.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= aMat.GetUpperBound(1); j++)
                {
                    Console.Write(aMat[i, j] + ",");
                }
                Console.WriteLine();
            }
            */

        }

        static double fx1(double x)
        {
            double ans; ans = 0.2 * x * x + 1;
            return ans;
        }


    }

    class csvdraw
    {
        public string filepath; //this is the file where the drawing is going to be done.
        public string[,] thepaper; //this is the 2d array where the drawing is done.
        public delegate double fx1(double x);
        public delegate double fx2(double x, double y);
        //0 will be the point of reference
        //read the file, draw lines on that file, output file.

        public csvdraw(string filepath)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.IO.StreamReader myReader = new System.IO.StreamReader(filepath);
                List<string[]> aList = new List<string[]>();
                int maxwidth = 0;
                while (!myReader.EndOfStream)
                {
                    string s = myReader.ReadLine();
                    string[] aLine = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    aList.Add(aLine);
                    if (aLine.Length > maxwidth) { maxwidth = aLine.Length; }
                }

                string[,] aMat = new string[aList.Count, maxwidth];
                for (int i = 0; i <= aMat.GetUpperBound(0); i++)
                {
                    string[] aLine = aList[i];
                    for (int j = 0; j < aLine.Length; j++)
                    {
                        aMat[i, j] = aLine[j];
                    }
                }

                thepaper = aMat;
            }
            else
            { Console.WriteLine("File Path Does not Exist"); }
        }

        public void DrawaFunction(fx1 f, int x1, int x2, int penwidth, string symbol)
        {
            //need to do rounding so it becomes an integer.
            for (int x = x1; x <= x2; x++)
            {

                double fx = f(x);
                int y = (int)Math.Round(fx);
                int _x, _y;
                if (0 <= x & x < thepaper.GetUpperBound(0))
                { _x = x; }
                else if (x < 0)
                { _x = 0; }
                else { _x = thepaper.GetUpperBound(0); }

                if (0 <= y & y < thepaper.GetUpperBound(0))
                { _y = y; }
                else if (y < 0)
                { _y = 0; }
                else { _y = thepaper.GetUpperBound(0); }

                this.thepaper[_x, _y] = symbol;
            }
        }

        public void DrawaLine(int x1, int y1, int x2, int y2, int penwidth, string symbol)
        {
            double m = 1;
            if (x2 - x1 != 0)
            {
                { m = (y2 - y1) / (x2 - x1); }

                double c = (y1 - m * x1);

                List<double[]> points = new List<double[]>();
                int _x1 = x1, _x2 = x2;
                if (x1 > x2)
                { _x1 = x2; _x2 = x1; }
                for (int x = _x1; x <= _x2; x++)
                {
                    double fx = m * x + c;

                    int y = (int)Math.Round(fx);
                    int _x, _y;
                    if (0 <= x & x < thepaper.GetUpperBound(0))
                    { _x = x; }
                    else if (x < 0)
                    { _x = 0; }
                    else { _x = thepaper.GetUpperBound(0); }

                    if (0 <= y & y < thepaper.GetUpperBound(0))
                    { _y = y; }
                    else if (y < 0)
                    { _y = 0; }
                    else { _y = thepaper.GetUpperBound(0); }

                    this.thepaper[_x, _y] = symbol;
                }
            }
            else
            {
                //assuming you have a constant x as deltax is 0, you would only need to increment from y1 to y2
                int _y1, _y2;
                if (y2 > y1)
                { _y1 = y1; _y2 = y2; }
                else
                { _y1 = y2; _y2 = y1; }
                int _x = WithInBounds(x1, 0);

                for (int y = _y1; y <= _y2; y++)
                {
                    thepaper[_x, WithInBounds(y, 1)] = symbol;
                    if (y > thepaper.GetUpperBound(1))
                    { break; }
                }

            }

        }

        public void DrawaRectangle(int x1, int y1, int x2, int y2, int penwidth, string symbol)
        {
            bool testmode = true;
            DrawaLine(x1, y1, x1, y2, penwidth, symbol);
            if (testmode == true)
            { this.drawpage(""); }

            DrawaLine(x1, y1, x2, y1, penwidth, symbol);
            if (testmode == true)
            { this.drawpage(""); }
            DrawaLine(x2, y2, x1, y2, penwidth, symbol);
            if (testmode == true)
            { this.drawpage(""); }
            DrawaLine(x2, y2, x2, y1, penwidth, symbol);
            if (testmode == true)
            { this.drawpage(""); }

        }
        //circle could be of the same type again using 2 pairs of coordinates penwidth and symbol.

        public csvdraw(string filepath, int rows, int column)
        {
            thepaper = new string[rows, column];
            for (int i = 0; i <= thepaper.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= thepaper.GetUpperBound(1); j++)
                { thepaper[i, j] = " "; }
            }
        }

        public void drawpage(string sep)
        {
            string[,] apaper = this.thepaper;
            for (int i = 0; i <= apaper.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= apaper.GetUpperBound(1); j++)
                {
                    Console.Write(apaper[i, j] + sep);
                }
                Console.WriteLine();
            }
        }

        int WithInBounds(int anindex, int dim)
        {
            //if dim is = 0, then check rows, else if dim = 1, check columns.
            int _anindex = anindex;
            if (dim == 0 || dim == 1)
            {
                if (!(0 <= anindex && anindex <= this.thepaper.GetUpperBound(dim)))
                {
                    if (anindex < 0)
                    { _anindex = 0; }
                    else
                    { _anindex = this.thepaper.GetUpperBound(dim); }
                }
            }
            return _anindex;
        }



        public void savepage(string filepath)
        {
            if (!System.IO.File.Exists(filepath))
            { System.IO.File.CreateText(filepath); }
            System.IO.StreamWriter mywriter = new System.IO.StreamWriter(filepath);

            for (int i = 0; i <= this.thepaper.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= this.thepaper.GetUpperBound(1); j++)
                {
                    mywriter.Write(thepaper[i, j] + ",");
                }
                mywriter.WriteLine();
            }
            mywriter.Close();
        }
    }

    class Maze
    {
        public string[,] theMaze;//this is the maze which it is in.
        public int[] Location;//this is the reference
        public int[] start; //this is the start point
        public int[] end;// this is the end point.

        /*
         
         "x" will the be a wall.
         * 
         
         */
        public int dist; // this is the distance travelled
        public Maze(string filepathofmaze, int[] Location, int[] start, int[] end)
        {
            this.Location = Location; this.start = start; this.end = end;
            System.IO.StreamReader myReader = new System.IO.StreamReader(filepathofmaze);
            List<string[]> aList = new List<string[]>();
            int maxwidth = 0;
            while (!myReader.EndOfStream)
            {
                string s = myReader.ReadLine();

                string[] aLine = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                aList.Add(aLine);
                if (aLine.Length > maxwidth) { maxwidth = aLine.Length; }
            }
            //now you have all the lines and all of the items.

            string[,] aMat = new string[aList.Count, maxwidth];

            for (int i = 0; i <= aMat.GetUpperBound(0); i++) //i is the line, j is the column
            {
                string[] aLine = aList[i];

                for (int j = 0; j < aLine.Length; j++)
                {
                    aMat[i, j] = aLine[j];
                }
            }

            this.theMaze = aMat;
            // make a list of string [], process each line.
            //2D array



        }

        //need to read in the maze, maze will be stored as text file.

        public static string TextFileReader(string filepath)
        {
            System.IO.StreamReader InputFile = new System.IO.StreamReader(filepath);
            string s = "";
            while (!InputFile.EndOfStream)
            {
                s += InputFile.ReadLine();
            }
            return s;
        }



    }

}

