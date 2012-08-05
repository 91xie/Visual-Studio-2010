using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string astring = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
            string findthis = "abc";
            StringFinder2(findthis, astring);
            Console.ReadLine();
            
        }

        
        static List<int> StringFinderX(string find, string paragraph)
        {
            List<int> ListofOutputIndex = new List<int>();
            Console.WriteLine("paragraph  :{0}", paragraph);
            Console.WriteLine("find       :{0}", find);
            Console.WriteLine("find1stchar:{0}", find[0]);
            char achar = find[0];
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (achar == paragraph[i])
                { Console.WriteLine("{0} was found in {1} where i={2}", find[0], paragraph, i); ListofOutputIndex.Add(i); }
            }

            return ListofOutputIndex;
        }



        static int StringFinder (string find, string paragraph)
        {
            Console.WriteLine("paragraph  :{0}", paragraph);
            Console.WriteLine("find       :{0}", find);
            Console.WriteLine("find1stchar:{0}", find[0]);
            int indexinparagraph=0;
            char achar = find[0];
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (achar == paragraph[i])
                { Console.WriteLine("{0} was found in {1} where i={2}", find[0], paragraph, i); indexinparagraph = i; }
            }

            return indexinparagraph;
        }

        static void StringFinder2(string find, string paragraph)
        {
            int indexinparagraph = StringFinder(find, paragraph);
            int findindex = 0;
            string outputstring = "";
            while (findindex < find.Length && indexinparagraph < paragraph.Length  )
            {
                if(find[findindex] == paragraph[indexinparagraph])
                {outputstring += find[findindex]; findindex++; indexinparagraph++; }
                else {break;}
            }
            
            
            Console.WriteLine("outputstring {0} was found in {1}", outputstring, paragraph);

        }



        //now to find a lots of strings.
        
        //run first to check if it is actually there, pass a boolean back to see if it is true/right, if present continue with the 
    }
}
