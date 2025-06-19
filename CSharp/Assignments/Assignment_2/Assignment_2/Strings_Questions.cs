using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Strings_Questions
    {
        public static void Question_1()
        {
            Console.WriteLine("Enter String");
            string s = Console.ReadLine();
            Console.WriteLine("Length of the String s={0}", s.Length);
        }

        public static void Question_2()
        {
            Console.WriteLine("Enter String");
            string s = Console.ReadLine();
            Console.WriteLine("Before String Reverse: {0}", s);
            string str =new  string(s.Reverse().ToArray());
            Console.WriteLine("After String Reverse: {0}", str);
        }

        public static void Question_3()
        {
            Console.WriteLine("Enter String1");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter String2");
            string s2 = Console.ReadLine();
            bool res = (s1 == s2) ? true : false;
            if (res)
                Console.WriteLine("Both strings are same");
            else
                Console.WriteLine("Both Strings are not same");
        }
    }
}
