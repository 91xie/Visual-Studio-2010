using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraysTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * C# has a nnumber of useful clases and structrures for doing this:
             * arrays, list
             *  queues, stacks
             *  
             * Queues, Takes information and puts it at the end of the queue and the takes stuff out of queue from the top.
             * Stacks is similar, stack relating to memory and stuff.
             * 
             * Arrays and list will be the most useufl for us.....
             * 
             * Arrays are a must and lis is a very powerful thing as well.
             * allows you tocollect a whole lot of infomration into the one place.
             * Arrays are useful for linear alegbra
             * 
             * /ARRAYS
             * 
             * an array is a data structure that contians a number of elements of the same type.
             * it has a number of components that define it.
             * Matix, 2D array -. to get to the numbers, you give it the index [0,1]
             * vectors and complex 1D
             * 
             * Arrays are reference type objects which you have to insitiate.
             * 
             * Higher dimensional arrays are possible, up to 7. (which is usually not necessary)
             * Arrays implicity inherit from the System.ARray class---
             * they have a number of useful methods and porperties e.g. GetUpperBound(), GetLowerBound(), Length.
             * 
             * pass an array to a method, all of the methods from system.array pass on as well.
             * 
             * CREATING ARRAY
             * 
             * arrays are linked with their index, you have to give it an index.
             * 
             * to indicate you are trying to get an index, you use square brackets []
             * 
             * int [] myArray;
             * myArray = new int [4]; //you have to give it a size and you can't change the size. //myArray can store 4 int values
             * //Thus they are static because they don't change the overall size
             * //a little more 128bits are set aside to store this bit of information.
             * 
             * Stack [myArray] ->   Managed Heap
             *                      [int] myArray[0]
             *                      [int] myArray[1]
             *                      [int] myArray[2]
             *                      [int] myArray[3]
             *                      
             * int [,] a = new int [4,3]; // 4x3 matrix
             * dimension 0, vertical, dimension 1.
             * 
             * Its already a class, it inherits from array class, knows all about itself.
             * 
             * int [,] a = new int[,] {{1,2,3,},{2,4,6},{3,5,7},{1,3,9}}; note that would a 4x3 array, computer decides how big it is going to be.             * 
             * 
             * EXAMPLES OF USES OF ARRAYS
             * matrix multiplication#
             * 
             * takes 2 arrays and gives you out another matrix.
             * 
             * a possible algortihm for doing this would be:
             * 
             * check that the
             * if NOT (number of colums in [A] = numbekr of rows in [B]) then terminate
             * 
             * for i = 1 to p 
             *  for j = 1 to r
             *      C i,j = 0
             *          for k - 1 to q
             *              c i, j += sum of A i,k * B k,j
             *          next k
             *  next j
             * next i
             * 
             * 
             * multiplication of matrix
             * 
             * 
             * public double [,]MatMult (double [,] A, double [,] B) // this is a method
             * {
             *      
             *      for i = 0 to N
             *              for j = 0 to M;
             *              Cij = 0
             *                  
             *                          For K = 1 To P
             *                              Cij += Aik * Bkj
             *                          Next k
             *                Next
             *       Next
             *                          
             * 
             * 
             *  return a 2D array
             * }
             * 
             * 
             */



            int[] myArray = new int[4] {4,2,5,10};

            //an array may be given intiial starting values in amany differnt ways e.g. the following are all equivalent.

            int[] myArray1 = new int[4] { 4, 7, 11, 2 };
            int[] myArray2 = new int[] { 4, 7, 11, 2 }; //given x number of values, the myArray2 makes it x size.
            //most of the time you won't have initial values so you just create an array with a certain size.

            //how do we access the elements?
            //use an index.

            //you can access individual values.

            int v1 = myArray[0]; //1st element in the array which you assign to a new int v1.
            myArray[3] = 31; //you can assign numbers in the array.
            myArray[3] *= 2; // you can treat the indexed bits as integers.

            //how to print out values
            Console.WriteLine("myArray[{0}]:= {1}", 0, myArray[0]);
            Console.WriteLine("myArray[{0}]:= {1}", 1, myArray[1]);
            Console.WriteLine("myArray[{0}]:= {1}", 2, myArray[2]);
            Console.WriteLine("myArray[{0}]:= {1}", 3, myArray[3]);

            //because they are type array, there are methods.

            //GetUpperBound (dimension) gets the upper bound (highest) indew of the specified dimension (zero indexed) in the array. if it says 4, it's actually 5D because it is zero indexed.
            //GetLength(dimension) gets a 32 bit integer that represents the number of the elements in the specified deimnsion zero indexed of the array (how many elements in the array)

            Console.WriteLine(myArray.Length);
            Console.WriteLine(myArray.GetUpperBound(0)); //very useful
            //=============


            Random myR = new Random();//2nd method, int Seed -> gets you the same values.

            int n, i;
            Console.WriteLine("Enter the size of the array: ");
            n = int.Parse(Console.ReadLine());

            double[] nums = new double[n];
            //use a for loop to acces and asign each
            //element of the aray sequentially
            for (i = 0; i <= nums.GetUpperBound(0); i++)
                nums[i] = myR.NextDouble() * 10;
            //use a similar for loop to acess and print
            //out value of each earray element.
            for (i = 0; i < nums.Length; i++)
                Console.WriteLine("nums({0,2:d}) = {1,8:f4}", i, nums[i]);

            //2D arrays

            int[,] a = new int[3, 4]; //4x3 size matrix. 3 across, 4 down. (first index is the row, second is the column) // don't forget zero indexing
            //any table could be stored as an array
            //get a code that would access every single element of the matrix =>  need one for the row, need one to get the index of the column.
            //similar to a table.

            //jagged array, array in an arra where the elements of the array reference other arrays

            int[][] b;
            b = new int[3][];

            b[0] = new int[] { 1, 2 }; //create first array
            b[1] = new int[] { 3, 5, 7, 9 }; // ceate second
            b[2] = new int[] { -1, 3, -5 }; // create third.
            //jagged arrays are faster than 2D arrays. this is not necessary for our assignment.
            i = 0;
            for (i = 0; i < b.Length; i++)
                Console.WriteLine(array2string(b[i])); //automated string writer for printing out arrays


            //jagged arrays are arrays of reference types.
            //all arrays are reference types.

            //if you want to copy (and not the reference but the values) and create a new array from it, you must use myArray.Clone
            //copies an array but you need to tell it what type it is.

            int[] myArrayC = new int[] { 4, 7, 11, 2 };
            int[] arrayCopy = (int[])myArrayC.Clone();
            //you may wish to copy the array, you can meessa round with the new copy and that you don't need to worry about messing up the original.
            

            //you can array anything... including class objects

            /*
             *static void main
             *{
             *
             * myClass [] a = new myClass[] {   new myClass(),
             *                                  new myClass(),
             *                                  new myClass(),
             *                                                  }; //you actually have three objects. new references to those three objects.
             *
             *}
             *
             * a[0].a = 1; a[] is a myclass. similar to saying myclass b = new myclass b.a; you can go a[0].a 
             * //how you store objects in the struct in a lakeclass
             * 
             * class myClas {int a; int b}
             * 
             * 
             */

            /*
             * List<T>
             * list is a very useful clas for creating a flexible colledtion of objects
             * they are not fixed size and objects may be adeed using the Add() method.
             * you can creat a liste of types.
             * this makes them very extendable.
             * you don't initialise, you just keep adding objects to the list.
             * these classes are freferreded.
             * 
             */

            List<int> numbers = new List<int>();
            for (i = 0; i < 4; i++)
                numbers.Add(5);
            int NumberCounter = numbers.Count;
            
            Console.ReadLine();


            }

        static string array2string(int [] x )
    {
        System.IO.StringWriter s = new System.IO.StringWriter();
            for ( int i = 0; i< x.Length; i++)
            {
                s.Write("  {0,2:D}", x[i]);
            }
            return s.ToString();
            //automated string writer for printing out arrays
    }
    }
}
