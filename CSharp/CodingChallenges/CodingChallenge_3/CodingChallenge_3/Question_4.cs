using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_3
{
     //4. Write a console program that uses delegate object as an argument to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication
     //by taking 2 integers and returning the output to the user. You should display all the return values accordingly.

    public delegate int CalculatorDelegate(int num1, int num2);
    class Question_4
    {
        static int Calculation(int a, int b, CalculatorDelegate calculator)
        {
            return calculator(a, b);
        }
        public static void Main()
        {
            Console.WriteLine("Question-4 Output: ");
            CalculatorDelegate Add = (a, b) => a + b;
            CalculatorDelegate Subtract = (a, b) => a - b;
            CalculatorDelegate Multiply = (a, b) => a * b;
            Console.Write("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("============Result==================");
            Console.WriteLine("Addition: {0}", Calculation(num1, num2, Add));
            Console.WriteLine("Subtraction: {0}", Calculation(num1, num2, Subtract));
            Console.WriteLine("Multiplication: {0}",Calculation(num1, num2, Multiply));
            Console.Read();

        }
    }
}
