using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Task
{

    class player
    {
        public int Score { get; set; }

        public player(int score)
        {
            Score = score;
        }

    }
    class Question_3
    {
        public static void Main()
        {
            Console.Write("Enter Player1 Score: ");
            int s1 = Convert.ToInt32(Console.ReadLine());
            player p1 = new player(s1);
            Console.Write("Enter Player2 Score: ");
            int s2 = Convert.ToInt32(Console.ReadLine());
            player p2 = new player(s2);

            Console.Write("Enter Player3 Score: ");
            int s3 = Convert.ToInt32(Console.ReadLine());
            player p3 = new player(s3);

            bool ByOperator = p1.Score == p2.Score;

            bool ByEquals = p2.Score.Equals(p3.Score);

            int ByCompareTo = p1.Score.CompareTo(p3.Score);

            if (ByOperator)
                Console.WriteLine("ByOperator p1 and p2 are Equal p1:{0} and p2:{1}", p1.Score, p2.Score);
            else
                Console.WriteLine("ByOperator p1 and p2 are not Equal p1:{0} and p2:{1}", p1.Score, p2.Score);

            if (ByEquals)
                Console.WriteLine("ByEqual p3 and p2 are Equal p3:{0} and p2:{1}", p3.Score, p2.Score);
            else
                Console.WriteLine("ByEqual p3 and p2 are not Equal p3:{0} and p2:{1}", p3.Score, p2.Score);

            if (ByCompareTo == 0)
                Console.WriteLine("ByCompareTo p1 and p3 are Equal p1:{0} and p3:{1}", p1.Score, p3.Score);
            else
                Console.WriteLine("ByCompareTo p1 and p3 are not Equal p1:{0} and p3:{1}", p1.Score, p3.Score);

            Console.Read();


        }
    }
}
