using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }
        //GET  Api/Customer
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {

            var customersQuery = _context.Customers
                .Include(m => m.MemberShipType);
            if (!string.IsNullOrWhiteSpace(query)) 
            customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customers = customersQuery.ToList()
            .Select(Mapper.Map<Customer, CustomerDto>);
        
            return Ok(customers);
        }

        //Get Api/Customer/1
        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //Post Api/Customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return customerdto;
        }

        //Put Api/Customer/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerdto)
        {
            var CustomerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            CustomerInDB.Name = customerdto.Name;
            CustomerInDB.Birthdate = customerdto.Birthdate;
            CustomerInDB.MemberShipTypeId = customerdto.MemberShipTypeId;
            CustomerInDB.IsSubscribedTonewsLetter = customerdto.IsSubscribedTonewsLetter;
            _context.SaveChanges();

        }

        //Delete Api/Customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
