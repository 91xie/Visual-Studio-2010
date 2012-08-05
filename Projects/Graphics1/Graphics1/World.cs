using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Graphics1
{
    class World
    {
        public List<Point> points;
        public List<Rectangle> rectangles;
        public World()
        {
            rectangles = new List<Rectangle>();
            points = new List<Point>();
        }

        public void Draw(Graphics g)
        {
            foreach (Rectangle r in rectangles)
            {
                g.DrawRectangle(Pens.Red, r);
            }
            if (points.Count > 1)
            {
                for (int i = 0; i < points.Count()-1; i += 2)
                {
                    g.DrawLine(Pens.Black, points[i], points[i + 1]);
                }
            }
        }
    }
}
