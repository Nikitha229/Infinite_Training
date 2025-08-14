using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class ActivateAndDeactivate
    {
        public static void ActivateTrain()
        {
            Console.Write("Enter Train Number to activate: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = "UPDATE Trains SET IsActive = 1 WHERE TrainNo = @TrainNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Train activated successfully.");
                else
                    Console.WriteLine("Train not found or already active.");
            }
        }

        public static void DeactivateTrain()
        {
            Console.Write("Enter Train Number to deactivate: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = Connection.getconnection())
            {
                SqlCommand cd = new SqlCommand($"select passengerid from passenger where trainno={trainNo}",conn);
                SqlDataReader read = cd.ExecuteReader();
                int c = 0;
                while(read.Read())
                {
                    c++;
                }
                read.Close();
                if (c == 0)
                {
                    string query = "UPDATE Trains SET IsActive = 0 WHERE TrainNo = @TrainNo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Train deactivated successfully.");
                    else
                        Console.WriteLine("Train not found or already inactive.");
                }
                else
                {
                    Console.WriteLine("Cannot deactivate this train, there are passengers booked for this train");
                }
            }
        }
    }
}
