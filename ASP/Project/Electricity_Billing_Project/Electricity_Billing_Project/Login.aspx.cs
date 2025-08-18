using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Billing_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "admin" && txtPass.Text == "admin123")
            {
                Response.Redirect("AddBill.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials!";
            }

        }
    }
}