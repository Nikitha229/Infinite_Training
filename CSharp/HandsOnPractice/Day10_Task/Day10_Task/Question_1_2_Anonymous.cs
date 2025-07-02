using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_Task
{
    class Question_1_2_Anonymous
    {
        static void Main(string[] args)
        {
            List<int> nums= new List<int> {2,3,5,7,9,12,4,30};
            Predicate<int> d = delegate (int num)
            {
                return num % 3 == 0;
            };
            List<int>a= nums.FindAll(d);
            Console.WriteLine("Numbers divisible by 3 using Anonymous Method:");
            foreach (int i in a)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

            Func<int, int, int> multiply = delegate (int x, int y)
            {
                return x * y;
            };
            int num1, num2;
            Console.Write("Enter num1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter num2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int product = multiply(num1,num2);
            Console.WriteLine("Product using Anonymous Method: " + product);

            Console.Read();

        }
    }
}
