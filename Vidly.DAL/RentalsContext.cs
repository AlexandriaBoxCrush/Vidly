using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.DAL.Objects;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Vidly.DAL
{
    public class RentalsContext : DbContext
    {

        public RentalsContext() : base("RentalsContext")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
