using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_2
{
/*1. Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  
 Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 Test the above by creating appropriate objects*/


    abstract class Student
    {
        public int StudentId;
        public string Name;
        public double Grade;

        public Student(int studentId, string name, double grade)
        {
            StudentId = studentId;
            Name = name;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(int studentid, string name, double grade) : base(studentid, name, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(int studentid, string name, double grade) : base(studentid, name, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Question_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question_1 Output: ");
            Console.WriteLine("Enter Student_1 Details: ");
            Console.Write("Enter StudentID: ");
            int studentId_1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name_1 = Console.ReadLine();
            Console.Write("Enter Grade: ");
            double grade_1 = Convert.ToDouble(Console.ReadLine());
            Undergraduate student_1 = new Undergraduate(studentId_1, name_1, grade_1);
            Console.WriteLine("Enter Student_2 Details: ");
            Console.Write("Enter StudentID: ");
            int studentId_2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name_2 = Console.ReadLine();
            Console.Write("Enter Grade: ");
            double grade_2 = Convert.ToDouble(Console.ReadLine());
            Graduate student_2 = new Graduate(studentId_2, name_2, grade_2);
            Console.WriteLine($"StudentId:{studentId_1} Name:{name_1} (Undergraduate) Passed:{student_1.IsPassed(grade_1)} ");
            Console.WriteLine($"StudentId:{studentId_2} Name:{name_2} (Graduate) Passed:{student_2.IsPassed(grade_2)} ");
            Console.Read();

        }
    }
}
