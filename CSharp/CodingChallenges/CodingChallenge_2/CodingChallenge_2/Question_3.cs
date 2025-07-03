using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_2
{
    /*3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.*/

    class NegativeNumberException:Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }
    class Question_3
    {
       
        public static void Main()
        {
            Console.WriteLine("Question_3 Output: ");
            Console.Write("Enter Number of Testcases: ");
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                try
                {
                    Console.Write("Enter Number: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0)
                    {
                        Console.WriteLine("Number: {0}", num);
                    }
                    else if (num < 0)
                    {
                        throw new NegativeNumberException($"You Entered Invalid number!!! Number: {num}");
                    }
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                T--;
            }
            Console.Read();
        }
    }
}
