using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win_Spam_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string anotherstring = textBox1.Text;
            int iterations = int.Parse(textBox3.Text);

            for (int i = 1; i < iterations; i++)
            {
                anotherstring += anotherstring;
                label3.Text = i.ToString();
            }

            textBox2.Text = anotherstring;

            label1.Text = string.Format("Characters: {0}", anotherstring.Count());
            label2.Text = string.Format("Pages     : {0}", anotherstring.Count() / 4500);
            
        }
    }
}
