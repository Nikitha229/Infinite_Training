using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    // Question 1 already dome in assignment 5

    // Write a program in C# Sharp to create a file and write an array of strings to the file.

    class Question_2
    {
        static void WriteStream(string[] lines)
        {
            FileStream fs = new FileStream("C:\\Infinite-Training\\CSharp\\Assignments\\Assignment_6\\Assignment_6\\Sample_Strings_Question_2_File.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var str in lines)
            {
                sw.WriteLine(str);
            }
            sw.Flush();
            sw.Close();
        }


        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            Console.Write("Enter number of strings: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Enter string {0}", i+1);
                string s = Console.ReadLine();
                lines.Add(s);
            }
            WriteStream(lines.ToArray());
            Console.WriteLine("Strings successfully added in the file");
            Console.Read();
        }
    }
}
