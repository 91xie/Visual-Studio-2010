using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TablePivoter
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputString1 = ReadFromFileToString("TablePivoterInput.csv");
            Console.WriteLine("InputString");
            Console.WriteLine(InputString1);
            

            
            
            string [] eachRow1 = InputString1.Split( new char [] {'\r'});
            
            string eachRow1a = "";
            eachRow1a = string.Concat(eachRow1);
            eachRow1 = eachRow1a.Split(new char[] { '\n' });

            Console.WriteLine("InputTable");
            foreach (string x in eachRow1)
            { Console.WriteLine(x); }

            string[][] eachSplitRow2 = new string[eachRow1.Count()][];

            int widthtable1 = 0;
            for (int i = 0; i < eachSplitRow2.Count(); i++)
            {
                string[] SplitRow3 = eachRow1[i].Split(new char[] { ',' });
                

                if (widthtable1 < SplitRow3.Count())
                { widthtable1 = SplitRow3.Count(); }

                eachSplitRow2[i] = SplitRow3;
            }

            
            int heighttable1 = eachSplitRow2.Count()-1;
            Console.WriteLine("rows {0} columns{1}", heighttable1, widthtable1);

            string[,] outtable = new string[widthtable1, heighttable1];

            for (int i = 0; i <= outtable.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= outtable.GetUpperBound(1); j++)
                {
                    outtable[i, j] = eachSplitRow2[j][i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("OutputTable");
            TableStringConsole(outtable);

            string outputcsv = TabletoString(outtable);
            CSVexample("TablePivoterOutput.csv", outputcsv);
            

            Console.ReadLine();


        }

        
        static void TableStringConsole(string[,] x)
        {
            
            for (int i = 0; i <= x.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= x.GetUpperBound(1); j++)
                {
                    Console.Write("{0},", x[i, j]);
                }
                Console.WriteLine();
            }
        }

        static string TabletoString(string[,] x)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            for (int i = 0; i <= x.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= x.GetUpperBound(1); j++)
                {
                    s.Write("{0},", x[i, j]);
                }
                s.WriteLine();
            }
            return s.ToString();
        }
        static string ReadFromFileToString(string aTextFile)
        {
            System.IO.StreamReader InputFile = new System.IO.StreamReader(aTextFile);
            System.IO.StringWriter s = new System.IO.StringWriter();
            while (!InputFile.EndOfStream)
            {
                s.WriteLine(InputFile.ReadLine());
            }
            return s.ToString();
        }

        static void CSVexample(string SaveFileName, string Text)
        {
            //csv is for numbers that can be opened in excel
            System.IO.StreamWriter theFile = new System.IO.StreamWriter(SaveFileName);
            theFile.Write(Text);
            theFile.Close();
            //dont' forget to close
        }
    }
}
