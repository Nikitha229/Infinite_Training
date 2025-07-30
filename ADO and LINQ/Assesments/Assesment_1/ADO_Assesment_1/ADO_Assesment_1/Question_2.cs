using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assesment_1
{
    class Question_2
    {
        public static void Main()
        {
            Data1 da = new Data1();
            da.Proc_InsertDetails_CalNetSalary();
            Console.Read();
        }
    }
    class Data1
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;

        public SqlConnection getconnection()
        {
            string connect = "Data Source=ICS-LT-DJ24D64\\SQLEXPRESS;Initial Catalog=Assesments;" +
                "User id=sa;password= Nikitha@12345;";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

        public void Display_Employee_Details(int empid)
        {
            con = getconnection();
            SqlCommand cmd1 = new SqlCommand($"select EmpId,name,salary from Employee_Details where empid={empid}", con);

            Console.WriteLine("----------------------Employee Details----------------------------------");
            try
            {
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" EmpID= {dr["EmpId"]} Name={dr["Name"]} Salary={dr["Salary"]} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public void Proc_InsertDetails_CalNetSalary()
        {
            con = getconnection();
            cmd = new SqlCommand("sp_SalaryIncrement", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter Employee Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlParameter id_param = new SqlParameter();
            id_param.ParameterName = "@id";
            id_param.Value = id;
            id_param.Direction = ParameterDirection.Input;
            id_param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(id_param);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Details Updated Successfully!!");

            Display_Employee_Details(id);

        }
    }
}
