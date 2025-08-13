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
            Console.Write("Enter Train Number to cancel: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = Connection.getconnection())
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
        }
    }
}
