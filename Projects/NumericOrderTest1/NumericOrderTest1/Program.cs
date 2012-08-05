using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericOrderTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            //numerical order...
            /*
             * start with first no. starting index.
             * check if no is smaller than any other no. if smaller, assign to first position.
             * if it does find a smaller no, takes that as the smallest no so far and reassigns it.
             * goes through the list, if it does find a smaller no, reassigns.
             * 
             * continue until the end of the list and assign the smallest item in the first position.
             * 
             * increment starting index (starts from index 1 now) and repeat check.
             * 
             * repeat check until starting value = listofserial.count
             * 
             * 
             */
            Random MyRandomGen = new Random() ;

            List<string> ListofSerialNos = new List<string>();
            int i = 0;
            Console.WriteLine("RandomListofNos");
            while (i < 10)
            {
                ListofSerialNos.Add((MyRandomGen.NextDouble()*10).ToString());
                Console.WriteLine(ListofSerialNos[i]);
                i++;
            }
            //created random list.
            List<string> numericorderlist = new List<string>();
            int startingindex = 0;
            int incrementer = startingindex + 1; //doesn't check the actual one, checks the one after it.

            double anint = double.Parse(ListofSerialNos[0]);
            Console.WriteLine("an int {0}:", anint);


            int sampleselectorindex = 0;

            double sample = double.Parse(ListofSerialNos[startingindex]);

            while (startingindex <= ListofSerialNos.Count())
            {
                if (startingindex == ListofSerialNos.Count())
                { break; }

                
                while (incrementer  < ListofSerialNos.Count() )
                {
                    Console.WriteLine("index: {0} smallest value is: {1}", incrementer, sample);
                    //incrementer = 1;..
                    
                    double comparewith;
                    comparewith = double.Parse(ListofSerialNos[incrementer]);
                    if (sample > comparewith)
                    {
                        sampleselectorindex = incrementer;
                        sample = comparewith;
                    }

                    incrementer++;
                    
                }
            }


            //select that item... remove that item,
            //place in first/next available place. continue until end of loop.
            numericorderlist.Add(ListofSerialNos[sampleselectorindex]);


            Console.WriteLine();
            Console.WriteLine("smallest value is: {0}", sample);
            
            Console.ReadLine();

            
        }
    }
}
