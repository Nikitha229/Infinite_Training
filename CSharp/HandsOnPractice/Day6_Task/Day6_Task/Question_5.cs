using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Task
{
    class InvalidRange : Exception
    {
        string message;
        public InvalidRange(string message) : base(message)
        {
            this.message = message;
        }
    }
    class Student
    {
        int subject1;
        int subject2;
        int subject3;
        float Average;

        public Student(int sub1, int sub2, int sub3)
        {
            subject1 = sub1;
            subject2 = sub2;
            subject3 = sub3;
        }

        public void Display()
        {
            Average = (subject1 + subject2 + subject3) / 3;
            Console.WriteLine("Subject1 marks: {0}", subject1);
            Console.WriteLine("Subject2 marks: {0}", subject2);
            Console.WriteLine("Subject3 marks: {0}", subject3);
            Console.WriteLine("Average Marks: {0}", Average);
        }
    }
    class Question_5
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter subject1 Marks: ");
                int m1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter subject2 Marks: ");
                int m2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter subject3 Marks: ");
                int m3 = Convert.ToInt32(Console.ReadLine());
                Student s = new Student(m1, m2, m3);
                if (m1 > 100 || m2 > 100 || m3 > 100)
                    throw new InvalidRange("Marks should be in range 0 to 100");
                s.Display();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error : Entered non integer value");
            }
            catch (InvalidRange ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Grade Calculation Completed");
            }
            Console.Read();
        }
    }
}
