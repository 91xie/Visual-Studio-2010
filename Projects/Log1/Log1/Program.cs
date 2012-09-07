using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Log1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = ("C:/Users/Patrick Xie/Documents");
            Console.WriteLine(dir);
            List<string> aList = OpenFolder(dir);
            foreach (string i in aList)
                Console.WriteLine(i);
            Console.WriteLine("openfolder");
            string selector = Console.ReadLine();
            int present = 0;
            foreach (string anitem in aList)
            {
                string filename = anitem.Substring(8);
                Console.WriteLine(filename);
            }
            

            Console.ReadLine();

        }

        static List<string> OpenFolder(string path)
        {

            if (Directory.Exists(path) == true)
            {
                List<string> aList = new List<string>();
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);
                foreach (string x in files)
                { 
                    
                    aList.Add("<file  >" + x); 
                }
                foreach (string x in folders)
                { aList.Add("<folder>" + x); }
                aList.Sort();
                
                return aList;
            }
            else
            { List<string> aList = new List<string>(); return aList; }
        }

        static void Code1()
        {
            string InitialDir = "C:/Users/Patrick Xie/Documents";
            Console.WriteLine(InitialDir);
            if (Directory.Exists(InitialDir) == true)
            {
                Console.WriteLine("FolderExists");
                string[] thefiles = Directory.GetFiles(InitialDir);
                foreach (string x in thefiles)
                {
                    Console.WriteLine("<file  >" + x);
                }

                string[] thefolders = Directory.GetDirectories(InitialDir);
                foreach (string x in thefolders)
                { Console.WriteLine("<folder>" + x); }
            }
            else { Console.WriteLine("FolderDoesNotExist"); }
        }
        
        
    }

    class objfso
    {
        //contents of folder
        public static List<string> OpenFolder(string path)
        {

            if (Directory.Exists(path) == true)
            {
                List<string> aList = new List<string>();
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);
                foreach (string x in files)
                { aList.Add("<file  >" + x); }
                foreach (string x in folders)
                { aList.Add("<folder>" + x); }
                aList.Sort();

                return aList;
            }
            else
            { List<string> aList = new List<string>(); return aList; }
        }

        
        public static string TextFileReader(string filepath)
        {
            StreamReader Inputfile = new StreamReader(filepath);
            string s;
            s = "";
            while (!Inputfile.EndOfStream)
            { s = s + Inputfile.ReadLine(); }
            return s;
        }

        public static void TextFileWriter(string filepath, string text)
        {
            StreamWriter theFile = new StreamWriter(filepath);
            theFile.Write(text);
            theFile.Close();
        }
        

        public static string[] StrListtoArray(List<string> alist)
        {
            string[] anarray = new string[alist.Count];
            for (int i = 0; i < alist.Count; i++)
            { anarray[i] = alist[i]; }
            return anarray;
        }

        public static List<string> StrArraytoList(string[] anarray)
        {
            List<string> alist = new List<string>();
            foreach (string x in alist)
            { alist.Add(x); }
            return alist;
        }
        
    }

    class fso
    {
        public string CurrentPath;

        public fso(string apath)
        {
            if (Directory.Exists(apath))
            {CurrentPath = apath;}
            else if (Directory.Exists(apath))
            {CurrentPath = apath;}
            else
            { CurrentPath = "C:/";}
        }

        public fso()
        { CurrentPath = "C:/"; }

        public List<string> OpenFolder(string path)
        {

            if (Directory.Exists(path) == true)
            {
                List<string> aList = new List<string>();
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);
                foreach (string x in files)
                { aList.Add("<file  >" + x); }
                foreach (string x in folders)
                { aList.Add("<folder>" + x); }
                aList.Sort();
                this.CurrentPath = path;
                return aList;
            }
            else
            { List<string> aList = new List<string>(); return aList; }
        }

        public static string TextFileReader(string filepath)
        {
            StreamReader Inputfile = new StreamReader(filepath);
            string s;
            s = "";
            while (!Inputfile.EndOfStream)
            { s = s + Inputfile.ReadLine(); }
            return s;
        }

        public static void TextFileWriter(string filepath, string text)
        {
            StreamWriter theFile = new StreamWriter(filepath);
            theFile.Write(text);
            theFile.Close();
        }

        public string ReadFromFile(string filename)
        { string s = TextFileReader(this.CurrentPath); return s; }

        /*
         * open program which is browser.
         * 
         * select log
         * open the log and show log entries.
         * options... 1. create new log 2. open log
         * 
         */


    }
}
