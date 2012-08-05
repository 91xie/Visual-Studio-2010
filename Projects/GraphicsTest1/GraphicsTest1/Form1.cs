using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicsTest1
{
    
    public partial class Form1 : Form
    {
        World myWorld;

        public Form1()
        {
            InitializeComponent();
            myWorld = new World();
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            myWorld.Draw(pictureBox1.CreateGraphics());
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pictureBox1.Size.Height>e.X && pictureBox1.Size.Width>e.Y && e.Location.X>0 &&e.Location.Y>0)
            {
                myWorld.points.Add(e.Location);
                myWorld.Draw(pictureBox1.CreateGraphics());

            }
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                myWorld.points.Add(e.Location);
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            myWorld.Draw(pictureBox1.CreateGraphics());
        }
    }
}
