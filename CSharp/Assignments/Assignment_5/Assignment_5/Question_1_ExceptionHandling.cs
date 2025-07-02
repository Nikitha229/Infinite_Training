using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class InsufficientBalanceException : Exception
    {
        int amount;
        public InsufficientBalanceException(string message, int Amount) : base(message)
        {
            this.amount = Amount;
        }

    }
    class BankAccount
    {
        int AccountNo;
        string Name;
        string TransactionType;
        int Balance;
        int Amount;

        public BankAccount(int accno,string name,string transactiontype,int amount, int balance)
        {
            AccountNo = accno;
            Name = name;
            TransactionType = transactiontype;
            Amount = amount;
            Balance = balance;
        }

        public void Deposit()
        {
            Balance += Amount;
        }
        public void WithDrawal()
        {
            if (Amount > Balance)
            {
                throw new InsufficientBalanceException($"You Can't withdraw the amount it exceeds your Balance: {Balance}", Amount);
            }
            Balance -= Amount;
            Console.WriteLine($"Withdrawal Successfull Remaining Balance:{Balance}");
        }

        public void Display()
        {
            Console.WriteLine("Account No: {0}", AccountNo);
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Balance: {0}", Balance);
        }
    }
    class Question_1_ExceptionHandling
    {
        public static void Main()
        {
            Console.Write("Enter Account Number: ");
            int accno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Transaction Type: ");
            string transactiontype = Console.ReadLine();
            Console.Write("Enter Balance: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            BankAccount b = new BankAccount(accno,name,transactiontype,amount, balance);
            try
            {
                Console.WriteLine("---------------Account Details Before Transaction----------------- ");
                b.Display();
                Console.WriteLine("------------------------------------------------------------------- ");
                if (transactiontype == "Withdrawal") {
                    Console.WriteLine($"Trying to withdraw {amount}");
                    b.WithDrawal();
                }
                else if (transactiontype == "Deposit") {
                    Console.WriteLine($"Trying to deposit {amount}");
                    b.Deposit();
                }
                Console.WriteLine("------------------------------------------------------------------- ");
                Console.WriteLine("---------------Account Details After Transaction-------------------- ");
                b.Display();

            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message} Attempted:{amount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Read();
        }
    }
}
