using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.DAL.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Vidly.BLL
{
    
    public class RentalsContext : DbContext
    {

        public RentalsContext(DbContextOptions<RentalsContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            string connectionString = "Data Source=LAPTOP-IUD4AQIP\\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True";
            
               optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            */

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>().ToTable("Movie");
            //modelBuilder.Entity<Customer>().ToTable("Customer");
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }










        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get connection string from configurations
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFail("appsettings.json")
                .Build();

            //set context to reference database in the connection string
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("?RentalContext?"));
        }
       

        public RentalsContext() : base("Data Source=LAPTOP-IUD4AQIP\\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True")
        {
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } */
    }
}

