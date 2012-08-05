using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphics1
{
    public partial class Form1 : Form
    {
        //client object which raises an event.
        //services object, which raises an event.
        //think of the client object, handles the event.
        //service flows to client object.
        //client object is actively listening and waiting for something to happen.
        //service object could be a button which could be clicked.
        //it triggers the event.
        //the client may or may not be listening to it.
        //client has an event tied to the service object.
        //then goes to function which is delegated to that event.
        //the method has an argument list.

        World myWorld;
        public Form1()
        {
            InitializeComponent();
            myWorld = new World();
            myWorld.rectangles.Add(new Rectangle(50, 25, 100, 150));
            button1.Click += new EventHandler(button1_Click);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            //pictureBox1.MouseMove -= pictureBox1_MouseMove;


        }

        
        
        void pictureBox1_MouseDown(object sender, MouseEventArgs e)//2events mouse event is also a class. mouse event is an object.
        {//it can check what button it is pressed, also it tells you where the mouse is when it's clicked.
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //add new point
                myWorld.points.Add(e.Location);
                
            }

        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = string.Format("({0},{1})", e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                myWorld.points[myWorld.points.Count-1] = e.Location;
            }
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //add new point
                myWorld.points.Add(e.Location);
                this.Refresh();
            }
        }


        protected override void OnPaint(PaintEventArgs e)//means all the stuff will be drawn every single time to stop graphics from disappearing.
        {
            base.OnPaint(e);
            myWorld.Draw(e.Graphics);
            myWorld.Draw(pictureBox1.CreateGraphics());

        }

        void button1_Click(object sender, EventArgs e)
        {
            myWorld.Draw(this.CreateGraphics());
            myWorld.Draw(pictureBox1.CreateGraphics());
            myWorld.Draw(button2.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
