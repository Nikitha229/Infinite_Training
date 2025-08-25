using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding_Challenge_9_Question_1.Models;

namespace Coding_Challenge_9_Question_1.Controllers
{
    public class CustomerController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomersInGermany(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return View("CustomersInGermany");
            }

            var customers = db.Customers
                              .Where(c => c.Country == country)
                              .ToList();

            return View("CustomersInGermany",customers);
        }


        public ActionResult CustomerByOrder(int? orderId)
        {
            if (orderId == null)
            {
                return View("CustomerByOrder");
            }

            var customer = db.Orders
                             .Where(o => o.OrderID == orderId)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            return View("CustomerByOrder", customer);
        }

    }
}
