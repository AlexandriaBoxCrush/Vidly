using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Vidly.DAL.Objects;

namespace Vidly.BLL
{
    public static class RentalInitializer 
    {
        public static void Initialize(RentalsContext context)
        {
            context.Database.EnsureCreated();

            System.Diagnostics.Debug.WriteLine("In Init");
            //Look for Movies
            if (context.Customers.Any() || context.Movies.Any() )
            {
               return; //DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer { Name = "Sarah Jane", MembershipTypeId = 1, IsSubscribedToNewsletter=false},
                new Customer { Name = "Tom Mick", MembershipTypeId = 2, IsSubscribedToNewsletter=false},
                new Customer { Name = "J.K. Rowling", MembershipTypeId = 2, IsSubscribedToNewsletter=true},
                new Customer { Name = "Jane Doe", MembershipTypeId = 3, IsSubscribedToNewsletter=false},
                new Customer { Name = "John Smith", MembershipTypeId = 3, IsSubscribedToNewsletter=true}

            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie{ Name = "Wall-e"},
                new Movie{ Name = "A New Hope"},
                new Movie{ Name = "Return of the Jedi"},
                new Movie{ Name = "Black Spot"},
                new Movie{ Name = "Wreck-It-Ralph"}
            };

            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }

    }
}
