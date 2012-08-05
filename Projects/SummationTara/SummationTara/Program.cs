using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double answer = 0;
            for (int i = 0; i <= 499; i++)
            {
                answer += 2 * i + 1;
                Console.WriteLine("ith term:{0} current a= 2*n + 1 : {1} Current Sum = {2}",i+1, 2*i +1, answer);
                if (i == 10)
                    Console.ReadLine();
 
            }

            Console.WriteLine(answer);
            Console.ReadLine();

        }
    }
}
