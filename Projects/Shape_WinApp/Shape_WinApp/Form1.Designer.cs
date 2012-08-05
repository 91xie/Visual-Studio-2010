namespace Shape_WinApp
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
            this.CreateCircleButton = new System.Windows.Forms.Button();
            this.CreateRectangleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateCircleButton
            // 
            this.CreateCircleButton.Location = new System.Drawing.Point(45, 13);
            this.CreateCircleButton.Name = "CreateCircleButton";
            this.CreateCircleButton.Size = new System.Drawing.Size(75, 23);
            this.CreateCircleButton.TabIndex = 0;
            this.CreateCircleButton.Text = "CreateCircle";
            this.CreateCircleButton.UseVisualStyleBackColor = true;
            // 
            // CreateRectangleButton
            // 
            this.CreateRectangleButton.Location = new System.Drawing.Point(45, 42);
            this.CreateRectangleButton.Name = "CreateRectangleButton";
            this.CreateRectangleButton.Size = new System.Drawing.Size(101, 23);
            this.CreateRectangleButton.TabIndex = 1;
            this.CreateRectangleButton.Text = "CreateRectangle";
            this.CreateRectangleButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateRectangleButton);
            this.Controls.Add(this.CreateCircleButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateCircleButton;
        private System.Windows.Forms.Button CreateRectangleButton;
        private System.Windows.Forms.Label label1;
    }
}

