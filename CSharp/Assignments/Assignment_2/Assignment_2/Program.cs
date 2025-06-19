using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Question_1---------------");
            Swap();
            Console.WriteLine("--------------Question_2---------------");
            Question_2();
            Console.WriteLine("--------------Question_3---------------");
            Question_3();
            Console.WriteLine("--------------Arrays_Question_1_(a)---------------");
            Arrays_Questions.Question_1_a();
            Console.WriteLine("--------------Arrays_Question_1_(a)---------------");
            Arrays_Questions.Question_1_b();
            Console.WriteLine("--------------Arrays_Question_2---------------");
            Arrays_Questions.Question_2();
            Console.WriteLine("--------------Arrays_Question_3---------------");
            Arrays_Questions.Question_3();
            Console.WriteLine("--------------Strings_Question_1---------------");
            Strings_Questions.Question_1();
            Console.WriteLine("--------------Strings_Question_2---------------");
            Strings_Questions.Question_2();
            Console.WriteLine("--------------Strings_Question_3---------------");
            Strings_Questions.Question_3();
            Console.Read();
        }
        public static void Swap()
        {
            Console.WriteLine("Enter num1 and num2");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int temp;
            Console.WriteLine("num1 and num2 Before Swapping num1={0} and num2={1}", num1, num2);
            temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("num1 and num2 After Swapping num1={0} and num2={1}", num1, num2);
        }
        public static void Question_2()
        {
            Console.WriteLine("Enter number to display in pattern");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < 4; i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (i % 2 == 0)
                        Console.Write(num + " ");
                    else
                        Console.Write(num);
                }
                Console.WriteLine();
            }

        }

        public static void Question_3()
        {
            Console.WriteLine("Enter day number in between (1 t0 7)");
            int day_num = Convert.ToInt32(Console.ReadLine());
            string res = "";
            if (day_num == 1)
                res = "Sunday";
            else if (day_num == 2)
                res = "Monday";
            else if (day_num == 3)
                res = "Tuesday";
            else if (day_num == 4)
                res = "Wednesday";
            else if (day_num == 5)
                res = "Thursday";
            else if (day_num == 6)
                res = "Friday";
            else if (day_num == 7)
                res = "Saturday";
            Console.WriteLine(res);
        }
    }
}
