using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureProgrammeClasses //namespace takes everything in the same namespace and puts them altogether.
//namespace means they all have the same "scope"
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *Classes is a the bigger version of a struct.
             * 
             * Classes instatisates to a reference tyoe object.  Struct which creates a value type object.
             * Classes can fully do inheritance. make your life easier when it comes to making new classes.
             * everything that we have learned so far for structs applies to classes too. ie parameter, properties, constructors etc.
             * when you delete an object, you delete the reference and initiate a method called a finaliser.
             * class can have virtual members(inheritance).
             * 
             * Classes can have: fields, properties and methods.
             * instantiating a class requires mandatorues use of the new keyword.
             * Constructors are the same and you may provide default parameterless constructors.
             * 
             * 
             * 
             */

            

            // can't use "a.x =1 " as you've made a constructor in the class which overrides the default constructors.
            //after creating a default constructor, it outputs (0,0,0)
            
            //CLASS VS STRUCT
            /*
             * the class has additional functioanlity
             * have to provide your own constructors because it is a reference type object.
             * doesn't refer to any particular value but a reference which is stored.
             * 
             * structs inherit from system type ->
             * e.g
             * "struct MyStruct {...}
             * you can visualise MyStruct as a box.
             * and above it is "System.ValueType" and inherits from it.
             * "System.ValueType" inherits from "System.Object"
             * ---------------------------
             * "class MyClass {...}
             * classes would reference from "System.Object"
             * 
             *   classes also need to get a finalise method (delete reference method)
             *   
             *   instiating must use "new" keyword. c = a+b (in the override operater, notice there is "new Vector3D")
             *   
             */

            //INTRO TO DELETING AN OBJECT
            /*
             * for memory issues.
             *  MyClass a = new MyClass ();
             *  a refers to a block of memory.
             *  a.x refers to a specific value.
             * 
             * Vector3D a, b, c;
             * a = new Vector3D(1,3,-6); .... this process is called instantiation.
             * setting aside the memory for this object.
             * anything that is complex takes memory.
             * on small programs, not an issue but for bigger array of this could cause problems.
             * you could be like "I'm finished with this" and delete stuff afterwards.
             * 
             * This section is called deleting an object but you don't actually delete anything.
             * d is a reference.
             * d-> 32bit (x=0, y=1, z =2) (references a memory location)
             * d.x-> 0 
             * d.y= 10;
             * d-> 32bit (x=0, y=1, z =2)
             * the identifier d is a reference.
             * and when you want get something into the 
             * 
             * deleting, delete the reference and hand the information back to the system.
             * d = null; ... null is like the opposite to new.
             * new sets up the reference and null deletes it.
             * the memory that was used and is not set to null is now tagged.
             * it is tagged that it can be used for system.
             * difference between c++ and c# is the memory management.
             * c++ you had to explicity handle the memory management.
             * c# does it for you.
             * c# it runs a program called garbage collection.
             * goes through all the memory which is tagged and hands back to the system
             * and then deletes it.
             * null doesn't actually do that.
             * the big implication is that at the end of running the program (even if it crashes), it collects all the bits and deletes it.
             * c# manages memory for you. don't have to worry about i.
             * 
             * c++ on the other hand, all of the memory is stored (unless you write memory management for it)
             * problem is that after a while, after a no. of runs, one may run out of RAM and the computer crashes.
             * 
             * MyClass a = new MyClass;
             * 
             *=> a stores the memory location where the class is stored
             *Since it is more complex (storing methods, different fields) it will take up a lot of memory
             *As the process works through, there is a potential that RAM would run out.
             *Which is why you set stuff to null when you are finished.
             *
             * Problems with deleting.
             *
             * 
             *int a =10;
             *this would exist as long as it is in scope
             * 
             */



            /*
             *Scope of any identifier is the block
             *
             * namespace: essentially a container... all part of the same family if you wish.
             * just a way of arranging everything.
             * only thing you can contain classes and no variables.
             * It's like a folder basically.
             * 
             *Next level down: classes and structs. one can start declaring methods, properties, variables etc.
             *Class scope, it only makes sense within that class.
             *
             * method scope, declaring variables which are only visible and make sense within a method.
             * 
             * statement blocks, variables which are only valid within the loop.
             * 
             * Namespace Ns.name
             * {
             * 
             *      class myclass
             *      {   
             *          int a; // this is one a
             *          void m1 () {int c; c=a;}
             *      }
             *      
             *      class myotherclass
             *      {
             *          int a; //this is a different a altogether.
             *          public myotherclass (int a) {this.a = a;} // this refers to the object that does the invoking. myotherclass b = new myotherclass(3)
             *          //this-> "b" replace "this" with "b" and it makes sense.
             *      }
             * }
             * SCOPE RELATION TO PROJECT FILES
             * multiple namespaces allowed in the one file.
             * - a namespace can be deinfed across multiple files
             * - will be brought together a tbuild tie mas a single namespace.
             * classes may be defind across multiple files - use the partial class keyword (forms are multiple classes)
             * 
             * VALUE AND REFERENCE TYPE OBJECTS
             * VALUE TYPE: the identifier of an object is associated directly with it's values.
             * assigment ie on the lhs of an = results in a full copy of the object being formed
             * all primitive date types are value types, as are structs.
             * 
             * value refers to where the object is double a, int a
             * 
             * REFERENCE TYPE
             * the identifier is associated directly reference the memory location.
             * assingmen results in a copy of the reference being formed. ie two idetifiers can reference the same object
             * all instatiated classes are referne type variables.
             * this is hwy structs do not need to be explicity instatiated and classes do.
             * we will explain the subtlieties with examples in the lecture
             * 
             * classes are reference types.
             * you have to explicity instiated.
             * 
             * reference is like an address
             * "my object refers to the first location of the memory there (memory location).
             * obj (refers to big block of memory, like value)
             * obj.a (bit of big block of memory)
             * 
             * "which thing in memory do you want?"
             * a.x
             * a.y
             * 
             * thing before the 
             * 
             * 24/02/2011
             * 
             * myClass a; ->takes a block of memory and calls that block of memory a (sets aside one memory location for a: a-> X999
             * a = new myClass; goes for the heap, takes a block of memory for the class block of memory called X999
             * a.n = 3; block of [x999 (n)3]
             * 
             * 
             * myClass x; (reference type)
             *
             * the stack- block of memoery that sotres local and static variaables.
             * it has a last in first out protocl. groows as the program enters ta method and shirnks as it leaves the method.
             * visualise it a stack of memory that is continuously growing and shrinking as the program progresses.
             * 
             * memory manage decides which is which. 
             * 
             * the heap is contigious block of memory and wher ethe date for a freference type object is stored once it is instantiated.
             * 
             */ 
            


            Vector3D a = new Vector3D();
            
            Console.WriteLine(a);
            a = null;
            Console.WriteLine("a = {0}", a);
            //when you try to set the x value of a, it crashes.
            //a no longer references to a vector3D.
            a.x = 2;
            Console.WriteLine("a = {0}", a);
        }

    }

//Project > Add Class...

}

