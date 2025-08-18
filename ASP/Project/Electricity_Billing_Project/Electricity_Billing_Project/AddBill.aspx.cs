using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Billing_Project
{
    public partial class AddBill : System.Web.UI.Page
    {
        public string ValidateUnitsConsumed(int units)
        {
            return units < 0 ? "Given units is invalid" : "Valid";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtConsumerNumber.Text, @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");

                int units = int.Parse(txtUnits.Text);
                string validationMsg =ValidateUnitsConsumed(units);
                if (validationMsg != "Valid")
                {
                    lblResult.Text = validationMsg;
                    return;
                }
                ElectricityBill bill = new ElectricityBill
                {
                    ConsumerNumber = txtConsumerNumber.Text,
                    ConsumerName = txtConsumerName.Text,
                    UnitsConsumed = units
                };

                Code.ElectricityBoard board = new Code.ElectricityBoard();
                board.CalculateBill(bill);
                board.AddBill(bill);

                lblResult.Text = $"Bill Added: {bill.ConsumerNumber} {bill.ConsumerName} {bill.UnitsConsumed} Bill Amount: {bill.BillAmount}";
                txtConsumerNumber.Text= "";
                txtConsumerName.Text = "";
                txtUnits.Text= "";
            }
            catch (FormatException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBills.aspx");
        }
    }
}