using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ass2b_110352329
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            ObservationStruct[] Observations = new ObservationStruct[]
            {
                new ObservationStruct(0,23,15),
                new ObservationStruct(1,23,14),
                new ObservationStruct(2,23,14),
                new ObservationStruct(3,22,14),
                new ObservationStruct(8,20,14),
                new ObservationStruct(9,20,15),
                new ObservationStruct(10,19,14),
                new ObservationStruct(12,12,7),
                new ObservationStruct(18,11,7),
                new ObservationStruct(23,10,7),
                new ObservationStruct(29,10,6),
            
            };

            LakeClass Lake = new LakeClass(Observations, "Lake Nepressing", 2.3, 35);
            textBoxName.Text = Lake.name;
            textBoxDepth.Text = System.String.Format("{0}", Lake.maxdepth);
            textBoxArea.Text = System.String.Format("{0}", Lake.area);
            textBoxEpi.Text = System.String.Format("{0} - {1}", 0, Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth);
            textBoxThermo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth, Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth);
            textBoxHypo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth, Lake.Array[Lake.Array.GetUpperBound(0)].Depth);
            textBoxAllowableO2.Text = LakeClass.AllowableO2string(Lake);
            textBoxMaxTemp.Text = System.String.Format("{0}",LakeClass.MaxTemp(Lake));
            textBoxMinTemp.Text = System.String.Format("{0}",LakeClass.MinTemp(Lake));
            richTextBox1.Text = System.String.Format("{0}", LakeClass.ObservationOutputString(Lake));    
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ObservationStruct[] Observations = new ObservationStruct[]
            {
               
                new ObservationStruct(0,24,12),
                new ObservationStruct(0,24,12),
                new ObservationStruct(4,23,13),
                new ObservationStruct(6,20,10),
                new ObservationStruct(8,21,11),
                new ObservationStruct(10,17,9),
                new ObservationStruct(12,13,5),
                new ObservationStruct(14,13,4),
                new ObservationStruct(16,12,4),
                new ObservationStruct(18,12,4),
                new ObservationStruct(20,12,3),

                };
            LakeClass Lake = new LakeClass(Observations, "LakeHadley", 1.7, 24);
            textBoxName.Text = Lake.name;
            textBoxDepth.Text = System.String.Format("{0}", Lake.maxdepth);
            textBoxArea.Text = System.String.Format("{0}", Lake.area);
            textBoxEpi.Text = System.String.Format("{0} - {1}", 0, Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth);
            textBoxThermo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth, Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth);
            textBoxHypo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth, Lake.Array[Lake.Array.GetUpperBound(0)].Depth);
            textBoxAllowableO2.Text = LakeClass.AllowableO2string(Lake);
            textBoxMaxTemp.Text = System.String.Format("{0}", LakeClass.MaxTemp(Lake));
            textBoxMinTemp.Text = System.String.Format("{0}", LakeClass.MinTemp(Lake));
            richTextBox1.Text = System.String.Format("{0}", LakeClass.ObservationOutputString(Lake));    
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ObservationStruct[] Observations = new ObservationStruct[]
            {
               
                
                new ObservationStruct(0,23,8),
                new ObservationStruct(3,24,8),
                new ObservationStruct(5,22,7),
                new ObservationStruct(8,15,4),
                new ObservationStruct(10,16,3),
                new ObservationStruct(13,15,3),
                new ObservationStruct(15,14,2),
                
                };
            LakeClass Lake = new LakeClass(Observations, "Fish Lake", 1.1, 19);
            textBoxName.Text = Lake.name;
            textBoxDepth.Text = System.String.Format("{0}", Lake.maxdepth);
            textBoxArea.Text = System.String.Format("{0}", Lake.area);
            textBoxEpi.Text = System.String.Format("{0} - {1}", 0, Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth);
            textBoxThermo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth, Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth);
            textBoxHypo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth, Lake.Array[Lake.Array.GetUpperBound(0)].Depth);
            textBoxAllowableO2.Text = LakeClass.AllowableO2string(Lake);
            textBoxMaxTemp.Text = System.String.Format("{0}", LakeClass.MaxTemp(Lake));
            textBoxMinTemp.Text = System.String.Format("{0}", LakeClass.MinTemp(Lake));
            richTextBox1.Text = System.String.Format("{0}", LakeClass.ObservationOutputString(Lake));    
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ObservationStruct[] Observations = new ObservationStruct[]
            {
               
                
                new ObservationStruct(0,26,11),
                new ObservationStruct(1,25,11),
                new ObservationStruct(2,24,11),
                new ObservationStruct(4,24,10),
                new ObservationStruct(5,23,11),
                new ObservationStruct(8,20,10),
                new ObservationStruct(9,17,9),
                new ObservationStruct(11,17,9),
                new ObservationStruct(13,17,10),
                
                };
            LakeClass Lake = new LakeClass(Observations, "Ortonville Lake", 1.3, 15);
            textBoxName.Text = Lake.name;
            textBoxDepth.Text = System.String.Format("{0}", Lake.maxdepth);
            textBoxArea.Text = System.String.Format("{0}", Lake.area);
            textBoxEpi.Text = System.String.Format("{0} - {1}", 0, Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth);
            textBoxThermo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[0]].Depth, Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth);
            textBoxHypo.Text = System.String.Format("{0} - {1}", Lake.Array[LakeClass.privateThermocline(Lake)[1]].Depth, Lake.Array[Lake.Array.GetUpperBound(0)].Depth);
            textBoxAllowableO2.Text = LakeClass.AllowableO2string(Lake);
            textBoxMaxTemp.Text = System.String.Format("{0}", LakeClass.MaxTemp(Lake));
            textBoxMinTemp.Text = System.String.Format("{0}", LakeClass.MinTemp(Lake));
            richTextBox1.Text = System.String.Format("{0}", LakeClass.ObservationOutputString(Lake));    
            
        }

       
    }


    struct ObservationStruct
    {



        public double Depth;
        public double Temp;
        public double Olevels;

        public ObservationStruct(double Depth, double Temp, double Olevels)
        {
            this.Depth = Depth;
            this.Temp = Temp;
            this.Olevels = Olevels;
        }

        public ObservationStruct(ObservationStruct a)
        {
            Depth = a.Depth;
            Temp = a.Temp;
            Olevels = a.Olevels;
        }

        public override string ToString()
        {
            string Observationstructstring = System.String.Format("|{0,6}|{1,6}|{2,6}", Depth, Temp, Olevels);
            return Observationstructstring;
        }


    
    }
}
