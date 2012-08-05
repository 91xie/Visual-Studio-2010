using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadWriteTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadFromFileToString("text.txt"));
            Console.ReadLine();
        }



        static void CSVexample()
        {
                                                                                    //csv is for numbers that can be opened in excel
            System.IO.StreamWriter theFile = new System.IO.StreamWriter("Lotsofnumbers.csv");
            for (int i = 0; i <= 10; i++)
            {
                theFile.Write("{0},", i);
            }
            theFile.Close();
            //dont' forget to close
        }

        static void ReadFromFileToConsole(string aTextFile)
        {
            System.IO.StreamReader InputFile = new System.IO.StreamReader(aTextFile);
            string s;
            while (!InputFile.EndOfStream)
            {
                s = InputFile.ReadLine();
                Console.WriteLine(s);
            }


            
            //write different methods for returning strings.
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
    }
}
