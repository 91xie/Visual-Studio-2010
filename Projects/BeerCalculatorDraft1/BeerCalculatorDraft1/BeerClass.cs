using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalculatorDraft1
{
    class BeerClass
    {
        string Name, Shop;
        double units, volume, totalcost;
        double costperlitre { get {return _costperlitre; } }
        private double _costperlitre;

        public BeerClass(string Name, string Shop, double units, double volume, double totalcost)
        { this.Name = Name; this.Shop = Shop; this.units = units; this.volume = volume; this._costperlitre = (units * volume) / totalcost; }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("Name: {0} Shop: {1} Units: {2} Volume/Unit: {3} TotalCost:{4} Cost/litre:{5}",Name,Shop,units,volume,totalcost,costperlitre);
            return s.ToString();
        }

        //learn how to make an internal list. everytime you create an object, you add it to the list.

    }
}
