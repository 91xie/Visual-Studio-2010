using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE1005_StackHeap
{
    class Program
    {
        static void Main(string[] args) //program starts at main.
        {
            myClass a = new myClass (2,6);
            Console.WriteLine(a);
            myClass b;
            b =a; //both a and b are pointing to the same memory location.
            b.x *=3;
            Console.WriteLine(a); //copied the reference... if you change the object, a refers to the same object as b and you get the same output.

            myStruct p = new myStruct(8,7);

            Console.WriteLine(p);

            myStruct q;
            q = p;
            Console.WriteLine(q);
        }
    }


    class myClass
    {
        public int x, y;
        double _z;
        public double z { get { return _z; } set { _z = Math.Abs(value); } }
        public myClass (int x, int y_ {this.x = x; this.y =y;}
        public int P1 {get {return x*y;}}
        public override string  ToString(){ return "x=" + x + " y =" + y + "z= " + z;}

    }

    struct myStruct
    {
        public int a, b;
        public myStruct (int a, int b) {this.a = a; this.b = b;}
        public int P1 {get {return a*b;}}
        public override string  ToString() {return "a= " + a + "b= " + b;}
    }


}

