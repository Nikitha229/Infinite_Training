using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Billing_Project
{
    public partial class ViewBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtN.Text);
            Code.ElectricityBoard board = new Code.ElectricityBoard();
            gvBills.DataSource = board.Generate_N_BillDetails(n);
            gvBills.DataBind();
        }

    }
}