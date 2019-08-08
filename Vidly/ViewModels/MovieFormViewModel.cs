using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.DAL.Objects;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Movie Title")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,20)]
        public int? NumberInStock { get; set; }



        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
                //if (Id !=0)
                //    return "Edit Movie";
                //return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Genre = movie.Genre;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}
