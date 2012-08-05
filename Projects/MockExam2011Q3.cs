using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static public void Main()
        {
            Child a;
Parent b;
int i;
List<Parent> Parents = new List<Parent>();

for (i = 1; i <= 2; i++)
{
a = new Child(i, 2 * i, 3 * i);
Parents.Add(a);
}
for(i = 0; i < Parents.Count; i++)
{
b = Parents[i];
Console.WriteLine(b.OutString());
Console.WriteLine("Length: {0} ", b.Sum);
}
for(i = 0; i < Parents.Count; i++)
{
a = (Child) Parents[i];
Console.WriteLine(a.OutString());
Console.WriteLine("Length: {0}", a.Sum);
}
Console.ReadLine();

        }
        abstract public class Parent
        {
            public int x, y;
            public int Sum { get { return x + y; } }
            public virtual string OutString() { return x + " " + y; }
        }
        public class Child : Parent
        {
            public int z;
            public Child(int x, int y, int z)
            {
                this.x = x; this.y = y; this.z = z;
            }
            public int Sum { get { return x + y + z; } }
            public override string OutString()
            {
                return x + " " + y + " " + z;
            }
        }
    }
}
