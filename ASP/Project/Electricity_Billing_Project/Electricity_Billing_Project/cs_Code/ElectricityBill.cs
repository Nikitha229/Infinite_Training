using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electricity_Billing_Project
{
    public class ElectricityBill
    {
        public string ConsumerNumber { get; set; }
        public string ConsumerName { get; set; }
        public int UnitsConsumed { get; set; }
        public double BillAmount { get; set; }

    }

}