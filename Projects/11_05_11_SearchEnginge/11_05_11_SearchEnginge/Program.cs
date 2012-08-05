using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_05_11_SearchEnginge
{
    class Program
    {
        static void Main(string[] args)
        {
            //search for names.

            List<Students> ListofStudents = new List<Students>();
            ListofStudents.Add(new Students("Patrick Xie", "110352329", new date (28,10,1991), new date (30,09,2014)));
            //write a program to add new objects.



            RandomAddNewStudents(ListofStudents, 20);
            /*
            ListPrintOut(ListofStudents);
            int selector = 1;
            while (selector == 1)
            {
                AddNewStudents(ListofStudents);
                Console.Write("Enter 1 to continue:");
                selector = int.Parse(Console.ReadLine());
            }
            */


            ListPrintOut(ListofStudents);
            
            
            Console.ReadLine();


        }



        static void ListPrintOut(List<Students> a)
        {foreach (Students x in a){ Console.WriteLine(x); }}

        static void AddNewStudents(List<Students> a)
        {
            string Name, IDNo;
            int DOBday, DOBmonth, DOByear, Expiresday, Expiresmonth, Expiresyear;
            Console.Write("Name: "); Name = Console.ReadLine();
            Console.Write("ID: "); IDNo = Console.ReadLine();
            Console.Write("DOBday: "); DOBday = int.Parse(Console.ReadLine());
            Console.Write("DOBmonth: "); DOBmonth = int.Parse(Console.ReadLine());
            Console.Write("DOByear: "); DOByear = int.Parse(Console.ReadLine());

            Console.Write("Expiresday: "); Expiresday = int.Parse(Console.ReadLine());
            Console.Write("Expiresmonth: "); Expiresmonth = int.Parse(Console.ReadLine());
            Console.Write("Expiresyear: "); Expiresyear = int.Parse(Console.ReadLine());

            Console.Write("Create..."); Console.ReadLine();

            a.Add(new Students(Name, IDNo, new date(DOBday, DOBmonth, DOByear), new date(Expiresday, Expiresmonth, Expiresyear)));

            Console.WriteLine(a[a.Count - 1]);
        }

        static void RandomAddNewStudents(List<Students> a, int NoOfStudents)
        {
            Random s = new Random();
            
            Random RanGen = new Random();
            int max = 30;
            for (int i = 0; i < NoOfStudents; i++)
                a.Add(new Students(i.ToString(), RanGen.Next(99999999).ToString(), new date(RanGen.Next(max), RanGen.Next(max), RanGen.Next(max)), new date(RanGen.Next(max), RanGen.Next(max), RanGen.Next(max))));

            
        }
    }

    struct date
    {
        public int Day, Month, Year;

        public date(int Day, int Month, int Year)
        { this.Day = Day; this.Month = Month; this.Year = Year; }

        public date(int[] a)
        { this.Day = a[0]; this.Month = a[1]; this.Year = a[2]; }

        public override string ToString()
        { return Day + "/" + Month + "/" + Year; }

    }
    class Students
    {
        public string Name { get { return _Name; } }
        public string IDNo { get { return _IDNo; } }
        public date DOB { get { return _DOB; } }
        public date Expires;

        static private List<Students> ListofStudents = new List<Students>();

        private string _Name, _IDNo;
        private date _DOB;
        public Students (string Name, string IDNo, date DOB, date Expires)
        { this._Name = Name; this._IDNo = IDNo; this._DOB = DOB; this.Expires = Expires; }

        

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.Write("Name: {0} ID: {1} DOB: {2} Expires: {3}", Name, IDNo, DOB, Expires);
            return s.ToString();
        }

    }


}
