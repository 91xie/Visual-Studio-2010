using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static string TextFileReader(string filepath)
        {
            System.IO.StreamReader Inputfile = new System.IO.StreamReader(filepath)
            string s;
            s = "";
            while (!Inputfile.EndOfStream)
            {s = s + Inputfile.ReadLine();}
            return s;
        }

        static void TextFileWriter(string filepath, string text)
        {
            System.IO.StreamWriter theFile = new System.IO.StreamWriter(filepath)
            theFile.Write(text);
            theFile.Close();
        }
        
    }


}
