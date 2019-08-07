using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Vidly.DAL.Objects;

namespace Vidly.BLL
{
    public class RentalInitializer //: System.Data.Entity.DropCreateDatabaseIfModelChanges<RentalsContext>
    {
        public static void Initialize(RentalsContext context)
        {
            context.Database.EnsureCreated();

            //Look for Movies
            if (context.Movies.Any())
            {
                return;
            }

            var movies = new Movie[]
            {
                new Movie{ Name = "Wall-e", Id = 1},
                new Movie{ Name = "A New Hope", Id = 2},
                new Movie{ Name = "Return of the Jedi", Id = 3},
                new Movie{ Name = "Black Spot", Id = 4},
                new Movie{ Name = "Wreck-It-Ralph", Id = 5}
            };

            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer { Name = "Sarah Jane", Id = 1},
                new Customer { Name = "Tom Mick", Id = 2},
                new Customer { Name = "J.K. Rowling", Id = 3},
                new Customer { Name = "Jane Doe", Id = 4},
                new Customer { Name = "John Smith", Id = 5}

            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }

    }
}
