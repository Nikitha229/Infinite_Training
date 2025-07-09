using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_3
{
    //2. Write a class Box that has Length and breadth as its members.Write a function that adds 2 box objects and stores in the 3rd.Display the 3rd object details. Create a Test class to execute the above
    public class Box
    {
        public double Length;
        public double Breadth;

        public Box(double length,double breadth) 
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    public class Test
    {
        public static void Main()
        {
            Console.WriteLine("Question-2 Output: ");

            Console.Write("Enter Box-1 Length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Box-1 Breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Box-2 Length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Box-2 Breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());
            Box box1 = new Box(length1,breadth1);
            Box box2 = new Box(length2,breadth2);
            Box box3 = box1 + box2;

            Console.WriteLine("=====Box 1=========");
            box1.Display();

            Console.WriteLine("=====Box 2=========");
            box2.Display();

            Console.WriteLine("========Box 3 (Result)=========");
            box3.Display();

            Console.Read();
        }
    }

}
