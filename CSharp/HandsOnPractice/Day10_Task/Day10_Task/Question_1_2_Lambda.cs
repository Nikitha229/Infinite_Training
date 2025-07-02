using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_Task
{
    class Question_1_2_Lambda
    {
        public static void Main()
        {
            List<int> numbers = new List<int> {2,9,8,7,6,3,36,18};
            Predicate<int> d = num => num % 3 == 0;
            List<int> a = numbers.FindAll(d);
            Console.WriteLine("Numbers divisible by 3 using Lambda Expression:");
            foreach (int i in a)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

            Func<int, int, int> multiply = (x, y) => x * y;
            int num1, num2;
            Console.Write("Enter num1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter num2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            int product = multiply(num1, num2);
            Console.WriteLine("Product using Lambda Expression: " + product);

            Console.Read();
        }
    }
}
