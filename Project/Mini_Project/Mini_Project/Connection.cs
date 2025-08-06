using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Connection
    {
        static SqlConnection con = null;

        public static SqlConnection getconnection()
        {
            string connect = "Data Source=ICS-LT-DJ24D64\\SQLEXPRESS;Initial Catalog=Railway_DB;" +
                "User id=sa;password= Nikitha@12345;";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

    }
}
