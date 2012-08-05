using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_04_11c
{
    class Program
    {
        static void Main(string[] args)
        {

            //Structs and Object Orientated Programming.

            /*
             * an object is an instance of a class/struct.
             * a object is not a class/struct.
             * a class/struct is not an object.
             * 
             * class/struct is more like a blue print.
             * objects are real and are stored in memory.
             * 
             * ARGUMENT PASSING
             * 
             * invoking program to both send and receive values from the invoked procedure.
             * 3 situations c# caters for to determin how a variable is handled by the procedure.
             * 
             * value call - the variabl (either value or reference is copied in the method. changes made in the method are NOT permanent. (just copies the value to use...)
             * ref call - the variable (either value or reference is pased directly to the method. changes made in the method ARE permanent. (gets the object from referenced location and manipulates that directly)
             * out call - explicity defining one way variable transfer.
             * 
             * passing by value call. (c# default)
             * allows the value of the variable to be recieved by te invoked procedure.
             * value doesn't get changed in the procedure.
             * 
             * passing by ref.
             * any modification done during the method would be change the invoking object(s).
             * 
             * dangerous but could be handy if you want more than one value returned in a method.
             * 
             * 
             * passing out out 
             * need not be assinged a vlue before being pased to the method. 
             * 
             * 
             * //Properties...
             * get and set...
             * get is readonly {get {return;}}
             * 
             * 
             * //STUFF
             * STUFF
             * STUFF
             * 1. look over properties...
             * 2. look over passing value call, reference call and out call
             * 
             * 
             
             */

            //==============
            /* 
             VARIABLES- is an OJBECT that cane store data during runtime.
             * Identifier is the name.
             * type is the type of data (like double, int string etct)
             * 
             * 2 types of variables.
             * 1. Value type
             * 2. Reference type
             * ==========================
             * 1. VALUE TYPEconsidering value type variables for the moment
             * Variables which refer directly to the data. any manipulation is carried out directly on the value stored in the memory location.
             * int n = 33; assigns 33 to this memory location called n. whatever you do to change "n" it will change the value which is stored in n.
             * value types are sotred onthe "stack"
             * 
             * passing by value call. (c# default)
             * allows the value of the variable to be recieved by te invoked procedure.
             * value doesn't get changed in the procedure.
             * 
             * value type objectds.
             * the identifer of an objecdt is assocaited directly with it's value(s).
             * assignment (LHS of a =) results in a full copy of the object being formed.
             * all primitive date types are value types, structs included.
             * 
             * reference type;
             * the identifier is associated directly references the memory location.
             * assignment results in a copy of the reference. 2 identifiers could reference the same objet.
             * 
             * ========================
             *2.  reference types which store the reference to the actual data is stored on the heap.
             * passing by ref.
             * any modification done during the method would be change the invoking object(s).
             * 
             * dangerous but could be handy if you want more than one value returned in a method.
             * 
             * 
             * 
             * 
             */

            //lecture 7
            /*
             * stack and heap
             * 
             * class instiated to a reference type object
             * struct creates a value type object.
             * 
             * classes can have paramterless default constructors.
             * must have a finalizer
             * they ahve have virtual members(abstract classes basically)
             * 
             * class instiates to reference type objects refers directly to the memory location and what's stored inside it.
             * deleting the class object is only deleting the reference.
             * it only really gets deleted by the memory which was used for storage is handed back.
             * 
             * finalizer is inherited for system.object
             * 
             * 
             * STACK
             * block of memoery that stroes local and static variables.
             * last in, first out. grows as program enters a method and shrinks as it leaves a method...
             * local variables like the ones in a method, and when the method is used up, those variables could be deleted.
             * 
             * stack is structured and related to
             * the scope (like once it leaves a scope, the locals would be deleted.)
             * procedural structure of the program
             * why code blocks could not overlap
             * 
             * it stores
             * the actdual values of all local value type objects
             * the mmeory location of the heap of the entry point to an instantiated reference type object.
             * all static objects. 
             * 
             * HEAP
             * a contigous block of memeory wher the date for reference type objects are stored once it is instiated.
             * managed by .NET framework
             * times, the stuff is "dereferenced" and the garbage collector throws th stuff away.
             * unstructured in a sense. garbage collector goes through this.
             * heap is only effected by the GC
             * heap sotreds all instance variables (the fields of the ojbect it's data).
             * 
             * 
             * 
             * 
             
             */
            Person Peter = new Person("Peter", 18);
            Console.WriteLine(Peter.Name);

        }

        struct Methods
        {
            public void Method1(int a)
            { a *= 2; }
            public void Method2ref(ref int a)
            { a *= 2; }

        }
        class Person
        {
            public string Name { get { return _Name; } }
            public int Age;
            private string _Name;

            public Person(string _Name, int Age)
            { this._Name = Name; this.Age = Age; }

        }
    }
}
