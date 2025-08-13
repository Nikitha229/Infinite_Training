using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Reservation
    {
        public static void MakeReservation(int custid)
        {
            Console.Write("Enter Source Station: ");
            string source = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            string destination = Console.ReadLine();
            Console.Write("Enter Date of Journey (yyyy-mm-dd): ");
            DateTime doj = DateTime.Parse(Console.ReadLine());
            if (doj >= DateTime.Today)
            {
                try
                {

                    SqlConnection con = Connection.getconnection();

                    string trainQuery = @"select t.TrainNo, t.TrainName, tc.Class, tc.Available_Seats, tc.Cost_Per_Seat
                              from Trains t
                              join TrainClasses tc ON t.TrainNo = tc.TrainNo
                              where t.Source = @Source AND t.Destination = @Destination and t.isactive=1";

                    SqlCommand trainCmd = new SqlCommand(trainQuery, con);
                    trainCmd.Parameters.AddWithValue("@Source", source);
                    trainCmd.Parameters.AddWithValue("@Destination", destination);

                    SqlDataReader reader = trainCmd.ExecuteReader();
                    var trainOptions = new Dictionary<int, List<(string Class, int Seats, double Cost)>>();

                    Console.WriteLine("\nAvailable Trains:");
                    int j = 0;

                    while (reader.Read())
                    {
                        int trainNo = reader.GetInt32(0);
                        string trainName = reader.GetString(1);
                        string travelClass = reader.GetString(2);
                        int seats = reader.GetInt32(3);
                        double cost = reader.GetDouble(4);

                        if (!trainOptions.ContainsKey(trainNo))
                        {
                            Console.WriteLine();
                            trainOptions[trainNo] = new List<(string, int, double)>();
                            j = 0;
                        }

                        trainOptions[trainNo].Add((travelClass, seats, cost));
                        if (j == 0)
                        {

                            Console.WriteLine($"Train No: {trainNo}, Train Name: {trainName}");
                            Console.WriteLine($"Class: {travelClass}, Seats: {seats}, Cost: ₹{cost}");
                            j++;
                        }
                        else
                        {
                            Console.WriteLine($"Class: {travelClass}, Seats: {seats}, Cost: ₹{cost}");
                        }
                    }
                    reader.Close();

                    Console.Write("\nEnter Train No to book: ");
                    int selectedTrainNo = Convert.ToInt32(Console.ReadLine());

                    if(!trainOptions.ContainsKey(selectedTrainNo))
                    {
                        Console.WriteLine("invalid Train number");
                        return;
                    }

                    string trainNameQuery = "SELECT TrainName FROM Trains WHERE TrainNo = @TrainNo";
                    SqlCommand cmd2 = new SqlCommand(trainNameQuery, con);
                    cmd2.Parameters.AddWithValue("@TrainNo", selectedTrainNo);
                    string selectedTrainName = cmd2.ExecuteScalar().ToString();

                    Console.Write("Enter Class to book: ");
                    string selectedClass = Console.ReadLine();

                    var selectedClassInfo = trainOptions[selectedTrainNo].FirstOrDefault(c => c.Class == selectedClass);
                    if (selectedClassInfo.Seats == 0)
                    {
                        Console.WriteLine("No seats available in selected class.");
                        return;
                    }

                    int customerId = custid;
                    Console.Write("Enter Number of Passengers: ");
                    int numPassengers = int.Parse(Console.ReadLine());

                    if (numPassengers > selectedClassInfo.Seats)
                    {
                        Console.WriteLine("Not enough seats available.");
                        return;
                    }

                    double totalCost = selectedClassInfo.Cost * numPassengers;

                    string resQuery = @"insert into Reservation (CustomerId, TrainNo, TrainName, DateOfJourney, Source, Destination, Class, BookingDate, No_of_Passengers, TotalCost)
                            values (@CustomerId, @TrainNo, @TrainName, @DOJ, @Source, @Destination, @Class, GETDATE(), @Passengers, @TotalCost);
                            select SCOPE_IDENTITY();";

                    SqlCommand resCmd = new SqlCommand(resQuery, con);
                    resCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    resCmd.Parameters.AddWithValue("@TrainNo", selectedTrainNo);
                    resCmd.Parameters.AddWithValue("@TrainName", selectedTrainName);
                    resCmd.Parameters.AddWithValue("@DOJ", doj);
                    resCmd.Parameters.AddWithValue("@Source", source);
                    resCmd.Parameters.AddWithValue("@Destination", destination);
                    resCmd.Parameters.AddWithValue("@Class", selectedClass);
                    resCmd.Parameters.AddWithValue("@Passengers", numPassengers);
                    resCmd.Parameters.AddWithValue("@TotalCost", totalCost);

                    int bookingId = Convert.ToInt32(resCmd.ExecuteScalar());

                    string[] berths = { "Upper", "Middle", "Lower","Side Lower","Side Upper" };
                    Random rand = new Random();

                    for (int i = 0; i < numPassengers; i++)
                    {
                        Console.WriteLine($"\nEnter details for Passenger {i + 1}:");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Adhar Number: ");
                        string adhar = Console.ReadLine();
                        Console.Write("Gender: ");
                        string gender = Console.ReadLine();
                        string berth = berths[rand.Next(berths.Length)];
                        double cost = selectedClassInfo.Cost;

                        string passQuery = @"insert into Passenger (BookingId, Name, Phone, AdharNumber, Gender, TrainNo, TrainName, TravelDate,Status, Berth,Cost)
                                 values (@BookingId, @Name, @Phone, @Adhar, @Gender, @TrainNo, @TrainName, @TravelDate,@Status, @Berth,@Cost)";
                        SqlCommand passCmd = new SqlCommand(passQuery, con);
                        passCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        passCmd.Parameters.AddWithValue("@Name", name);
                        passCmd.Parameters.AddWithValue("@Phone", phone);
                        passCmd.Parameters.AddWithValue("@Adhar", adhar);
                        passCmd.Parameters.AddWithValue("@Gender", gender);
                        passCmd.Parameters.AddWithValue("@TrainNo", selectedTrainNo);
                        passCmd.Parameters.AddWithValue("@TrainName", selectedTrainName);
                        passCmd.Parameters.AddWithValue("@TravelDate", doj);
                        passCmd.Parameters.AddWithValue("@Status", "Confirmed");
                        passCmd.Parameters.AddWithValue("@Berth", berth);
                        passCmd.Parameters.AddWithValue("@Cost", cost);

                        passCmd.ExecuteNonQuery();

                        Console.WriteLine($"Passenger {i + 1} booked. Berth: {berth}, Cost: {selectedClassInfo.Cost}");
                    }

                    string updateSeatsQuery = @"update TrainClasses
                                    set Available_Seats = Available_Seats - @Passengers
                                    where TrainNo = @TrainNo and Class = @Class";

                    SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, con);
                    updateCmd.Parameters.AddWithValue("@Passengers", numPassengers);
                    updateCmd.Parameters.AddWithValue("@TrainNo", selectedTrainNo);
                    updateCmd.Parameters.AddWithValue("@Class", selectedClass);
                    updateCmd.ExecuteNonQuery();

                    Console.WriteLine($"\nReservation successful! Booking ID: {bookingId}");
                    Console.WriteLine($"Grand Total for {numPassengers} passengers: {totalCost}");
                    Console.WriteLine("Status: Ticket Booked");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Inalid Date");
            }
        }

        

    }
}