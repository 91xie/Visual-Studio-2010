namespace WaterHeatDraft1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1efficiency = new System.Windows.Forms.TextBox();
            this.textBox2energyperlitre = new System.Windows.Forms.TextBox();
            this.textBox3tempdiff = new System.Windows.Forms.TextBox();
            this.textBox4costperlitrefuel = new System.Windows.Forms.TextBox();
            this.textBox5flowrate = new System.Windows.Forms.TextBox();
            this.label1efficiency = new System.Windows.Forms.Label();
            this.label2energyperlitre = new System.Windows.Forms.Label();
            this.label3tempdiff = new System.Windows.Forms.Label();
            this.label4costperlitrefuel = new System.Windows.Forms.Label();
            this.label5flowrate = new System.Windows.Forms.Label();
            this.button1calculatecostpermin = new System.Windows.Forms.Button();
            this.label1costpermin = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1minperday = new System.Windows.Forms.TextBox();
            this.label1minperday = new System.Windows.Forms.Label();
            this.comboBox2flowrate = new System.Windows.Forms.ComboBox();
            this.textBox1kWh = new System.Windows.Forms.TextBox();
            this.label1kWh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1efficiency
            // 
            this.textBox1efficiency.Location = new System.Drawing.Point(24, 13);
            this.textBox1efficiency.Name = "textBox1efficiency";
            this.textBox1efficiency.Size = new System.Drawing.Size(100, 20);
            this.textBox1efficiency.TabIndex = 0;
            this.textBox1efficiency.Text = "0.7";
            // 
            // textBox2energyperlitre
            // 
            this.textBox2energyperlitre.Location = new System.Drawing.Point(24, 39);
            this.textBox2energyperlitre.Name = "textBox2energyperlitre";
            this.textBox2energyperlitre.Size = new System.Drawing.Size(100, 20);
            this.textBox2energyperlitre.TabIndex = 1;
            this.textBox2energyperlitre.Text = "35000000";
            // 
            // textBox3tempdiff
            // 
            this.textBox3tempdiff.Location = new System.Drawing.Point(24, 65);
            this.textBox3tempdiff.Name = "textBox3tempdiff";
            this.textBox3tempdiff.Size = new System.Drawing.Size(100, 20);
            this.textBox3tempdiff.TabIndex = 2;
            this.textBox3tempdiff.Text = "30";
            // 
            // textBox4costperlitrefuel
            // 
            this.textBox4costperlitrefuel.Location = new System.Drawing.Point(24, 91);
            this.textBox4costperlitrefuel.Name = "textBox4costperlitrefuel";
            this.textBox4costperlitrefuel.Size = new System.Drawing.Size(100, 20);
            this.textBox4costperlitrefuel.TabIndex = 3;
            this.textBox4costperlitrefuel.Text = "0.87";
            // 
            // textBox5flowrate
            // 
            this.textBox5flowrate.Location = new System.Drawing.Point(24, 117);
            this.textBox5flowrate.Name = "textBox5flowrate";
            this.textBox5flowrate.Size = new System.Drawing.Size(100, 20);
            this.textBox5flowrate.TabIndex = 4;
            this.textBox5flowrate.Text = "5";
            // 
            // label1efficiency
            // 
            this.label1efficiency.AutoSize = true;
            this.label1efficiency.Location = new System.Drawing.Point(130, 16);
            this.label1efficiency.Name = "label1efficiency";
            this.label1efficiency.Size = new System.Drawing.Size(110, 13);
            this.label1efficiency.TabIndex = 5;
            this.label1efficiency.Text = "efficiency of oil heater";
            // 
            // label2energyperlitre
            // 
            this.label2energyperlitre.AutoSize = true;
            this.label2energyperlitre.Location = new System.Drawing.Point(130, 42);
            this.label2energyperlitre.Name = "label2energyperlitre";
            this.label2energyperlitre.Size = new System.Drawing.Size(121, 13);
            this.label2energyperlitre.TabIndex = 6;
            this.label2energyperlitre.Text = "energyperlitre joules/litre";
            // 
            // label3tempdiff
            // 
            this.label3tempdiff.AutoSize = true;
            this.label3tempdiff.Location = new System.Drawing.Point(130, 68);
            this.label3tempdiff.Name = "label3tempdiff";
            this.label3tempdiff.Size = new System.Drawing.Size(44, 13);
            this.label3tempdiff.TabIndex = 7;
            this.label3tempdiff.Text = "tempdiff";
            // 
            // label4costperlitrefuel
            // 
            this.label4costperlitrefuel.AutoSize = true;
            this.label4costperlitrefuel.Location = new System.Drawing.Point(130, 94);
            this.label4costperlitrefuel.Name = "label4costperlitrefuel";
            this.label4costperlitrefuel.Size = new System.Drawing.Size(75, 13);
            this.label4costperlitrefuel.TabIndex = 8;
            this.label4costperlitrefuel.Text = "costperlitrefuel";
            // 
            // label5flowrate
            // 
            this.label5flowrate.AutoSize = true;
            this.label5flowrate.Location = new System.Drawing.Point(130, 120);
            this.label5flowrate.Name = "label5flowrate";
            this.label5flowrate.Size = new System.Drawing.Size(104, 13);
            this.label5flowrate.TabIndex = 9;
            this.label5flowrate.Text = "flowrate litres/minute";
            // 
            // button1calculatecostpermin
            // 
            this.button1calculatecostpermin.Location = new System.Drawing.Point(24, 196);
            this.button1calculatecostpermin.Name = "button1calculatecostpermin";
            this.button1calculatecostpermin.Size = new System.Drawing.Size(75, 23);
            this.button1calculatecostpermin.TabIndex = 10;
            this.button1calculatecostpermin.Text = "Calculate";
            this.button1calculatecostpermin.UseVisualStyleBackColor = true;
            // 
            // label1costpermin
            // 
            this.label1costpermin.AutoSize = true;
            this.label1costpermin.Location = new System.Drawing.Point(130, 201);
            this.label1costpermin.Name = "label1costpermin";
            this.label1costpermin.Size = new System.Drawing.Size(35, 13);
            this.label1costpermin.TabIndex = 11;
            this.label1costpermin.Text = "label1";
            this.label1costpermin.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kerosene",
            "Gas Oil",
            "Heavy Fuel Oil"});
            this.comboBox1.Location = new System.Drawing.Point(257, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Select Fuel";
            // 
            // textBox1minperday
            // 
            this.textBox1minperday.Location = new System.Drawing.Point(24, 143);
            this.textBox1minperday.Name = "textBox1minperday";
            this.textBox1minperday.Size = new System.Drawing.Size(32, 20);
            this.textBox1minperday.TabIndex = 13;
            this.textBox1minperday.Text = "0";
            // 
            // label1minperday
            // 
            this.label1minperday.AutoSize = true;
            this.label1minperday.Location = new System.Drawing.Point(130, 146);
            this.label1minperday.Name = "label1minperday";
            this.label1minperday.Size = new System.Drawing.Size(50, 13);
            this.label1minperday.TabIndex = 14;
            this.label1minperday.Text = "mins/day";
            // 
            // comboBox2flowrate
            // 
            this.comboBox2flowrate.FormattingEnabled = true;
            this.comboBox2flowrate.Items.AddRange(new object[] {
            "Shower (my house) 5l/min",
            "Shower (USA) 9.5l/min",
            "Sink 3.5l/min",
            "Dishwasher 11l/min"});
            this.comboBox2flowrate.Location = new System.Drawing.Point(257, 117);
            this.comboBox2flowrate.Name = "comboBox2flowrate";
            this.comboBox2flowrate.Size = new System.Drawing.Size(121, 21);
            this.comboBox2flowrate.TabIndex = 15;
            this.comboBox2flowrate.Text = "Select Flowrate";
            // 
            // textBox1kWh
            // 
            this.textBox1kWh.Location = new System.Drawing.Point(24, 170);
            this.textBox1kWh.Name = "textBox1kWh";
            this.textBox1kWh.Size = new System.Drawing.Size(100, 20);
            this.textBox1kWh.TabIndex = 16;
            this.textBox1kWh.Text = "0.141";
            // 
            // label1kWh
            // 
            this.label1kWh.AutoSize = true;
            this.label1kWh.Location = new System.Drawing.Point(130, 173);
            this.label1kWh.Name = "label1kWh";
            this.label1kWh.Size = new System.Drawing.Size(41, 13);
            this.label1kWh.TabIndex = 17;
            this.label1kWh.Text = "€/kWh";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 390);
            this.Controls.Add(this.label1kWh);
            this.Controls.Add(this.textBox1kWh);
            this.Controls.Add(this.comboBox2flowrate);
            this.Controls.Add(this.label1minperday);
            this.Controls.Add(this.textBox1minperday);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1costpermin);
            this.Controls.Add(this.button1calculatecostpermin);
            this.Controls.Add(this.label5flowrate);
            this.Controls.Add(this.label4costperlitrefuel);
            this.Controls.Add(this.label3tempdiff);
            this.Controls.Add(this.label2energyperlitre);
            this.Controls.Add(this.label1efficiency);
            this.Controls.Add(this.textBox5flowrate);
            this.Controls.Add(this.textBox4costperlitrefuel);
            this.Controls.Add(this.textBox3tempdiff);
            this.Controls.Add(this.textBox2energyperlitre);
            this.Controls.Add(this.textBox1efficiency);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1efficiency;
        private System.Windows.Forms.TextBox textBox2energyperlitre;
        private System.Windows.Forms.TextBox textBox3tempdiff;
        private System.Windows.Forms.TextBox textBox4costperlitrefuel;
        private System.Windows.Forms.TextBox textBox5flowrate;
        private System.Windows.Forms.Label label1efficiency;
        private System.Windows.Forms.Label label2energyperlitre;
        private System.Windows.Forms.Label label3tempdiff;
        private System.Windows.Forms.Label label4costperlitrefuel;
        private System.Windows.Forms.Label label5flowrate;
        private System.Windows.Forms.Button button1calculatecostpermin;
        private System.Windows.Forms.Label label1costpermin;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1minperday;
        private System.Windows.Forms.Label label1minperday;
        private System.Windows.Forms.ComboBox comboBox2flowrate;
        private System.Windows.Forms.TextBox textBox1kWh;
        private System.Windows.Forms.Label label1kWh;
    }
}

