using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Cancellation
    {
        public static void CancelTicket(int custid)
        {
            SqlConnection con =Connection.getconnection();

           string query = $"SELECT * FROM Reservation r join passenger p on r.bookingid=p.bookingid where r.customerid={custid} and p.status='Confirmed'";
            List<int> ids = new List<int>();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- All Reservations ---\n");
            Console.WriteLine(
                $"{ "BookingId",-8}| { "CustomerId",-10} | { "TrainNo",-6} |{ "TrainName",-17} | { "DOJ",-9}| { "Source",-10}| { "Dest",-10}| { "Class",-8}| { "BookingDate",-13}| { "Passengers",-8}| { "NetCost",-8}");

            Console.WriteLine(new string('-', 130));
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["BookingId"],-9}| {reader["CustomerId"],-11}| {reader["TrainNo"],-8}| {reader["TrainName"],-15}| {Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd"),-11}| {reader["Source"],-10}| {reader["Destination"],-10}| {reader["Class"],-8}| {Convert.ToDateTime(reader["BookingDate"]).ToString("yyyy-MM-dd"),-13}| {reader["No_of_Passengers"],-6}| {reader["TotalCost"],-8}");
                ids.Add(Convert.ToInt32(reader["BookingId"]));
            }

            reader.Close();
            Console.Write("Enter Booking ID(in range 1000 to 2000): ");
            int bookingId = int.Parse(Console.ReadLine());
            if (ids.Contains(bookingId))
            {
                SqlCommand getpassenger = new SqlCommand($"select passengerid,name from passenger  where bookingid={bookingId} and status='Confirmed'", con);
                SqlDataReader readgetpass = getpassenger.ExecuteReader();
                while (readgetpass.Read())
                {
                    int passengerid = readgetpass.GetInt32(0);
                    string passengername = readgetpass.GetString(1);
                    Console.WriteLine($"PassengerID: {passengerid} PassengerName:{passengername}");
                }
                readgetpass.Close();
                Console.Write("Enter Passenger ID: ");
                int passengerId = int.Parse(Console.ReadLine());
                string getCostQuery = $"select Traveldate,cost from Passenger where passengerId = {passengerId}";
                SqlCommand getCmd = new SqlCommand(getCostQuery, con);
                getCmd.Parameters.AddWithValue("@BookingId", bookingId);
                SqlDataReader result = getCmd.ExecuteReader();
                if (result.Read())
                {
                    double totalCost = result.GetDouble(1);
                    DateTime doj = result.GetDateTime(0);
                    string cancelQuery = @"insert into Cancellation (BookingId, PassengerID, RefundAmount, CancellationDate)
                                   values (@BookingId, @PassengerID, @Refund, GETDATE())";
                    SqlCommand cancelCmd = new SqlCommand(cancelQuery, con);
                    cancelCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    cancelCmd.Parameters.AddWithValue("@PassengerID", passengerId);
                    int diff = (doj - DateTime.Now).Days;
                    double refund = totalCost;
                    if (diff <= 30)
                    {
                        refund = totalCost * 0.2;
                    }
                    else if (diff <= 10)
                    {
                        refund = totalCost * 0.5;
                    }
                    cancelCmd.Parameters.AddWithValue("@Refund", refund);
                    result.Close();
                    cancelCmd.ExecuteNonQuery();
                    Console.Write("Are you sure you want cancel ticket(y/n): ");
                    string c = Console.ReadLine();
                    if (c == "y")
                    {
                        Console.WriteLine($"Cancellation successful. Refund initiated: {refund}");
                        SqlCommand updatestatus = new SqlCommand($"update Passenger set status='Cancelled' where passengerid={passengerId}", con);
                        SqlDataReader updatereader = updatestatus.ExecuteReader();
                        updatereader.Close();
                    }

                }
            }
            else
            {
                Console.WriteLine("Booking ID not valid.");
            }
        }
    }
}
