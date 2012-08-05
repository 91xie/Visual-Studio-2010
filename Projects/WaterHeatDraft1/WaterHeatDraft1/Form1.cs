using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaterHeatDraft1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1calculatecostpermin.Click += new EventHandler(button1calculatecostpermin_Click);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            comboBox2flowrate.SelectedIndexChanged += new EventHandler(comboBox2flowrate_SelectedIndexChanged);
            
        }

        void comboBox2flowrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2flowrate.SelectedIndex == 0)
            { textBox5flowrate.Text = 5.ToString(); }
            else if (comboBox2flowrate.SelectedIndex == 1)
            { textBox5flowrate.Text = 9.5.ToString(); }
            else if (comboBox2flowrate.SelectedIndex == 2)
            { textBox5flowrate.Text = 3.5.ToString(); }
            else if (comboBox2flowrate.SelectedIndex == 3)
            { textBox5flowrate.Text = 11.ToString(); }
            
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { textBox2energyperlitre.Text = 35000000.ToString(); }
            else if (comboBox1.SelectedIndex == 1)
            { textBox2energyperlitre.Text = 38000000.ToString(); }
            else if (comboBox1.SelectedIndex == 2)
            { textBox2energyperlitre.Text = 41200000.ToString(); }
        }

        void button1calculatecostpermin_Click(object sender, EventArgs e)
        {
            
            double ee, E, europerlitre, deltaT, f,c, mins, m, massofwaterperday;
            
            System.IO.StringWriter s = new System.IO.StringWriter();
            c = 4180;
            ee = double.Parse(textBox1efficiency.Text);
            E = double.Parse(textBox2energyperlitre.Text);
            deltaT = double.Parse(textBox3tempdiff.Text);
            europerlitre = double.Parse(textBox4costperlitrefuel.Text);
            f = double.Parse(textBox5flowrate.Text);
            mins = double.Parse(textBox1minperday.Text);

            m = ((ee * E) / (c * deltaT));
            massofwaterperday = f * mins;

            double costpermin =((1/m) * europerlitre * f);
            double costperday = costpermin * double.Parse(textBox1minperday.Text);
            double costperyear = costperday * 365;

            double oilperday = massofwaterperday / m;
            double oilperyear = oilperday * 365;

            double europerkwh = double.Parse(textBox1kWh.Text);

            double energykwh = 3600000;

            double kwhpermin = (f * c * deltaT) / energykwh;
            double kwhperday = (massofwaterperday*c*deltaT)/energykwh;
            double kwhperyear = kwhperday*365;

            double costinkwhpermin = kwhpermin * europerkwh;
            double costinkwhperday = kwhperday*europerkwh;
            double costinkwhperyear= kwhperyear*europerkwh;

            label1costpermin.Visible = true;
            s.WriteLine("Cost in Oil/min = {0,2:c3} \nCost in Oil/day = {1,2:c2} \nCost in Oil/year = {2,2:c2}",costpermin, costperday,costperyear);
            s.WriteLine("");
            s.WriteLine("Cost in kWh/min = {0:c3} \nCost in kWh/day = {1:c3} \nCost in kWh/year = {2:c2}", costinkwhpermin, costinkwhperday, costinkwhperyear);
            s.WriteLine(""); 
            s.WriteLine("Oil/day = {0:f3}l \nOil/year = {1:f3}l", oilperday, oilperyear);
            s.WriteLine("");
            s.WriteLine("kWh/day= {0:f3} \nkWh/year = {1:f3}",kwhperday,kwhperyear);
            
            
            label1costpermin.Text = s.ToString() ;

        }

        
    }
}
/*Adding Functionality to a C# ComboBox

By default the user will be able to select items in the ComboBox but that is all. The programmer can write additional functions that use the contents of the ComboBox, but they can also create a function that will run whenever the ComboBox selection is changed. The programmer does this by adding an event listener:
cboExample.SelectedIndexChanged +=
new EventHandler(this.combo_selected);

Now the function "combo_selected" will run whenever the user changes the selected item. This means that the programmer will need to write the function to be called by the event handler:
public void combo_selected(object Sender, EventArgs e) {
MessageBox.Show(
"Day = " + cboExample.Text
+ ": Planet = " + planets[cboExample.SelectedIndex]);
}

In this example the function returns a message box containing day selected and the planet from which the day name is derived. It does this by using the selected item's index number to reference the contents of an array such as:
private string[] planets = {
"Sun",
"Moon",
"Mars",
"Mercury",
"Jupiter",
"Venus",
"Saturn"};

Read more at Suite101: How to Add a ComboBox to a C# Windows Form: Adding and Populating a C# ComboBox in a Windows Application | Suite101.com http://www.suite101.com/content/how-to-add-combobox-to-a-c-windows-form-a109998#ixzz1RiGO4jZx
*/

/*could try developing a class for all this*/