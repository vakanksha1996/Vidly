using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieViewModel
    {
        public Movie movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}