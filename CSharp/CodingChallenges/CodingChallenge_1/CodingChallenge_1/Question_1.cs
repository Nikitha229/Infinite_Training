using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_1
{
    class Question_1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of Testcases: ");
            int t = Convert.ToInt32(Console.ReadLine());
            while (t > 0)
            {
                Console.Write("Enter String: ");
                string s = Console.ReadLine();
                Console.Write("Enter Index : ");
                int index = Convert.ToInt32(Console.ReadLine());
                string str = "";
                Console.WriteLine("Before removing Character s: {0}", s);
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == index)
                        continue;
                    else
                        str += s[i];
                }
                s = str;
                Console.WriteLine("After removing character s: {0}", s);
                t--;
            }
            Console.Read();
        }
    }
}
