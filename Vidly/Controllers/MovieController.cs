using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()

        {
            if (User.IsInRole("CanManageMovies")) 
            return View();
            return View("ReadOnlyList");
        }
        public ActionResult Details(int id) 
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==id);

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();

            var Viewmodel = new MovieViewModel
            {
                
                Genres = Genres


            };
            return View(Viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.DateAdded = movie.DateAdded;
                MovieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
            
        }
        public ActionResult  Edit(int id)
        {
          var  movie= _context.Movies.Single(m => m.Id == id);
            var ViewModel = new MovieViewModel
            {
                movie = movie,
                Genres = _context.Genres.ToList()

            };
            return View("New",ViewModel);
        }
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return Content("Not Found");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

    }
}