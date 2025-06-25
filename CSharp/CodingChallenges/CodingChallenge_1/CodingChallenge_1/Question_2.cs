using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_1
{
    class Question_2
    {
        public static void Main()
        {
            Console.Write("Enter number of testcases: ");
            int t = Convert.ToInt32(Console.ReadLine());
            while (t>0)
            {
                Console.Write("Enter String: ");
                string str = Console.ReadLine();
                char firstChar = str[0], lastChar = str[str.Length - 1];
                string s = "";
                Console.WriteLine("Before Swapping first and last Characters: {0}", str);
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 0)
                        s += lastChar;
                    else if (i == str.Length - 1)
                        s += firstChar;
                    else
                        s += str[i];
                }
                Console.WriteLine("After Swapping first and last Characters: {0}", s);
                t--;
            }
            Console.Read();
        }
    }
}
