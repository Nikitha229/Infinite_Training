using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Electricity_Billing_Project.Code
{


    public class DBConnection
    {
        static SqlConnection con = null;
        public SqlConnection GetConnection()
        {
            string connect = "Data Source=ICS-LT-DJ24D64\\SQLEXPRESS;Initial Catalog=Electricity_DB;" +
                "User id=sa;password= Nikitha@12345;";
            con = new SqlConnection(connect);
            //con.Open();
            return con;
        }
    }

}