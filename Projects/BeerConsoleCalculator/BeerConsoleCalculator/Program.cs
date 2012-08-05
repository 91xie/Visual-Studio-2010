using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BeerClass> ListofBeers = new List<BeerClass>();
            
            Console.WriteLine("1. Add new Beer");
            int Selector = int.Parse(Console.ReadLine());
            while (Selector == 1)
            {
                Console.Write("Name="); string Name = Console.ReadLine();
                Console.Write("Shop="); string Shop = Console.ReadLine();
                Console.Write("Units"); double Units = double.Parse(Console.ReadLine());
                Console.Write("Volume"); double Volume = double.Parse(Console.ReadLine());
                Console.Write("TotalCost"); double TotalCost = double.Parse(Console.ReadLine());

                
                

                ListofBeers.Add(new BeerClass(Name, Shop, Units, Volume, TotalCost));
                for (int i = 0; i < ListofBeers.Count; i++)
                { Console.WriteLine(ListofBeers[i]); }
                double Checker = 100;
                int checkerindex = 0;
                for (int i = 0; i<ListofBeers.Count;i++)
                {
                    double val = ListofBeers[i].costperlitre;
                    if (val < Checker)
                    { Checker = val; checkerindex = i; }
                    
                    
                }
                Console.WriteLine("Cheapest:{0}", ListofBeers[checkerindex]);
                //Show lowestCost beer
                Console.WriteLine("1. Add and Continue");
                Selector = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Byebye");
            Console.ReadLine();
        }
    }

    struct BeerClass
    {
        public string Name, Shop;
        public double units, volume, totalcost;
        public double costperlitre { get { return _costperlitre; } }
        private double _costperlitre;

        public BeerClass(string Name, string Shop, double units, double volume, double totalcost)
        { this.Name = Name; this.Shop = Shop; this.units = units; this.volume = volume; this.totalcost = totalcost; this._costperlitre = (units * volume) / totalcost; }

        

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Name: {0} Shop: {1} Units: {2} Vol/Unit: {3} TotalCost:{4} cost/l:{5}", Name, Shop, units, volume, totalcost, costperlitre);
            return s.ToString();
        }
    }
}
