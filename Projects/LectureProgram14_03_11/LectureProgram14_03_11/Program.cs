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
            Shapes s = new Shapes(new Point2D());
            s.centroid.x = 2;
            s.centroid.y = 3;

            circle c = new circle(new Point2D());
            c.centroid.x = 1;
            c.centroid.y = -3;
            c.area = 5;
            
            rectangle r = new rectangle(new Point2D());
            r.centroid.x = 0;

            Console.ReadLine();
        }
    }
}
/*
 *Inheritance-Parent Class/base class
 *object derived from class are child classes or derived classes.
 *
 * [parent
 * members:
 * m1, m2]
 * 
 * [child 1]//inherits from parent
 *inhertis parent members:
 *m3 (m1, m2 and m3);
 *
 * [child 2 also inhertis parent
 * m1,m2,m4,m5]
 * 
 * basically put all of the common stuff to the the parent class.
 * and derived ths tuff for the other derived classes.
 * 
 * An example
 * to write a program for 2D shapes.
 * 
 * a number of classes are needed to store information about planarr shaes. for exampele it is a necessary to bre able to store relevant infromation about circlesd and rectanges. it has been decidded that following funcationality is necessary:
 * a circle shpae has the followingf atttirbutes:
 * centroid co -oordinates
 * area
 * radius
 * for the circle, we may only need 2 to define it.
 * 
 * a recatnge shape object has the following atttributesA:
 * centroid co-ordinates are length width
 * the following class structure has been decided.
 * 
 * write a program store the information about circles and rectangles...
 * things that are in common are centroids and areas. (this could be in a parent class)
 * area depends on the shape...
 * all have a perimeter which also depends on the shape...
 * 
 * cShape [centroid as point_2D] - cPoint 2D [x as double, y as double]
 *              |
 *             /  \
 * cCircle              cRectange
 * [inherits cShape     [Length as double
 * radius as double]    inheritsCshape
                        width as double]
 
 */