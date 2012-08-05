using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA1
{
    class Program
    {
        static void Main(string[] args)
        {
            DNA a = DNA.RandomDNA(9);
            Console.WriteLine(a);
            List<DNA> TripsOfA = a.Triplets();
            foreach (DNA x in TripsOfA)
            { Console.WriteLine(x); }

            string astring = "abc";
            string bstring = "abc";
            Console.WriteLine(astring.CompareTo(bstring));

            Console.ReadLine();
        }
    }

    class DNA
    {
        public string strand;

        public DNA(string strand)
        {this.strand = strand;}

        public DNA Compliment()
        {
            string inputstring = this.strand;
            string outputstring = "";
            foreach (char x in inputstring)
            {
                outputstring += CompPair(x);
                
            }
            return new DNA (outputstring);
        }

        public List<DNA> DNAFindStartStop(DNA a)
        {
            string[] Start = new string [] {"AUG"};
            string[] Stop = new string[]{"UAA", "UAG", "UGA"};
            string astring = a.strand;
            for (int i = 0; i < astring.Length-2; i++)
            {
                string comp = Cut(astring, i, i + 2);
                int startofone = 0; int endofone = 1;
                if (Start[0].CompareTo(comp) == 0)
                {
                    //store i as the start reference.
                    startofone = i;

                    for (int j = 0; j < astring.Length - 2; j++)
                    {
                        string comp2 = Cut(astring,j,j+2);
                        foreach (string stops in Stop)
                        {
                            if (stops.CompareTo(comp2) == 0)
                            {

                            }

                        }
                    }
                }
            }
        }
        public DNA Cut(int Start, int End)
        {
            Console.WriteLine("CutMethodRun");
            string a = this.strand;
            string cutout = "";
            if (End < a.Length)
            { cutout = a.Substring(Start, End - Start+1);}
            else
            { cutout = a.Substring(Start, a.Length -Start); Console.WriteLine("EndPoint is Out of Bounds"); }
            return new DNA(cutout);
        }

        static string Cut(string a, int Start, int End)
        {
            string cutout = "";
            if (End < a.Length)
            { cutout = a.Substring(Start, End - Start + 1); }
            else
            { cutout = a.Substring(Start, a.Length - Start); Console.WriteLine("EndPoint is Out of Bounds"); }
            return cutout;
        }



        public List<DNA> Triplets()
        {
            List<DNA>  aListofTriplets= new List<DNA>();
            string a = this.strand;
            
            
            double NoOfTriplets = Math.Floor(  (a.Length*1.0)  /3);
            for (int i = 0; i < NoOfTriplets; i++)
            {
                string atrip = "";
                for (int j = i * 3; j < i*3 +3; j++)
                {
                    atrip += this.strand[j];
                }
                aListofTriplets.Add(new DNA(atrip));
            }
            return aListofTriplets;

        }

        public char CompPair(char x)
        {
            char achar = ' ';
            if (x == 'G')
            { achar = 'C'; }
            else if (x == 'C')
            { achar = 'G'; }
            else if (x == 'A')
            { achar = 'T'; }
            else if (x == 'T')
            { achar = 'A'; }
            else { achar = 'x'; }
            return achar;
        }

        public static DNA RandomDNA(int length)
        {
            Random myRand = new Random();
            string astrand = "";
            for (int i = 0; i < length; i++)
            {
                int randomnum = myRand.Next(0, 3);
                if (randomnum == 0)
                { astrand += 'G'; }
                else if (randomnum == 1)
                { astrand += 'C'; }
                else if (randomnum == 2)
                { astrand += 'A'; }

                else 
                { astrand += 'T'; }
                

            }
            return new DNA(astrand);
            
        }

        public override string ToString()
        {
            return this.strand;
        }
    }
}
