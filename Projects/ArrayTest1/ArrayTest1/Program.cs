using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arrays Test 1");

            Console.WriteLine("From Page 32 of book");
            // http://www.youtube.com/watch?v=aU8QUJcyr7k
            //an array respresents a fi

            string[] letters = { "A", "B", "C", "D", "E" }; //[] means one dimesion
            //[,] multidimensional
            //one dimensional arrays
            //each position is [0,0] but since it is one dimensional, we don't need to state that
            int x = 0;
            foreach (string l in letters) //declared a string earlier
                //for each string element (which we call "l") in letters
                //we do everything below.
            {
                Console.WriteLine("Letters[(0)] = {1}", x, l);
                //prints out l for each element of letters.

                x++;
            }



            string[,] states = { { "CA", "California" }, { "A", "Arizona" }, { "TX", "Texas" } };
                
                foreach (string str in states) //for each string element "str" in array "states", write out each element
                {
                    Console.WriteLine(str);
                }

                Console.WriteLine(states[0, 0].ToString());
                Console.WriteLine(states[0, 2].ToString());    

            Console.ReadLine();
        }
    }
}
