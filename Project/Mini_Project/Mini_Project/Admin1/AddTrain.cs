using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class AddTrain
    {
        public static void AddNewTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter Source Station: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination Station: ");
            string destination = Console.ReadLine();

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = @"INSERT INTO Trains (TrainNo, TrainName, Source, Destination,isactive)
                                 VALUES (@TrainNo, @TrainName, @Source, @Destination,1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Train added successfully.");
            }

            Console.Write("Enter number of classes to add: ");
            int classCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < classCount; i++)
            {
                Console.WriteLine($"\nClass {i + 1}:");
                Console.Write("Enter Class Name: ");
                string className = Console.ReadLine();

                Console.Write("Enter Available Seats: ");
                int seats = int.Parse(Console.ReadLine());

                Console.Write("Enter Cost Per Seat: ");
                float cost = float.Parse(Console.ReadLine());

                using (SqlConnection conn = Connection.getconnection())
                {
                    string classQuery = @"INSERT INTO TrainClasses (TrainNo, Class, Available_Seats, Cost_Per_Seat)
                                          VALUES (@TrainNo, @Class, @Seats, @Cost)";
                    SqlCommand classCmd = new SqlCommand(classQuery, conn);
                    classCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    classCmd.Parameters.AddWithValue("@Class", className);
                    classCmd.Parameters.AddWithValue("@Seats", seats);
                    classCmd.Parameters.AddWithValue("@Cost", cost);

                    classCmd.ExecuteNonQuery();
                    Console.WriteLine("Class added successfully.");
                }
            }
        }
    }
}
