using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20_05_11_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";
            string b = "";

            string findthis = "Hello";

            string inparagraph = "Hello World";

            StringSearchEngine(findthis, inparagraph);
            //increment through each character until you find one that matches the first character of the checker.
            //get new starting location.
            //check next if it matches the next character. add the equivalent characters to a new output string.
            //continue until character does not match.
            //increment again through each character until you find one that matches the first character of the checker.


        }

        static void StringSearchEngine(string findthis, string inthisparagraph)
        {
            string rollingstring = "";
            char findthischar, inthisparagraphchar;
            int i=0, j=0;
            findthischar = findthis[i];
            inthisparagraphchar = inthisparagraph[0];

            //loop until you get to the very bottom...
            while (j < inthisparagraph.Length)//j references position in paragraph
            {
                for (j++; inthisparagraph[j] == findthis[i]; )
                {
                    //when you find one that matches.
                    rollingstring += inthisparagraph[j];//add the character to the list.
                    //increment i and j and check if they are equal.
                    j++; i++;
                    if (j < inthisparagraph.Length-1) break;

                }

                i = 0;
                Console.WriteLine("Results: {0}", rollingstring);
                rollingstring = "";
            }
        }
    }
}
