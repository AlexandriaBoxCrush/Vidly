using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.DAL.Objects;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Movie> Movies{ get; set; }
    }
}
