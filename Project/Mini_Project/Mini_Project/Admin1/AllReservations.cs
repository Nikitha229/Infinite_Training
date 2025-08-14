using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class AllReservations
    {
        public static void ViewAllReservations()
        {

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = "SELECT * FROM Reservation";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\n--- All Reservations ---\n");
                    Console.WriteLine(
                        $"{ "BookingId",-8}| { "CustomerId",-10} | { "TrainNo",-8} |{ "TrainName",-20} | { "DOJ",-11}| { "Source",-14}| { "Dest",-12}| { "Class",-8}| { "BookingDate",-15}| { "Passengers",-10}| { "NetCost",-10}");

                    Console.WriteLine(new string('-', 150));
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["BookingId"],-9}| {reader["CustomerId"],-10}| {reader["TrainNo"],-10}| {reader["TrainName"],-21}| {Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd"),-12}| {reader["Source"],-14}| {reader["Destination"],-12}| {reader["Class"],-8}| {Convert.ToDateTime(reader["BookingDate"]).ToString("yyyy-MM-dd"),-15}| {reader["No_of_Passengers"],-10}| {reader["TotalCost"],-10}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving reservations: " + ex.Message);
                }
            }
        }

    }
}
