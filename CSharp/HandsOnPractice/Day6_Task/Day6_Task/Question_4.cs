using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Task
{
    class DailyLimitExceededException : Exception
    {
        int amount;
        public DailyLimitExceededException(string message, int Amount) : base(message)
        {
            this.amount = Amount;
        }

    }
    class BankAccount
    {
        int DailyLimit = 50000;
        int Balance;
        int Amount;

        public BankAccount(int amount, int balance)
        {
            Amount = amount;
            Balance = balance;
        }

        public void WithDrawal()
        {
            if (Amount > DailyLimit)
            {
                throw new DailyLimitExceededException($"You Can't withdraw the amount it exceeds dailylimit {DailyLimit}", Amount);
            }
            else if (Amount > Balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
            Balance -= Amount;
            Console.WriteLine($"Withdrawal Successfull Remaining Balance:{Balance}");
        }
    }
    class Question_4
    {
        public static void Main()
        {
            Console.Write("Enter Balance: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Amount to Withdraw: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            BankAccount b = new BankAccount(amount, balance);
            try
            {
                Console.WriteLine($"Trying to withdraw {amount}");
                b.WithDrawal();
            }
            catch (DailyLimitExceededException ex)
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
