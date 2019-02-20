using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
        
    {
       private  ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [OutputCache(Duration = 50)]
        public ActionResult Index()

        {
           
            return View();
        }

        public ActionResult Details(int id)
        { 
          Customer customer=  _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c=>c.Id==id);
                    
            return View(customer);
        }
       
        public ActionResult New()
        {
            var MembershipTypes = _context.MemberShipTypes.ToList();

            var Viewmodel = new CustomerViewModel
            { 
                customer = new Customer(),
                MemberShipTypes = MembershipTypes
            

            };
            return View(Viewmodel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel
                {
                    customer=customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("New", ViewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate= customer.Birthdate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedTonewsLetter = customer.IsSubscribedTonewsLetter;

            }
            System.Diagnostics.Debug.WriteLine("hello");
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.Single(c => c.Id == id);
            var ViewModel = new CustomerViewModel
            {
                customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()

            };
           

            return View("New",ViewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}