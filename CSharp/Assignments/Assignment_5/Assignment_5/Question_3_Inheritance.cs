using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class SaleDetails
    {
        public static int SalesNo;
        public static int ProductNo;
        public static int Price;
        public static DateTime DateOfSale;
        public static int Quantity;
        public static int TotalAmount;

       
        public SaleDetails(int salesno, int productno, int price, DateTime dos, int quantity)
        {
            SalesNo = salesno;
            ProductNo = productno;
            Price = price;
            DateOfSale = dos;
            Quantity = quantity;
        }
    }

    class Sales:SaleDetails
    {
        public void Sale(int price, int quantity)
        {
            TotalAmount = price * quantity;
        }
        public Sales(int salesno, int productno, int price, DateTime dos, int quantity) : base(salesno, productno, price, dos, quantity) { Sale(price, quantity); }
        public static void  display()
        {
            Console.WriteLine("SalesNo: {0}", SalesNo);
            Console.WriteLine("ProductNo: {0}", ProductNo);
            Console.WriteLine("Price of each Product: {0}", Price);
            Console.WriteLine("DateOfSale: {0}", DateOfSale);
            Console.WriteLine("Quantity: {0}", Quantity);
            Console.WriteLine("TotalAmount: {0}", TotalAmount);

        }

    }
        
    class Question_3_Inheritance
    {
        public static void Main()
        {
            Console.WriteLine("Enter Sales Details:");
            Console.Write("Enter SaleNo: ");
            int salno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter ProductNo: ");
            int productno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter DateOfSale: ");
            DateTime dos = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Sales s = new Sales(salno, productno, price, dos, qty);
            Console.WriteLine("----------Sales Details---------");
            Sales.display();
            Console.Read();
        }
    }
}
