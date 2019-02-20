using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,10)]
        [Display(Name="Number In Stock")]
        public int NumberInStock{ get; set; }

        public byte NumberAvailable { get; set; }
        public Genre Genre { get; set; }
        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }
    }
}