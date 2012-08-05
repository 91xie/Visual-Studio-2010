using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE1005_StackHeap2
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
            Console.WriteLine(p);
            Console.WriteLine(q);
            q.a *= -2;
            Console.WriteLine(p);
            Console.WriteLine(q);

            anotherClass.count = 2;
            Console.WriteLine("anotherClass.x= ", anotherClass.count );

            anotherClass o1 = new anotherClass();
            anotherClass o2 = new anotherClass();
            anotherClass o3 = new anotherClass();

            o1.y = 10;
            o2.y = -4;
            Console.WriteLine("o2.x:=" + o2.y);

        }
    }

    class anotherClass
    {
        public int y;
        public static int count; //all statics are stored on the stack //first put memory space for all statics.
        //statics are given the first memory locations.
        // it is called static because it doesn't move.
        public anotherClass ()
        {count=+1;}
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

