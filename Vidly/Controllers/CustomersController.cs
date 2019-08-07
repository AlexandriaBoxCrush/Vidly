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

        //private ApplicationDbContext _context;
        //private DbContext _context;
        private CustomersController()
        {
            //_context = new ApplicationDbContext();
            //_context = new DbContext(); //Cannot access DbContext with no parameters
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public IActionResult Index()
        {
            var customer = GetCustomers();
            return View(customer);
        }


        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return View();

            return View(customer);
        }


        //HARD CODED
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
        }
    }
}

