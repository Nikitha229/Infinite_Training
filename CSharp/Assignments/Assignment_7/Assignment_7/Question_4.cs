using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_7_Question_4;

namespace Assignment_7
{
    class Question_4
    {
        public static void Main()
        {
            Console.Write("Enter your name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("Enter the total fare: ");
            double TotalFare = double.Parse(Console.ReadLine());

            Assignment_7_Question_4.TravelConcession travelConcession = new TravelConcession();
            string res=travelConcession.CalculateConcession(Age,TotalFare);
            Console.WriteLine($"Hello {Name}, {res}");
            Console.Read();
        }
     }

}
