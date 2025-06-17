using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question-1 Output:");
            Console.WriteLine();
            Question_1();
            Console.WriteLine("Question-2 Output:");
            Console.WriteLine();
            Question_2();
            Console.WriteLine("Question-3 Output:");
            Console.WriteLine();
            Question_3();
            Console.WriteLine("Question-4 Output:");
            Console.WriteLine();
            Question_4();
            Console.WriteLine("Question-5 Output:");
            Console.WriteLine();
            Question_5();
            Console.Read();
        }
        public static void Question_1()
        {
            Console.WriteLine("Enter 1st number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine("{0} and {1} are equal", num1, num2);
            }
            else
            {
                Console.WriteLine("{0} and {1} are not equal", num1, num2);
            }
        }
        public static void Question_2()
        {
            Console.WriteLine("Enter number :");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine("{0} is a Positive number", num);
            }
            else
                Console.WriteLine("{0} is a Negative number", num);
        }
        public static void Question_3() 
        {
            Console.WriteLine("Enter num1:");
           
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Operation:");
            char operand = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter num2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if ( operand == '+')
            {
                Console.WriteLine("{0} {1} {2} = {3}", num1,operand, num2,num1+num2);
            }
            else if(operand == '-')
            {
                Console.WriteLine("{0} {1} {2} = {3}", num1, operand, num2, num1-num2);
            }
            else if(operand == '*')
            {
                Console.WriteLine("{0} {1} {2} = {3}", num1, operand, num2, num1*num2);
            }
            else if(operand == '/')
            {
                Console.WriteLine("{0} {1} {2} = {3}", num1, operand, num2, num1/num2);
            }
        }
        public static void Question_4()
        {
            Console.WriteLine("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine("{0} * {1} = {2}", num, i, num * i);
            }
        }
        public static void Question_5()
        {
            Console.WriteLine("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine("Output:{0}", 3 * (num1 + num2));
            }
            else
            {
                Console.WriteLine("Output:{0}", num1 + num2);
            }
        }
    }
}
