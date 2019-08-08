using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DAL.Objects
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Movie Title")]
        public string Name { get; set; }

        // DETAILS MIGRATION
        public string Genre { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

    }
}
