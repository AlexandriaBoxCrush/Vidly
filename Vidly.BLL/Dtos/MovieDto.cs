using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Vidly.DAL.Objects;

namespace Vidly.BLL.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
    }
}
