using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Vidly.DAL.Objects;

namespace Vidly.DAL
{
    public class RentalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RentalsContext>
    {
        protected override void Seed(RentalsContext context)
        {
            var movies = new List<Movie>
            {
                new Movie{ Name = "Wall-e", Id = 1},
                new Movie{ Name = "A New Hope", Id = 2},
                new Movie{ Name = "Return of the Jedi", Id = 3},
                new Movie{ Name = "Black Spot", Id = 4},
                new Movie{ Name = "Wreck-It-Ralph", Id = 5}
            };

            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer { Name = "Sarah Jane", Id = 1},
                new Customer { Name = "Tom Mick", Id = 2},
                new Customer { Name = "J.K. Rowling", Id = 3},
                new Customer { Name = "Jane Doe", Id = 4},
                new Customer { Name = "John Smith", Id = 5}

            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var rentals = new List<Rental>
            {
                new Rental { MovieId = 1, CustomerId = 1, RentalId = 1 },
                new Rental { MovieId = 2, CustomerId = 1, RentalId = 2 },
                new Rental { MovieId = 1, CustomerId = 2, RentalId = 3 },
                new Rental { MovieId = 3, CustomerId = 2, RentalId = 4 },
                new Rental { MovieId = 2, CustomerId = 3, RentalId = 5 },
                new Rental { MovieId = 2, CustomerId = 4, RentalId = 6 },
                new Rental { MovieId = 5, CustomerId = 4, RentalId = 7 },
                new Rental { MovieId = 1, CustomerId = 5, RentalId = 8 },
                new Rental { MovieId = 4, CustomerId = 5, RentalId = 9 },
                new Rental { MovieId = 5, CustomerId = 5, RentalId = 10 }
            };

            rentals.ForEach(r => context.Rentals.Add(r));
            context.SaveChanges();
        }
    }
}
