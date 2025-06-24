using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class SaleDetails
    {
        static int SalesNo;
        static int ProductNo;
        static int Price;
        static DateTime DateOfSale;
        static int Quantity;
        static int TotalAmount;

        public void Sale(int price,int quantity)
        {
            TotalAmount = price * quantity;
        }
        public SaleDetails(int salesno,int productno,int price,DateTime dos,int quantity)
        {
            SalesNo = salesno;
            ProductNo = productno;
            Price = price;
            DateOfSale = dos;
            Quantity = quantity;
            Sale(Price,Quantity);
        }

        public static void display()
        {
            Console.WriteLine("SalesNo: {0}", SalesNo);
            Console.WriteLine("ProductNo: {0}", ProductNo);
            Console.WriteLine("Price of each Product: {0}", Price);
            Console.WriteLine("DateOfSale: {0}", DateOfSale);
            Console.WriteLine("Quantity: {0}", Quantity);
            Console.WriteLine("TotalAmount: {0}", TotalAmount);

        }
    }
    class Question_3
    {
        public static void Main()
        {
            Console.WriteLine("Enter Sales Details:");
            Console.Write("Enter SaleNo: ");
            int salno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ProductNo: ");
            int productno=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DateOfSale: ");
            DateTime dos = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            SaleDetails s = new SaleDetails(salno, productno, price, dos, qty);
            Console.WriteLine("----------Sales Details---------");
            SaleDetails. display();
            Console.Read();
        }
    }
}
