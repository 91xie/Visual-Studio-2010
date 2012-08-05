using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _27_05_11_SearchEngine2
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Hello";
            string b = "Hello World";
            StringSearchEngine(a, b);
        }

        static void StringSearchEngine(string findthis, string paragraph)
        {
            //either that or you could output it into a list of items and then write another line of code to output the list.
            int i = 0, j = 0;
            string rollingstring = "";
            while (j < paragraph.Length-1)
            {
                if (i == findthis.Length - 1) { i = 0; }
                
                if  (findthis[i] == paragraph[j] )
                { rollingstring += paragraph[j]; i++; j++; }
                else
                { i = 0; j++; }

                

            }

            Console.WriteLine(rollingstring);
        }
    }
}
