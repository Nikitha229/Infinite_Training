using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    class Question_3
    {
        static void ReadStream()
        {
            FileStream fs = new FileStream("C:\\Infinite-Training\\CSharp\\Assignments\\Assignment_6\\Assignment_6\\Sample_Strings_Question_2_File.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            int count = 0;
            string str = sr.ReadLine();
            while (str != null)
            {
                count++;
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            Console.WriteLine("Number of lines in file: {0}", count);
            sr.Close();
            fs.Close();
        }
        public static void Main()
        {
            ReadStream();
            Console.Read();
        }
    }
}
