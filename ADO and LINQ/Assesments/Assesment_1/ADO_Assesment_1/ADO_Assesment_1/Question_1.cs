using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assesment_1
{
    class Question_1
    {
        static void Main(string[] args)
        {
            Data da = new Data();
            da.Proc_InsertDetails_CalNetSalary();
            da.Display_Employee_Details();
            Console.Read();
        }
    }
    class Data
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

        public void Display_Employee_Details()
        {
            con = getconnection();
            SqlCommand cmd1 = new SqlCommand("select * from Employee_Details", con);

            Console.WriteLine("----------------------Employees Details----------------------------------");
            try
            {
                SqlDataReader dr = cmd1.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine($" EmpID= {dr["EmpId"]} Name={dr["Name"]} Gender={dr["Gender"]} Salary={dr["Salary"]} Net_Salary={dr["Net_Salary"]}");
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
            cmd = new SqlCommand("sp_InsertEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Enter Details to insert");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Salary: ");
            float salary = float.Parse(Console.ReadLine());

            SqlParameter name_Param = new SqlParameter();
            name_Param.ParameterName = "@name";
            name_Param.Value = name;
            name_Param.DbType = DbType.String;
            name_Param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(name_Param);

            SqlParameter gender_Param = new SqlParameter();
            gender_Param.ParameterName = "@gender";
            gender_Param.Value = gender;
            gender_Param.DbType = DbType.String;
            gender_Param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(gender_Param);

            SqlParameter salary_Param = new SqlParameter();
            salary_Param.ParameterName = "@sal";
            salary_Param.Value = salary;
            salary_Param.SqlDbType = SqlDbType.Float;
            salary_Param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(salary_Param);

            SqlParameter id_param = new SqlParameter();
            id_param.ParameterName = "@id";
            id_param.Direction = ParameterDirection.Output;
            id_param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(id_param);

            SqlParameter netsalary_param = new SqlParameter();
            netsalary_param.ParameterName = "@Netsal";
            netsalary_param.Direction = ParameterDirection.Output;
            netsalary_param.SqlDbType = SqlDbType.Float;
            cmd.Parameters.Add(netsalary_param);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Details Inserted Successfully!!");

            Console.WriteLine($"Net Salary: {netsalary_param.Value}");

        }
    }
}
