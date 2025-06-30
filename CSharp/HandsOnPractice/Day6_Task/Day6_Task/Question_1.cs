using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Task
{
    class Question_1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Price of each item: ");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Qunatity: ");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            int TotalPrice = Quantity * Price;
            float Discount = TotalPrice * 0.1f;
            Console.WriteLine("Price before Discount: {0}", TotalPrice);
            Console.WriteLine("Price after Discount: {0}", TotalPrice - Discount);
            Console.Read();
        }
    }
}
