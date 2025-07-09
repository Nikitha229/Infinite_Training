using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge_3
{
    //Question-1: Write a program to find the Sum and the Average points scored by the teams in the IPL. Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input and accepts that many scores from the user. The function should then return the Count of Matches, Average and Sum of the scores.
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            List<int> Scores = new List<int>();
            int TotalScore = 0;
            for(int i=0;i<no_of_matches;i++)
            {
                Console.Write("Enter Score of Match-{0}: ", i + 1);
                int score = Convert.ToInt32(Console.ReadLine());
                TotalScore += score;
                Scores.Add(score);
            }
            double Average = TotalScore / no_of_matches;

            Console.WriteLine("Count of Matches: {0}", no_of_matches);
            Console.WriteLine("TotalScore from all Matches: {0}", TotalScore);
            Console.WriteLine("Average Score: {0}", Average);
        }
    }
    class Question_1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter No/- of Matches: ");
            int n = Convert.ToInt32(Console.ReadLine());
            CricketTeam cricketTeam = new CricketTeam();
            cricketTeam.Pointscalculation(n);
            Console.Read();
        }
    }
}
