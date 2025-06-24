using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class student
    {
        public int Rollno;
        public string Name;
        public int Sem;
        public string Branch;
        public int Section;
        public int[] marks = new int[5];
        public string status="Pass";
        public int failed = 0,TotalScore=0,AverageScore;


        public student(int rollno,string name,int sem,string branch,int section)
        {
            Rollno = rollno;
            Name = name;
            Sem = sem;
            Branch = branch;
            Section = section;
        }
        public void GetMarks()
        {
            for(int i=0;i<marks.Length;i++)
            {
                Console.Write("Enter marks for subject-{0}: ", i + 1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
                TotalScore += marks[i];
                if(marks[i]<35)
                {
                    failed++;
                }
            }
            AverageScore = TotalScore / 5;
        }

        public void DisplayData()
        {
            Console.WriteLine("RollNo: {0}",Rollno);
            Console.WriteLine("Name: {0}",Name);
            Console.WriteLine("Semister: {0}",Sem);
            Console.WriteLine("Branch: {0}",Branch);
            Console.WriteLine("Section: {0}", Section);
            Console.WriteLine("--------SubjectWise Marks--------");
            for(int i=0;i<marks.Length;i++)
            {
                Console.WriteLine("Subject-{0} Marks: {1}", i + 1, marks[i]);
            }
            if (failed > 0)
                status = "Failed";
            else if (failed == 0 && AverageScore < 50)
                status = "Failed";
            Console.WriteLine("Total Score: {0} Average Score: {1} and Status:{2}", TotalScore,AverageScore, status);
        }

    }
    class Question_2
    {
        public static void Main()
        {
            Console.WriteLine("Enter Student Details");
            Console.Write("Enter rollno: ");
            int rollno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Sem: ");
            int sem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();
            Console.Write("Enter Section: ");
            int section = Convert.ToInt32(Console.ReadLine());
            student s1 = new student(rollno, name, sem, branch, section);
            s1.GetMarks();
            Console.WriteLine("================Results==============");
            s1.DisplayData();
            Console.Read();
        }
    }
}
