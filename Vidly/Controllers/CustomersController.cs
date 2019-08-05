using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.DAL.Objects;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
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

