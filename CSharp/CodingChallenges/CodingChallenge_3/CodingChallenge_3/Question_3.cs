using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodingChallenge_3
{
    class Question_3
    {
        static void WriteStream()
        {
            FileStream fs = new FileStream("C:\\Infinite-Training\\CSharp\\CodingChallenges\\CodingChallenge_3\\CodingChallenge_3\\Question_3_FileStream.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.Write("Enter string to get append in the file:  ");
            string str = Console.ReadLine();
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
        }

        static void ReadStream()
        {
            FileStream fs = new FileStream("C:\\Infinite-Training\\CSharp\\CodingChallenges\\CodingChallenge_3\\CodingChallenge_3\\Question_3_FileStream.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Console.WriteLine("Text in the particular file: ");
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void Main()
        {
            Console.WriteLine("Question-3 Output: ");
            WriteStream();
            Console.WriteLine("Text Appended Successfully!!");
            Console.WriteLine("======================================================");
            ReadStream();
            Console.Read();
        }
    }
}
