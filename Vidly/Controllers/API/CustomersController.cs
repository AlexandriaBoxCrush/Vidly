using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.BLL;
using Vidly.DAL.Objects;
using Vidly.ViewModels;


namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly RentalsContext _context;
        public CustomersController(RentalsContext context)
        {
            _context = context;
        }


        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //GET /api/customers/1
        public Customer GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new Exception("404 Http Request Not Found");   //NotFound();
            //throw new HttpResponse(CustomersController.NotFound);

            return customer;
        }

    //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new Exception("404 Http Request Not Found");
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    //PUT /api/customers/1
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new Exception("404 Http Request Not Found");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new Exception("404 Http Request Not Found");
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

    }
}