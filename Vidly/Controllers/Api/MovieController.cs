using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //Get  Api/Movie
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                   .Include(m => m.Genre);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
               
            }
            var movies = moviesQuery.ToList()
            .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }
        //Get  Api/Movie/1
        [HttpGet]
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var moviedto = Mapper.Map<Movie, MovieDto>(movie);
            return moviedto;
        }

        //Post  Api/Movie
        [HttpPost]
        public MovieDto CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            moviedto.Id = movie.Id;

            return moviedto;

        }

        //Put Api/Movie/1
        [HttpPut]
        public void UpdateMovie(int id,MovieDto moviedto)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Mapper.Map(moviedto, movie);
            _context.SaveChanges();


        }

        //Delete  Api/Movie/1
        [HttpDelete]
          public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

        }
    }
}
