using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()

        {
            List<Customer> CustomerList = new List<Customer>();
            CustomerList.Add(new Customer() { Id = 100, Name = "Mosh" });
            CustomerList.Add(new Customer() { Id = 101, Name = "Mary" });
            CustomerList.Add(new Customer() { Id = 102, Name = "Rose" });
            CustomerList.Add(new Customer() { Id = 103, Name = "John" });
            CustomerList.Add(new Customer() { Id = 104, Name = "Harry" });

            return View(CustomerList);
        }
    }
}