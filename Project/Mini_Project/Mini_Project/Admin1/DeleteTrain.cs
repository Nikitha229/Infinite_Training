using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class DeleteTrain
    {
        public static void fn_DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train Number to cancel: ");
                int trainNo = int.Parse(Console.ReadLine());

                using (SqlConnection conn = Connection.getconnection())
                {
                    SqlCommand cd = new SqlCommand($"select passengerid from passenger where trainno={trainNo}", conn);
                    SqlDataReader read = cd.ExecuteReader();
                    int c = 0;
                    while (read.Read())
                    {
                        c++;
                    }
                    read.Close();
                    if (c == 0)
                    {
                        string deleteClasses = "DELETE FROM TrainClasses WHERE TrainNo = @TrainNo";
                        string deleteTrain = "DELETE FROM Trains WHERE TrainNo = @TrainNo";

                        SqlCommand cmd1 = new SqlCommand(deleteClasses, conn);
                        SqlCommand cmd2 = new SqlCommand(deleteTrain, conn);

                        cmd1.Parameters.AddWithValue("@TrainNo", trainNo);
                        cmd2.Parameters.AddWithValue("@TrainNo", trainNo);

                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();

                        Console.WriteLine("Train and associated classes cancelled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Cannot delete the train, there are passengers booked for this train");
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
