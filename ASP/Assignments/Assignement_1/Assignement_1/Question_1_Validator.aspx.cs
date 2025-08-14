using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignement_1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (txtName.Text == txtFamilyName.Text)
                {
                    lblResult.Text = "Name and Family Name must be different.";
                }
                else
                {
                    lblResult.Text = "All validations passed!";
                }
            }
        }
    }
}


