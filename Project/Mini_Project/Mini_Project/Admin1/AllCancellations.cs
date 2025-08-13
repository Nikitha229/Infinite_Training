using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class AllCancellations
    {
        public static void ViewAllCancellations()
        {

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = "SELECT * FROM Cancellation";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\n--- All Cancellations ---\n");
                    Console.WriteLine(
                        $"{ "CancelID",-10} { "BookingID",-10} { "PassengerID",-12} { "RefundAmount",-15} { "CancelDate",-15}");

                    Console.WriteLine(new string('-', 70));
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["CancellationID"],-10} {reader["BookingId"],-10} {reader["PassengerID"],-12} {reader["RefundAmount"],-13} {Convert.ToDateTime(reader["CancellationDate"]).ToString("yyyy-MM-dd"),-15}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving cancellations: " + ex.Message);
                }
            }
        }

    }
}
