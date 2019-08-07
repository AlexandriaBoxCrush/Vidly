using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.BLL;
using Vidly.DAL.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        //private DbContext _context;
        /*private CustomersController()
        {
            _context = new DbContext(DbContextOptions < DbContext > options) : base(options);
        }
        protected override void Dispose(bool disposing)
        {
           //_context.Dispose();
        }*/

        private readonly RentalsContext _context;
        public CustomersController(RentalsContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }


        /*
        public IActionResult Index()
        {
            var customer = GetCustomers(); //RentalsContext.Customers;  //
            return View(customer);
        } 

    */


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return View();

            return View(customer);
        }


        //HARD CODED
        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ Id = 1, Name = "Monica"},
                new Customer{ Id = 2, Name = "Fibi"},
                new Customer{ Id = 3, Name = "Ross"},
                new Customer{ Id = 4, Name = "Rachel"},
                new Customer{ Id = 5, Name = "Joey"},
                new Customer{ Id = 6, Name = "Chandler"}

            };
        } */
    }
}

