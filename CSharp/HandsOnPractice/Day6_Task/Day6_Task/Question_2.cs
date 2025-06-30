using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Task
{
    class Box
    {
        public int length;

        public static Box operator +(Box box1, Box box2)
        {
            Box temp = new Box();
            temp.length = box1.length + box2.length;
            return temp;
        }

    }
    class Question_2
    {
        public static void Main()
        {
            Box b1 = new Box();
            Console.Write("Enter Box1 Length: ");
            b1.length = Convert.ToInt32(Console.ReadLine());
            Box b2 = new Box();
            Console.Write("Enter Box2 Length: ");
            b2.length = Convert.ToInt32(Console.ReadLine());
            Box b3 = b1 + b2;
            Console.WriteLine("Box1 Length:{0}  Box2 Length:{1} Box3 Length:{2}", b1.length, b2.length, b3.length);
            Console.Read();
        }
    }
}
