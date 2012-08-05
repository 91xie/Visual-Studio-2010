using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankInfoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> ListofBankAccount = new List<BankAccount>();

            //Options 1. Create BankAccount 2. Access BankAccount 3. Exit

            Console.WriteLine("Welcome to Patrick's Bank Application");
            Console.WriteLine("What do you want to do?");
            Console.Write("1.Create BankAccount 2.Access BankAccount 3.Exit");

            int SelectorA;
            SelectorA = int.Parse(Console.ReadLine());

            while (SelectorA != 3)
            {
                if (SelectorA == 1)//createbankaccount
                {
                    Console.Clear();
                    string name, password;
                    Console.WriteLine("Create BankAccount...");
                    Console.Write("Name     :"); name = Console.ReadLine();
                    Console.Write("Password :"); password = Console.ReadLine();
                    ListofBankAccount.Add(new BankAccount(name, password, new List<Transaction>()));
                    Console.WriteLine();
                    Console.WriteLine("New Account Created...");
                    Console.WriteLine("Name:{0} Password:{1}", name, password);
                    Console.Write("Press Enter to Continue"); Console.ReadLine();

                   
                }//XXcreatebankaccount

                else if (SelectorA == 2 && ListofBankAccount.Count>0)//accessbankaccount.
                {
                    Console.Clear();
                    Console.WriteLine("Access BankAcount...");
                    string Name;
                    int CurrentAccoutIndex=0;
                    bool AccountFound = false;

                    while (AccountFound == false)
                    {
                        Console.Write("Name:");
                        Name = Console.ReadLine();
                        for (int i = 0; i < ListofBankAccount.Count; i++)
                        {
                            if (Name == ListofBankAccount[i].UserName)
                            {
                                CurrentAccoutIndex = i;
                                AccountFound = true;
                                break;
                            }
                        }
                        if (AccountFound == false) { Console.WriteLine("Account Not Found"); }

                    }


                    //you have the index... now password
                    string inputpassword = "";
                    
                    Console.Write("Password: ");
                    inputpassword = Console.ReadLine();

                    for(;;)
                    {
                        if (inputpassword != ListofBankAccount[CurrentAccoutIndex].Password)
                        {
                            Console.WriteLine("Username: {0}", ListofBankAccount[CurrentAccoutIndex].UserName);
                            Console.Write("Wrong Password, please try again...");
                            inputpassword = Console.ReadLine();
                        }
                        else if (inputpassword == ListofBankAccount[CurrentAccoutIndex].Password)
                        {
                            Console.Clear();
                            Console.WriteLine("Access Granted...");
                            Console.WriteLine(ListofBankAccount[CurrentAccoutIndex].ToString());
                            
                            ListofBankAccount[CurrentAccoutIndex].ToString();
                            break;
                        }
                    }

                    //what do you want to do?

                    int AccessedBankAccSelector=0;

                    Console.WriteLine("What do you want to do?");
                    Console.Write("1. Add Transaction 2. Logout...");
                    AccessedBankAccSelector = int.Parse(Console.ReadLine());
                    while (AccessedBankAccSelector != 2)
                    {
                        string date, info; double amount;
                        Console.WriteLine("Add Transaction...");
                        Console.Write("Date:   "); date = Console.ReadLine();
                        Console.Write("Info:   "); info = Console.ReadLine();
                        Console.Write("Amount: "); amount = double.Parse(Console.ReadLine());
                        ListofBankAccount[CurrentAccoutIndex].AddTransaction(date, info, amount);
                        Console.Clear();
                        Console.WriteLine(ListofBankAccount[CurrentAccoutIndex].ToString());
                        Console.Write("1. Add Transaction 2. Logout...");
                        AccessedBankAccSelector = int.Parse(Console.ReadLine());
                        if (AccessedBankAccSelector == 2)
                        { Console.WriteLine("You have logged out"); Console.Write("Press Enter to continue..."); Console.ReadLine(); }

                        
                    }



                }

                Console.Clear();
                Console.WriteLine("Welcome to Patrick's Bank Application");
                Console.WriteLine("What do you want to do?");
                Console.Write("1.Create BankAccount 2.Access BankAccount 3.Exit");
                SelectorA = int.Parse(Console.ReadLine());
                
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
            foreach (Transaction x in a) { s.Write("{0}\n",x.ToString()); }
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
                s.Write("|{0,12}|{1,40}|{2,10}|\n", label1, label2, label3);
                int dividerbarlength = 65;
                for (int i = 0; i < dividerbarlength; i++) { s.Write("-"); }
                s.Write("\n");
            }

            for (int i = 0; i < this.ListofTransactions.Count; i++)
            {
                s.Write("|{0,12}|{1,40}|{2,10:C}|\n",this.ListofTransactions[i].Date, this.ListofTransactions[i].Info,this.ListofTransactions[i].Amount);
            }
            return s.ToString();
        }

    }

}
