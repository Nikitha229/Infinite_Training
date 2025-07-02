using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//In Assignment 3 I done these questions without using inheritance concept , So I did them again using Inheritance.

namespace Assignment_5
{
    class Account
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public string TransactionType;
        public int Amount;
        public int Balance;

        public Account(int accno, string name, string acctype, int balance)
        {
            AccountNo = accno;
            CustomerName = name;
            AccountType = acctype;
            Balance = balance;
        }

       
    }
    class Transaction : Account
    {
        public Transaction(int accno,string name,string acctype,int balance) : base(accno, name, acctype, balance)
        {
            Balance = balance;
        }
        public void Credit(int amount)
        {
            Balance += amount;
        }

        public void Debit(int amount)
        {
            Balance -= amount;
        }
        public void Query()
        {
            Console.Write("Enter Transaction Type: ");
            TransactionType = Console.ReadLine();
            Console.Write("Enter Amount:");
            Amount = Convert.ToInt32(Console.ReadLine());

            if (TransactionType == "Deposit")
            {
                Credit(Amount);
            }
            else if (TransactionType == "Withdrawal")
            {
                Debit(Amount);
            }

        }


        public void Display()
        {
            Console.WriteLine("Account No: {0}", AccountNo);
            Console.WriteLine("Customer Name: {0}", CustomerName);
            Console.WriteLine("Account Type: {0}", AccountType);
            Console.WriteLine("Transaction Type: {0}", TransactionType);
            Console.WriteLine("Amount: {0}", Amount);
            Console.WriteLine("Balance: {0}", Balance);
        }

    }
    class Question_1_Inheritance
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Account Details");
            Console.Write("Enter Account Number: ");
            int accno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter CustomerName: ");
            string name = Console.ReadLine();
            Console.Write("Enter Account Type: ");
            string acctype = Console.ReadLine();
            Console.Write("Enter Balance: ");
            int balance = Convert.ToInt32(Console.ReadLine());

            Transaction a = new Transaction(accno, name, acctype, balance);
            Console.WriteLine("--------------Account Details Before Transaction---------");
            a.Display();
            Console.WriteLine("----------------------------------------------------------");
            a.Query();
            Console.WriteLine("---------------Account Details After Transaction-----------");
            a.Display();
            Console.Read();
        }
    }
    
}
