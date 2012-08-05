using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringToBank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Transaction> AListofTransactions = new List<Transaction>();
            AListofTransactions.Add(new Transaction("12/12/12", "SomeInfo", 500));
            AListofTransactions.Add(new Transaction("13/12/12", "SomeInfo2", 600));
            AListofTransactions.Add(new Transaction("14/12/12", "SomeInfo3", 700));
            AListofTransactions.Add(new Transaction("15/12/12", "SomeInfo4", 800));
            AListofTransactions.Add(new Transaction("16/12/12", "SomeInfo5", 900));
            BankAccount ABankAccount = new BankAccount("Patrick Xie", "12345", AListofTransactions);

            Console.WriteLine(ABankAccount.ToString());
            string rawdata2 = ABankAccount.SaveString();
            Console.WriteLine(rawdata2);
            BankAccount SavedBankAccount = BankAccount.SaveStringToBankAccount(rawdata2);
            Console.WriteLine(SavedBankAccount);

            */
            
            

            List<BankAccount> TestBank = BankAccount.TestCreateBankAccounts(10);
            string SavedString = BankAccount.SaveString2(TestBank);
            Console.WriteLine(SavedString);
            Console.ReadLine();

            List<BankAccount> CopyTestBank = BankAccount.SaveStringtoListofBankAccount(SavedString);
            Console.WriteLine(BankAccount.SaveString2(CopyTestBank));





            Console.ReadLine();
        }
        /*
        static BankAccount StringToBankAccount(string a)
        {
            char[] seperators = new char[] { '|', '\t', 'n', ' ', ':' ,'?',',' };
            string[] segements1 = a.Split(seperators);


        }
        */

        
        static string TestSting(string a)
        {
            System.IO.StringWriter s = new System.IO.StringWriter();
            char[] seperators = new char[] {  '\t', '\n', ' ', ':', '?' };//'|'
            string[] segements1 = a.Split(seperators);
            foreach (string asegement in segements1)
            { s.WriteLine(asegement); }

            List<string> segements2 = new List<string>();
            foreach (string asegement in segements1)
            { if (asegement != "") { segements2.Add(asegement); } }

            foreach (string asegement in segements2)
            { s.WriteLine(asegement); }

            return s.ToString();

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
        public double Amount { get { return _Amount; } } private double _Amount;
        List<Transaction> ListofTransactions;

        //constructor -> create bank account
        public BankAccount(string Name, string Password, List<Transaction> ListofTransactions)
        {
            this._UserName = Name; this.ListofTransactions = ListofTransactions; this.AmountCal(); this._Password = Password;
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
            s.Write("UserName:{0}\tAmount:{1:C}\n", UserName, Amount);

            string label1 = "Date", label2 = "Info", label3 = "Amount";

            if (this.ListofTransactions.Count > 0)
            {
                s.Write("|{0,12}|{1,40}|{2,10}\n", label1, label2, label3);
                /*int dividerbarlength = 65;
                for (int i = 0; i < dividerbarlength; i++) { s.Write("-"); }
                s.Write("\n");*/
            }

            for (int i = 0; i < this.ListofTransactions.Count; i++)
            {
                s.Write("|{0,12}|{1,40}|{2,10:C}\n", this.ListofTransactions[i].Date, this.ListofTransactions[i].Info, this.ListofTransactions[i].Amount);
            }
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
                s.Write("<Date     >{0}\n<Info     >{1}\n<Amount   >{2}\n",atransaction.Date,atransaction.Info,atransaction.Amount);
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
