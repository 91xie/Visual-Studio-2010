namespace CE1005_MyFirstWinApplication
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
            this.btnAButton = new System.Windows.Forms.Button();
            this.tbxStuff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAButton
            // 
            this.btnAButton.Location = new System.Drawing.Point(197, 12);
            this.btnAButton.Name = "btnAButton";
            this.btnAButton.Size = new System.Drawing.Size(75, 23);
            this.btnAButton.TabIndex = 0;
            this.btnAButton.Text = "Press Me";
            this.btnAButton.UseVisualStyleBackColor = true;
            // 
            // tbxStuff
            // 
            this.tbxStuff.Location = new System.Drawing.Point(69, 15);
            this.tbxStuff.Name = "tbxStuff";
            this.tbxStuff.Size = new System.Drawing.Size(100, 20);
            this.tbxStuff.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxStuff);
            this.Controls.Add(this.btnAButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAButton;
        private System.Windows.Forms.TextBox tbxStuff;
        private System.Windows.Forms.Label label1;
    }
}

