using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
         private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public IHttpActionResult NewRentalForm(RentalDto NewRental)
        {
            var customer = _context.Customers;

           // var customer = _context.Customers.Single(c => c.Id == NewRental.CustomerId);
            var movies = _context.Movies.Where(m => NewRental.MovieIds.Contains(m.Id)).ToList();

            
            foreach (var movie in movies)
            {
                
                if (movie.NumberAvailable == 0)
                {
                    
                    return BadRequest(movie.Name+" is not availbale");
                
                }
                movie.NumberAvailable--;
                
                var rental = new Rental()
                {
                  //  Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
                
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
