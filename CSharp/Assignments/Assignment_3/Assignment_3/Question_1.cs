using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Account
    {
        int AccountNo;
        string CustomerName;
        string AccountType;
        string TransactionType;
        int Amount;
        int Balance;

        public Account(int accno,string name,string acctype,int balance)
        {
            AccountNo = accno;
            CustomerName = name;
            AccountType = acctype;
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

            if(TransactionType=="Deposit")
            {
                Credit(Amount);
            }
            else if(TransactionType=="Withdrawal")
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
    class Question_1
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

            Account a = new Account(accno, name, acctype,balance);
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
