using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class UpdatingTrains
    {
        public static void UpdateTrain()
        {
            Console.Write("Enter Train Number to update: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = Connection.getconnection())
            {
                string checkQuery = "SELECT * FROM Trains WHERE TrainNo = @TrainNo";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                SqlDataReader reader = checkCmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("Train not found.");
                    return;
                }

                string currentName = reader["TrainName"].ToString();
                string currentSource = reader["Source"].ToString();
                string currentDestination = reader["Destination"].ToString();
                reader.Close();

                Console.Write($"Enter new Train Name (current: {currentName}) or press Enter to keep: ");
                string trainName = Console.ReadLine();
                if (trainName == "") trainName = currentName;

                Console.Write($"Enter new Source Station (current: {currentSource}) or press Enter to keep: ");
                string source = Console.ReadLine();
                if (source == "") source = currentSource;

                Console.Write($"Enter new Destination Station (current: {currentDestination}) or press Enter to keep: ");
                string destination = Console.ReadLine();
                if (destination == "") destination = currentDestination;

                string updateQuery = @"UPDATE Trains 
                               SET TrainName = @TrainName, Source = @Source, Destination = @Destination,isactive=1
                               WHERE TrainNo = @TrainNo";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@TrainName", trainName);
                updateCmd.Parameters.AddWithValue("@Source", source);
                updateCmd.Parameters.AddWithValue("@Destination", destination);
                updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                updateCmd.ExecuteNonQuery();
                Console.WriteLine("Train details updated successfully.");

                Console.Write("Do you want to update train classes? (yes/no): ");
                string updateClasses = Console.ReadLine().ToLower();

                if (updateClasses == "yes")
                {
                    Console.Write("Enter number of classes to update: ");
                    int classCount = int.Parse(Console.ReadLine());

                    for (int i = 0; i < classCount; i++)
                    {
                        Console.WriteLine($"\nClass {i + 1}:");
                        Console.Write("Enter Class Name: ");
                        string className = Console.ReadLine();

                        string classCheckQuery = @"SELECT * FROM TrainClasses WHERE TrainNo = @TrainNo AND Class = @Class";
                        SqlCommand classCheckCmd = new SqlCommand(classCheckQuery, conn);
                        classCheckCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        classCheckCmd.Parameters.AddWithValue("@Class", className);

                        SqlDataReader classReader = classCheckCmd.ExecuteReader();
                        if (!classReader.Read())
                        {
                            Console.WriteLine("Class not found.");
                            classReader.Close();
                            continue;
                        }

                        int currentSeats = Convert.ToInt32(classReader["Available_Seats"]);
                        float currentCost = Convert.ToSingle(classReader["Cost_Per_Seat"]);
                        classReader.Close();

                        Console.Write($"Enter new Available Seats (current: {currentSeats}) or press Enter to keep: ");
                        string seatsInput = Console.ReadLine();
                        int seats = string.IsNullOrWhiteSpace(seatsInput) ? currentSeats : int.Parse(seatsInput);

                        Console.Write($"Enter new Cost Per Seat (current: {currentCost}) or press Enter to keep: ");
                        string costInput = Console.ReadLine();
                        float cost = string.IsNullOrWhiteSpace(costInput) ? currentCost : float.Parse(costInput);

                        string updateClassQuery = @"UPDATE TrainClasses 
                                            SET Available_Seats = @Seats, Cost_Per_Seat = @Cost 
                                            WHERE TrainNo = @TrainNo AND Class = @Class";
                        SqlCommand classCmd = new SqlCommand(updateClassQuery, conn);
                        classCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        classCmd.Parameters.AddWithValue("@Class", className);
                        classCmd.Parameters.AddWithValue("@Seats", seats);
                        classCmd.Parameters.AddWithValue("@Cost", cost);

                        classCmd.ExecuteNonQuery();
                        Console.WriteLine("Class updated successfully.");
                    }
                }
            }
        }

    }
}
