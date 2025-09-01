using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10_Question_2.Models;
namespace CC10_Question_2.Controllers
{
    [RoutePrefix("api/orders")]
    public class CustomerController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("byempid")]
        public IHttpActionResult GetOrdersByEmployee(int Id)
        {

            var orders = db.Orders
                       .Where(o => o.EmployeeID == Id)
                       .Select(o => new
                       {
                           o.OrderID,
                           o.OrderDate,
                           o.CustomerID,
                           CompanyName = o.Customer.CompanyName,
                           ContactName = o.Customer.ContactName,
                           EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName
                       })
                       .ToList();

            return Ok(orders);

        }

        [HttpGet]
        [Route("country")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customerslist = db.GetCustomersByCountry(country).ToList();
            return Ok(customerslist);

        }


    }

}