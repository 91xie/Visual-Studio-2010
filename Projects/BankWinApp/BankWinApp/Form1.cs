using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BankWinApp
{
    public partial class Form1 : Form
    {
        static string SaveString;
        static List<BankAccount> ListofBankAccount = new List<BankAccount>();
        
        static int index = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1Create_Click(object sender, EventArgs e)
        {
            
            
                if ( textBox1Username.TextLength >0 && textBox1Password.TextLength > 0 &&  BankAccount.IsBankAccountPresent(textBox1Username.Text.ToString(), ListofBankAccount) ==  false)
                {
                    ListofBankAccount.Add(new BankAccount(textBox1Username.Text.ToString(), textBox1Password.Text.ToString(), new List<Transaction>()));
                    textBox1Username.BackColor = Color.LightGreen;
                    textBox1Password.BackColor = Color.LightGreen;
                    label1CreateLogStatus.Visible = true;
                    label1CreateLogStatus.Text = "Account Created";

                    //creates signs in and loads screen.
                }
                else
                {
                    textBox1Username.BackColor = Color.Red;
                    textBox1Password.BackColor = Color.Red;
                    label1CreateLogStatus.Visible = true;
                    label1CreateLogStatus.Text = "Name Already Used";
                }
                


            
        }

        private void button2SignIn_Click(object sender, EventArgs e)
        {

            if (textBox1Username.TextLength > 0 && textBox1Password.TextLength > 0 && BankAccount.IsBankAccountPresent(textBox1Username.Text.ToString(), ListofBankAccount) == true)
            {
                index = BankAccount.FindUserandReturnIndex(textBox1Username.Text.ToString(), ListofBankAccount);
                if (ListofBankAccount[index].Password == textBox1Password.Text.ToString())
                {
                    textBox1Username.BackColor = Color.LightGreen;
                    textBox1Password.BackColor = Color.LightGreen;
                    label1CreateLogStatus.Visible = true;
                    label1CreateLogStatus.Text = "Successfully Logged In";
                    //Load your accountinfo
                    textBox1AccountInfo.Visible = true;
                    textBox1AccountInfo.Text = ListofBankAccount[index].ToString();
                    //VISIBLE SETTER...
                    bool visiblesetter = true;
                    textBox1Date.Visible = visiblesetter;
                    textBox1Date.Text = DateTime.Today.Date.ToString().Substring(0,10);
                    textBox1Info.Visible = visiblesetter;
                    textBox1Amount.Visible = visiblesetter;
                    label1Date.Visible = visiblesetter;
                    label2Info.Visible = visiblesetter;
                    label2Amount.Visible = visiblesetter;
                    button1AddTransaction.Visible = visiblesetter;
                    button1SignOut.Visible = visiblesetter;
                    //XVISIBLE SETTER...


                }
                else
                {
                    textBox1Username.BackColor = Color.Red;
                    textBox1Password.BackColor = Color.Red;
                    label1CreateLogStatus.Visible = true;
                    label1CreateLogStatus.Text = "Password Incorrect";
                }


            }
            else
            {
                textBox1Username.BackColor = Color.Red;
                textBox1Password.BackColor = Color.Red;
                label1CreateLogStatus.Visible = true;
                label1CreateLogStatus.Text = "Account Not Found";
            }

        }

        private void button1AddTransaction_Click(object sender, EventArgs e)
        {
            string TransactionStatus = "";
            if (textBox1Date.TextLength > 0 && BankAccount.IsDigit(textBox1Amount.Text.ToString()))
            {
                ListofBankAccount[index].AddTransaction(textBox1Date.Text.ToString(), textBox1Info.Text.ToString(), double.Parse(textBox1Amount.Text.ToString()));
                textBox1AccountInfo.Text = ListofBankAccount[index].ToString();
                textBox1Date.Clear();
                textBox1Info.Clear();
                textBox1Amount.Clear();
                label1TransactionStatus.Visible = true;
                label1TransactionStatus.Text = "Transaction Accessfully Added";
                SaveString = BankAccount.SaveString2(ListofBankAccount);
                //every single time you add a transaction it updates and saves it.
            }
            else
            {
                if (textBox1Date.Text.Length == 0) { TransactionStatus += "Insert Date; "; }
                if (textBox1Info.Text.Length == 0) { TransactionStatus += "Insert Info; "; }
                if (BankAccount.IsDigit(textBox1Amount.Text.ToString()) == false) { TransactionStatus += "Insert Number for Amount; "; }
                label1TransactionStatus.Visible = true;
                label1TransactionStatus.Text = TransactionStatus;
            }

        }

        private void button1SignOut_Click(object sender, EventArgs e)
        {
            SaveString = BankAccount.SaveString2(ListofBankAccount);
            index = 0;
            //VISIBLE SETTER...2
            bool visiblesetter = false;
            textBox1Date.Visible = visiblesetter;
            textBox1Date.Text = DateTime.Today.Date.ToString().Substring(0, 10);
            textBox1Info.Visible = visiblesetter;
            textBox1Amount.Visible = visiblesetter;
            label1Date.Visible = visiblesetter;
            label2Info.Visible = visiblesetter;
            label2Amount.Visible = visiblesetter;
            button1AddTransaction.Visible = visiblesetter;
            button1SignOut.Visible = visiblesetter;
            textBox1AccountInfo.Visible = visiblesetter;
            label1TransactionStatus.Visible = visiblesetter;
            
            
            //XVISIBLE SETTER...2

            textBox1Username.Clear(); textBox1Username.BackColor = Color.White;
            textBox1Password.Clear(); textBox1Password.BackColor = Color.White;
            

        }

        private void button1SaveBank_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveString = BankAccount.SaveString2(ListofBankAccount);
                File.WriteAllText(saveFileDialog1.FileName, SaveString);
                label1LoadSaveStatus.Visible = true;
                label1LoadSaveStatus.Text = string.Format("{0} is saved", saveFileDialog1.FileName.ToString());

            }
        }

        private void button1LoadBank_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string loadedstring;
                loadedstring = File.ReadAllText(openFileDialog1.FileName);
                ListofBankAccount = BankAccount.SaveStringtoListofBankAccount(loadedstring);
                label1LoadSaveStatus.Visible = true;
                label1LoadSaveStatus.Text = string.Format("{0} is loaded", openFileDialog1.FileName);
                label1NoofBankAccount.Visible = true;
                string NoofBankAccount = "";
                NoofBankAccount += string.Format("{0} Bank Account(s)\n", ListofBankAccount.Count);
                foreach (BankAccount x in ListofBankAccount)
                {
                    NoofBankAccount += string.Format("{0}|\n",x.UserName.ToString());
                }
                label1NoofBankAccount.Text = NoofBankAccount;

            }
        }

        
        
        

        


    }

    struct Transaction
    {
        public string Date, Info;
        public double Amount;



        public Transaction(string Date, string Info, double amount)
        { this.Date = Date; this.Info = Info; this.Amount = amount; }

        public override string ToString()
        {
            return string.Format("Date: {0} Info:{1} Amount:{2}", Date, Info, Amount);
        }

        public string ListToString(List<Transaction> a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            foreach (Transaction x in a) { s.Write("{0}\n", x.ToString()); }
            return s.ToString();
        }
    }

    class BankAccount
    {
        public string UserName { get { return _UserName; } } private string _UserName;
        public string Password { get { return _Password; } } private string _Password;
        public string DateCreated { get { return _DateCreated; } }private string _DateCreated;
        public double Amount { get { return _Amount; } } private double _Amount;
        List<Transaction> ListofTransactions;

        //constructor -> create bank account

        public BankAccount()
        {
            this._UserName = ""; this.ListofTransactions = new List<Transaction>(); this._Amount = 0; this._Password = ""; _DateCreated = "dd/mm/yyyy";
        }

        public BankAccount(string Name, string Password, List<Transaction> ListofTransactions)
        {
            this._UserName = Name; this.ListofTransactions = ListofTransactions; this.AmountCal(); this._Password = Password; _DateCreated = DateTime.Today.Date.ToString().Substring(0,10);
        }

        public static BankAccount SaveStringToBankAccount(string a)
        {
            char[] seperators = new char[] { '\n' };
            string[] segements = a.Split(seperators);
            //segements brokenup into lines.
            string Username = "";
            string Password = "";
            List<Transaction> ListofTransaction = new List<Transaction>();
            int imark = 11;
            string Date = "", Info = ""; double Amount = 0;
            foreach (string line in segements)
            {
                if (line.Length < 11) { break; }

                string firsthalf = line.Substring(0, imark), secondhalf = line.Substring(imark);

                if (firsthalf == "<Username >")
                { Username = secondhalf; }
                else if (firsthalf == "<Password >")
                { Password = secondhalf; }
                else if (firsthalf == "<Date     >")
                { Date = secondhalf; }
                else if (firsthalf == "<Info     >")
                { Info = secondhalf; }
                else if (firsthalf == "<Amount   >")
                { Amount = double.Parse(secondhalf); ListofTransaction.Add(new Transaction(Date, Info, Amount)); }




            }
            return new BankAccount(Username, Password, ListofTransaction);
        }

        public static List<BankAccount> SaveStringtoListofBankAccount(string a)
        {
            List<BankAccount> NewList = new List<BankAccount>();
            char[] seperators = new char[] { '\t' };
            string[] segments = a.Split(seperators);
            foreach (string x in segments)
            {
                NewList.Add(SaveStringToBankAccount(x));
            }
            return NewList;
        }

        public static bool IsDigit(string a)
        {
            
            if (a.Length == 0)
            {
                return false;
            }

            foreach (char x in a)
            {
                if (char.IsDigit(x) == false&& x != '.') { return false; }
            }

            return true;
        }


        public void AmountCal()
        {
            if (this.ListofTransactions.Count > 0)
            {
                this._Amount = 0;
                for (int i = 0; i < this.ListofTransactions.Count; i++)
                {
                    this._Amount += this.ListofTransactions[i].Amount;
                }
            }
        }

        //Find a name given a list of BankTransactions


        public static bool IsBankAccountPresent(string name, List<BankAccount> a)
        {
            foreach (BankAccount x in a)
            {
                if (x._UserName == name)
                {
                    return true;
                }
            }
            return false;
        }
        //if it is true. pass use another method to find it

        public static int FindUserandReturnIndex(string name, List<BankAccount> a)
        {
            int index = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i]._UserName == name) { index = i; }
            }
            return index;
        }

        //Add Transaction

        public void AddTransaction(string Date, string Info, double Amount)
        {
            this.ListofTransactions.Add(new Transaction(Date, Info, Amount));
            this.AmountCal();
        }

        public override string ToString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            s.WriteLine("UserName:{0}\tAmount:{1:C}\tDate Created:{2}", UserName, Amount,DateCreated);

            string label1 = "Date", label2 = "Info", label3 = "Amount";

            if (this.ListofTransactions.Count > 0)
            {
                s.WriteLine("|{0,12}|{1,40}|{2,10}", label1, label2, label3);
                /*int dividerbarlength = 65;
                for (int i = 0; i < dividerbarlength; i++) { s.Write("-"); }
                s.Write("\n");*/
            }

            for (int i = 0; i < this.ListofTransactions.Count; i++)
            {
                s.WriteLine("|{0,12}|{1,40}|{2,10:C}", this.ListofTransactions[i].Date, this.ListofTransactions[i].Info, this.ListofTransactions[i].Amount);
            }
            s.WriteLine("Total: {0,58:C}", Amount);
            return s.ToString();
        }

        public static List<BankAccount> TestCreateBankAccounts(int j)
        {
            List<BankAccount> ListofBankAccounts = new List<BankAccount>();
            for (int i = 0; i < j; i++)
            {
                List<Transaction> AListofTransactions = new List<Transaction>();
                for (int k = 0; k < j; k++)
                {
                    string Date = string.Format("{0}/01/01", k);
                    string Info = string.Format("SomeInfo SomeInfo SomeInfo {0}", k);
                    double Amount = k * 100;
                    AListofTransactions.Add(new Transaction(Date, Info, Amount));
                }

                string aName = String.Format("Person {0}", i);
                string aPassword = String.Format("Password {0}", i);
                ListofBankAccounts.Add(new BankAccount(aName, aPassword, AListofTransactions));
            }

            return ListofBankAccounts;
        }

        public string SaveString()
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            //use mark up like html and have it a specific size.
            //<UserName>....\n <Date>...\n <Info>...\n <Amount>....\n add all to one string.
            s.Write("<Username >{0}\n", _UserName);
            s.Write("<Password >{0}\n", _Password);
            foreach (Transaction atransaction in ListofTransactions)
            {
                s.Write("<Date     >{0}\n<Info     >{1}\n<Amount   >{2}\n", atransaction.Date, atransaction.Info, atransaction.Amount);
            }
            return s.ToString();
        }

        public static string SaveString2(List<BankAccount> a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            foreach (BankAccount x in a)
            {
                s.Write("{0}\t", x.SaveString());
            }
            return s.ToString();
        }

    }

}
