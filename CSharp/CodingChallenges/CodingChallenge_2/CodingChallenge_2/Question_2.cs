using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_2
{
    /*2. Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products*/

    class Product
    {
        public int ProductId;
        public string ProductName;
        public int Price;

        public Product(int productid,string productname,int price)
        {
            ProductId = productid;
            ProductName = productname;
            Price = price;
        }
    }
    class Question_2
    {
        public static void Main()
        {
            Console.WriteLine("Question_2_Output: ");
            List<Product> Products = new List<Product>();
            Console.WriteLine("Enter 10 Products Details: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter details for product {0}: ", i + 1) ;
                Console.Write("ProductId: ");
                int productId=Convert.ToInt32(Console.ReadLine());
                Console.Write("ProductName: ");
                string productName=Console.ReadLine();
                Console.Write("Price: ");
                int price=Convert.ToInt32(Console.ReadLine());
                Products.Add(new Product(productId, productName, price));
            }
            var SortedProducts = Products.OrderBy(p => p.Price).ToList();

            Console.WriteLine("Sorted Products : ");
            int j = 1;
            foreach(var product in SortedProducts)
            {
                Console.WriteLine($"{j}. ProductID:{product.ProductId} ProductName:{product.ProductName} Price:{product.Price}");
                j++;
            }
            Console.Read();
        }
    }
}
