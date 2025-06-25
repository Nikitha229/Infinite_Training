using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_1
{
    class Question_3
    {
        public static void Main()
        {
            Console.Write("Enter number of testcases: ");
            int t = Convert.ToInt32(Console.ReadLine());
            while(t>0)
            {
                Console.Write("Enter num1: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter num2: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter num3: ");
                int num3 = Convert.ToInt32(Console.ReadLine());
                int largestNum=0;
                if (num1 >= num2 && num1 >= num3)
                    largestNum = num1;
                else if (num2 >= num1 && num2 >= num3)
                    largestNum = num2;
                else if (num3 >= num1 && num3 >= num2)
                    largestNum = num3;
                Console.WriteLine($"Largest number of {num1},{num2},{num3} is {largestNum}");
                t--;
            }
            Console.Read();
        }
    }
}
