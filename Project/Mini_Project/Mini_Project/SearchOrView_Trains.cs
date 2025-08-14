using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class SearchOrView_Trains
    {
        public static void SearchOrViewTrains()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. View all trains");
            Console.WriteLine("2. Search by source and destination");
            Console.Write("Enter option (1 or 2): ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                ShowAllTrains();
            }
            else if (option == 2)
            {
                Console.Write("Enter source station: ");
                string source = Console.ReadLine();

                Console.Write("Enter destination station: ");
                string destination = Console.ReadLine();

                ShowTrainsByRoute(source, destination);
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }
        static void ShowAllTrains()
        {
            using (SqlConnection conn = Connection.getconnection())
            {
                string query = @"SELECT T.TrainNo, T.TrainName,T.Source,T.Destination, TC.Class, TC.Available_Seats, TC.Cost_Per_Seat,T.isactive
                         FROM Trains T
                         JOIN TrainClasses TC ON T.TrainNo = TC.TrainNo where T.isactive=1
                         ORDER BY T.TrainNo";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                int currentTrainNo = -1;
                string currentTrainName = "";

                while (reader.Read())
                {
                    int trainNo = Convert.ToInt32(reader["TrainNo"]);
                    string trainName = reader["TrainName"].ToString();
                    string status = "";
                    if (Convert.ToInt32(reader["isactive"]) == 1)
                        status = "Active";
                    else
                    {
                        status = "Not-Active";
                    }
                    if (trainNo != currentTrainNo)
                    {
                        currentTrainNo = trainNo;
                        currentTrainName = trainName;

                        Console.WriteLine($"\nTrain No: {trainNo} - {trainName} (Source - {reader["Source"]} Destination - {reader["Destination"]}  ({status})");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Class\tAvailable Seats\t\tFare");
                        Console.WriteLine("-----------------------------------------------------------");

                    }

                    string className = reader["Class"].ToString();
                    int seats = Convert.ToInt32(reader["Available_Seats"]);
                    decimal fare = Convert.ToDecimal(reader["Cost_Per_Seat"]);

                    Console.WriteLine($"{className,-15}{seats,-16}{fare,-10}");
                }

                reader.Close();
            }
        }

        static void ShowTrainsByRoute(string source, string destination)
        {
            using (SqlConnection conn = Connection.getconnection())
            {
                string query = @"SELECT T.TrainNo, T.TrainName, TC.Class, TC.Available_Seats, TC.Cost_Per_Seat
                         FROM Trains T
                         JOIN TrainClasses TC ON T.TrainNo = TC.TrainNo
                         WHERE T.Source = @Source AND T.Destination = @Destination and T.isactive=1
                         ORDER BY T.TrainNo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);

                SqlDataReader reader = cmd.ExecuteReader();

                int currentTrainNo = -1;
                string currentTrainName = "";

                while (reader.Read())
                {
                    int trainNo = Convert.ToInt32(reader["TrainNo"]);
                    string trainName = reader["TrainName"].ToString();

                    if (trainNo != currentTrainNo)
                    {
                        currentTrainNo = trainNo;
                        currentTrainName = trainName;

                        Console.WriteLine($"\nTrain No: {trainNo} - {trainName}");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Class\t\tAvailable Seats\tFare");
                        Console.WriteLine("--------------------------------------------------");

                    }

                    string className = reader["Class"].ToString();
                    int seats = Convert.ToInt32(reader["Available_Seats"]);
                    decimal fare = Convert.ToDecimal(reader["Cost_Per_Seat"]);

                    Console.WriteLine($"{className,-15}{seats,-16}{fare,-10}");
                }

                reader.Close();
            }
        }

    }
}

