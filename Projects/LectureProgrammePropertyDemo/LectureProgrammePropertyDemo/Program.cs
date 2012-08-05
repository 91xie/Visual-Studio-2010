using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct x = new MyStruct();
            x.a = 9; // can't access a because a is private until you set the properties
            x.b = 18;
            Console.WriteLine(x.a);
            Console.WriteLine(x.b);
            Console.ReadLine();
        }

        struct MyStruct
        {
            private int _a; //use underscore to indicate private variable, abitof a convention
            //reason: you might have a restriction of the value that field would take.
            //e.g field cannot be negative. ie positive field.
            //use a property called a to access it.

            public int a 
            { 
                get //two bits get
                    //get access to _a
                { 
                    return _a; 
                } 
                set //set: sets the value of _a
                {
                    if (value < 0) //give controlled acces to your field variables.
                        _a = 0; // the value that you get is less than 0 than it would default to zero.
                    else

                    _a = value; 
                
                } 
                        //takes 9, takes a variable called value and then you can assign that to an internal private variable.
                //within get and set you can put in other code.

             }//declaration of a property
            
            //properties also don't take parameters because it's not a method.
            //eg.for vector3D Magnitude() becomes Magnitude without the bracket/argument parameters


            public int b
            {
                get { return _a * 2; }
                set { _a = value; }
            }

            //get on it's own means the peroperty is readonly -very common usage.
        //Software developers say you should declare everything and then write accessers.
            //this gives us the oppurtunity to change or adjust properties in the future.
        
        
        
        }
    }
}
