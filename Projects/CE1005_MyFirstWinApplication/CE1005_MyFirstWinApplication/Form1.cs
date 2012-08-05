using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CE1005_MyFirstWinApplication 
{
    public partial class Form1 : Form //has the word partial because its fined in 2 bits.
    {
        public Form1()
        {
            InitializeComponent();
            btnAButton.Click += new EventHandler(btnAButton_Click);
            btnAButton.MouseEnter += new EventHandler(btnAButton_MouseEnter);
            btnAButton.MouseLeave += new EventHandler(btnAButton_MouseLeave);

        }

        void btnAButton_MouseLeave(object sender, EventArgs e)
        {
            btnAButton.BackColor = Control.DefaultBackColor;
        }

        void btnAButton_MouseEnter(object sender, EventArgs e)
        {
            btnAButton.BackColor = Color.Aquamarine;
        }

        void btnAButton_Click(object sender, EventArgs e) //don't worry about the two arguments.
            //object sender, where the info was recieved.
        {
            string s = "Hello ";
            s += tbxStuff.Text; //what ever you type in the text box, it returns as a string
            //throw new NotImplementedException(); //default
            MessageBox.Show(s);
            label1.Text = s;
        }
    }
}
/*Press Button -> Triggers an event (Triggers a "click" event
 * 
 * for button click event run a method
 * 
 * need a method to "handle" this event "Button.Click"
 * 
 * 
*/