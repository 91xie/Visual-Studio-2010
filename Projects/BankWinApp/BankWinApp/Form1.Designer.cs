namespace BankWinApp
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
            this.button1Create = new System.Windows.Forms.Button();
            this.button2SignIn = new System.Windows.Forms.Button();
            this.label1Username = new System.Windows.Forms.Label();
            this.label1Password = new System.Windows.Forms.Label();
            this.textBox1Username = new System.Windows.Forms.TextBox();
            this.textBox1Password = new System.Windows.Forms.TextBox();
            this.label1CreateLogStatus = new System.Windows.Forms.Label();
            this.label1AccountInfo = new System.Windows.Forms.Label();
            this.textBox1AccountInfo = new System.Windows.Forms.TextBox();
            this.textBox1Date = new System.Windows.Forms.TextBox();
            this.textBox1Info = new System.Windows.Forms.TextBox();
            this.textBox1Amount = new System.Windows.Forms.TextBox();
            this.label1Date = new System.Windows.Forms.Label();
            this.label2Info = new System.Windows.Forms.Label();
            this.label2Amount = new System.Windows.Forms.Label();
            this.button1AddTransaction = new System.Windows.Forms.Button();
            this.label1TransactionStatus = new System.Windows.Forms.Label();
            this.button1SignOut = new System.Windows.Forms.Button();
            this.button1LoadBank = new System.Windows.Forms.Button();
            this.button1SaveBank = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1LoadSaveStatus = new System.Windows.Forms.Label();
            this.label1NoofBankAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1Create
            // 
            this.button1Create.Location = new System.Drawing.Point(102, 77);
            this.button1Create.Name = "button1Create";
            this.button1Create.Size = new System.Drawing.Size(89, 23);
            this.button1Create.TabIndex = 0;
            this.button1Create.Text = "Create Account";
            this.button1Create.UseVisualStyleBackColor = true;
            this.button1Create.Click += new System.EventHandler(this.button1Create_Click);
            // 
            // button2SignIn
            // 
            this.button2SignIn.Location = new System.Drawing.Point(197, 77);
            this.button2SignIn.Name = "button2SignIn";
            this.button2SignIn.Size = new System.Drawing.Size(75, 23);
            this.button2SignIn.TabIndex = 1;
            this.button2SignIn.Text = "Sign In";
            this.button2SignIn.UseVisualStyleBackColor = true;
            this.button2SignIn.Click += new System.EventHandler(this.button2SignIn_Click);
            // 
            // label1Username
            // 
            this.label1Username.AutoSize = true;
            this.label1Username.Location = new System.Drawing.Point(15, 15);
            this.label1Username.Name = "label1Username";
            this.label1Username.Size = new System.Drawing.Size(55, 13);
            this.label1Username.TabIndex = 2;
            this.label1Username.Text = "Username";
            // 
            // label1Password
            // 
            this.label1Password.AutoSize = true;
            this.label1Password.Location = new System.Drawing.Point(15, 41);
            this.label1Password.Name = "label1Password";
            this.label1Password.Size = new System.Drawing.Size(53, 13);
            this.label1Password.TabIndex = 3;
            this.label1Password.Text = "Password";
            // 
            // textBox1Username
            // 
            this.textBox1Username.Location = new System.Drawing.Point(74, 12);
            this.textBox1Username.Name = "textBox1Username";
            this.textBox1Username.Size = new System.Drawing.Size(100, 20);
            this.textBox1Username.TabIndex = 4;
            // 
            // textBox1Password
            // 
            this.textBox1Password.Location = new System.Drawing.Point(74, 38);
            this.textBox1Password.Name = "textBox1Password";
            this.textBox1Password.PasswordChar = '*';
            this.textBox1Password.Size = new System.Drawing.Size(100, 20);
            this.textBox1Password.TabIndex = 5;
            // 
            // label1CreateLogStatus
            // 
            this.label1CreateLogStatus.AutoSize = true;
            this.label1CreateLogStatus.Location = new System.Drawing.Point(71, 61);
            this.label1CreateLogStatus.Name = "label1CreateLogStatus";
            this.label1CreateLogStatus.Size = new System.Drawing.Size(35, 13);
            this.label1CreateLogStatus.TabIndex = 6;
            this.label1CreateLogStatus.Text = "label1";
            this.label1CreateLogStatus.Visible = false;
            // 
            // label1AccountInfo
            // 
            this.label1AccountInfo.AutoSize = true;
            this.label1AccountInfo.Location = new System.Drawing.Point(13, 109);
            this.label1AccountInfo.Name = "label1AccountInfo";
            this.label1AccountInfo.Size = new System.Drawing.Size(0, 13);
            this.label1AccountInfo.TabIndex = 7;
            // 
            // textBox1AccountInfo
            // 
            this.textBox1AccountInfo.Font = new System.Drawing.Font("Courier New", 8F);
            this.textBox1AccountInfo.Location = new System.Drawing.Point(12, 106);
            this.textBox1AccountInfo.Multiline = true;
            this.textBox1AccountInfo.Name = "textBox1AccountInfo";
            this.textBox1AccountInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1AccountInfo.Size = new System.Drawing.Size(708, 179);
            this.textBox1AccountInfo.TabIndex = 8;
            this.textBox1AccountInfo.Visible = false;
            // 
            // textBox1Date
            // 
            this.textBox1Date.Location = new System.Drawing.Point(99, 291);
            this.textBox1Date.Name = "textBox1Date";
            this.textBox1Date.Size = new System.Drawing.Size(173, 20);
            this.textBox1Date.TabIndex = 9;
            this.textBox1Date.Visible = false;
            // 
            // textBox1Info
            // 
            this.textBox1Info.Location = new System.Drawing.Point(99, 317);
            this.textBox1Info.Name = "textBox1Info";
            this.textBox1Info.Size = new System.Drawing.Size(173, 20);
            this.textBox1Info.TabIndex = 10;
            this.textBox1Info.Visible = false;
            // 
            // textBox1Amount
            // 
            this.textBox1Amount.Location = new System.Drawing.Point(99, 343);
            this.textBox1Amount.Name = "textBox1Amount";
            this.textBox1Amount.Size = new System.Drawing.Size(173, 20);
            this.textBox1Amount.TabIndex = 11;
            this.textBox1Amount.Visible = false;
            // 
            // label1Date
            // 
            this.label1Date.AutoSize = true;
            this.label1Date.Location = new System.Drawing.Point(15, 294);
            this.label1Date.Name = "label1Date";
            this.label1Date.Size = new System.Drawing.Size(81, 13);
            this.label1Date.TabIndex = 12;
            this.label1Date.Text = "Date dd/mm/yy";
            this.label1Date.Visible = false;
            // 
            // label2Info
            // 
            this.label2Info.AutoSize = true;
            this.label2Info.Location = new System.Drawing.Point(15, 320);
            this.label2Info.Name = "label2Info";
            this.label2Info.Size = new System.Drawing.Size(25, 13);
            this.label2Info.TabIndex = 13;
            this.label2Info.Text = "Info";
            this.label2Info.Visible = false;
            // 
            // label2Amount
            // 
            this.label2Amount.AutoSize = true;
            this.label2Amount.Location = new System.Drawing.Point(15, 346);
            this.label2Amount.Name = "label2Amount";
            this.label2Amount.Size = new System.Drawing.Size(43, 13);
            this.label2Amount.TabIndex = 14;
            this.label2Amount.Text = "Amount";
            this.label2Amount.Visible = false;
            // 
            // button1AddTransaction
            // 
            this.button1AddTransaction.Location = new System.Drawing.Point(119, 382);
            this.button1AddTransaction.Name = "button1AddTransaction";
            this.button1AddTransaction.Size = new System.Drawing.Size(97, 23);
            this.button1AddTransaction.TabIndex = 15;
            this.button1AddTransaction.Text = "Add Transaction";
            this.button1AddTransaction.UseVisualStyleBackColor = true;
            this.button1AddTransaction.Visible = false;
            this.button1AddTransaction.Click += new System.EventHandler(this.button1AddTransaction_Click);
            // 
            // label1TransactionStatus
            // 
            this.label1TransactionStatus.AutoSize = true;
            this.label1TransactionStatus.Location = new System.Drawing.Point(99, 366);
            this.label1TransactionStatus.Name = "label1TransactionStatus";
            this.label1TransactionStatus.Size = new System.Drawing.Size(35, 13);
            this.label1TransactionStatus.TabIndex = 16;
            this.label1TransactionStatus.Text = "label1";
            this.label1TransactionStatus.Visible = false;
            // 
            // button1SignOut
            // 
            this.button1SignOut.Location = new System.Drawing.Point(278, 77);
            this.button1SignOut.Name = "button1SignOut";
            this.button1SignOut.Size = new System.Drawing.Size(75, 23);
            this.button1SignOut.TabIndex = 17;
            this.button1SignOut.Text = "Sign Out";
            this.button1SignOut.UseVisualStyleBackColor = true;
            this.button1SignOut.Visible = false;
            this.button1SignOut.Click += new System.EventHandler(this.button1SignOut_Click);
            // 
            // button1LoadBank
            // 
            this.button1LoadBank.Location = new System.Drawing.Point(422, 15);
            this.button1LoadBank.Name = "button1LoadBank";
            this.button1LoadBank.Size = new System.Drawing.Size(75, 23);
            this.button1LoadBank.TabIndex = 18;
            this.button1LoadBank.Text = "Load Bank";
            this.button1LoadBank.UseVisualStyleBackColor = true;
            this.button1LoadBank.Click += new System.EventHandler(this.button1LoadBank_Click);
            // 
            // button1SaveBank
            // 
            this.button1SaveBank.Location = new System.Drawing.Point(503, 15);
            this.button1SaveBank.Name = "button1SaveBank";
            this.button1SaveBank.Size = new System.Drawing.Size(75, 23);
            this.button1SaveBank.TabIndex = 19;
            this.button1SaveBank.Text = "Save Bank";
            this.button1SaveBank.UseVisualStyleBackColor = true;
            this.button1SaveBank.Click += new System.EventHandler(this.button1SaveBank_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1LoadSaveStatus
            // 
            this.label1LoadSaveStatus.AutoSize = true;
            this.label1LoadSaveStatus.Location = new System.Drawing.Point(422, 45);
            this.label1LoadSaveStatus.Name = "label1LoadSaveStatus";
            this.label1LoadSaveStatus.Size = new System.Drawing.Size(35, 13);
            this.label1LoadSaveStatus.TabIndex = 20;
            this.label1LoadSaveStatus.Text = "label1";
            this.label1LoadSaveStatus.Visible = false;
            // 
            // label1NoofBankAccount
            // 
            this.label1NoofBankAccount.AutoSize = true;
            this.label1NoofBankAccount.Location = new System.Drawing.Point(425, 62);
            this.label1NoofBankAccount.Name = "label1NoofBankAccount";
            this.label1NoofBankAccount.Size = new System.Drawing.Size(35, 13);
            this.label1NoofBankAccount.TabIndex = 21;
            this.label1NoofBankAccount.Text = "label1";
            this.label1NoofBankAccount.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 417);
            this.Controls.Add(this.label1NoofBankAccount);
            this.Controls.Add(this.label1LoadSaveStatus);
            this.Controls.Add(this.button1SaveBank);
            this.Controls.Add(this.button1LoadBank);
            this.Controls.Add(this.button1SignOut);
            this.Controls.Add(this.label1TransactionStatus);
            this.Controls.Add(this.button1AddTransaction);
            this.Controls.Add(this.label2Amount);
            this.Controls.Add(this.label2Info);
            this.Controls.Add(this.label1Date);
            this.Controls.Add(this.textBox1Amount);
            this.Controls.Add(this.textBox1Info);
            this.Controls.Add(this.textBox1Date);
            this.Controls.Add(this.textBox1AccountInfo);
            this.Controls.Add(this.label1AccountInfo);
            this.Controls.Add(this.label1CreateLogStatus);
            this.Controls.Add(this.textBox1Password);
            this.Controls.Add(this.textBox1Username);
            this.Controls.Add(this.label1Password);
            this.Controls.Add(this.label1Username);
            this.Controls.Add(this.button2SignIn);
            this.Controls.Add(this.button1Create);
            this.Name = "Form1";
            this.Text = "Bank App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1Create;
        private System.Windows.Forms.Button button2SignIn;
        private System.Windows.Forms.Label label1Username;
        private System.Windows.Forms.Label label1Password;
        private System.Windows.Forms.TextBox textBox1Username;
        private System.Windows.Forms.TextBox textBox1Password;
        private System.Windows.Forms.Label label1CreateLogStatus;
        private System.Windows.Forms.Label label1AccountInfo;
        private System.Windows.Forms.TextBox textBox1AccountInfo;
        private System.Windows.Forms.TextBox textBox1Date;
        private System.Windows.Forms.TextBox textBox1Info;
        private System.Windows.Forms.TextBox textBox1Amount;
        private System.Windows.Forms.Label label1Date;
        private System.Windows.Forms.Label label2Info;
        private System.Windows.Forms.Label label2Amount;
        private System.Windows.Forms.Button button1AddTransaction;
        private System.Windows.Forms.Label label1TransactionStatus;
        private System.Windows.Forms.Button button1SignOut;
        private System.Windows.Forms.Button button1LoadBank;
        private System.Windows.Forms.Button button1SaveBank;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1LoadSaveStatus;
        private System.Windows.Forms.Label label1NoofBankAccount;
    }
}

