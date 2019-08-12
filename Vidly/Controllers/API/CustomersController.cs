using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.BLL;
using Vidly.BLL.Dtos;
using Vidly.DAL.Objects;
using Vidly.ViewModels;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        //[AutoMap(typeof(Customer))]
        public async Task<ActionResult<IQueryable<CustomerDto>>> GetCustomers()
        {
            var customers = _context.Customers.Select(c =>
            new CustomerDto()
            {
                Id = c.Id,
                Name = c.Name,
                Birthdate = c.Birthdate,
                MembershipTypeId = c.MembershipTypeId,
                IsSubscribedToNewsletter = c.IsSubscribedToNewsletter
            }).ToList();//.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }


    //GET /api/customers/1
        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        public async Task<ActionResult<IQueryable<CustomerDto>>> GetCustomers(int id)
        {
            var customers = _context.Customers.Select(c =>
            new CustomerDto()
            {
                Id = c.Id,
                Name = c.Name,
                Birthdate = c.Birthdate,
                MembershipTypeId = c.MembershipTypeId,
                IsSubscribedToNewsletter = c.IsSubscribedToNewsletter
            }).SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

    //POST /api/customers
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(typeof(CustomerDto), 400)]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer) //return CustomerDto
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            _context.Entry(customer).Property(c => c.Name);
            var dto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                MembershipTypeId = customer.MembershipTypeId,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter
            };
            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, dto); //customerDto;
        }


    //PUT /api/customers/1
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(typeof(CustomerDto), 400)]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var dto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                MembershipTypeId = customer.MembershipTypeId,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter
            };

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, dto);
        }

    //DELETE /api/customers/1
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /*
         * 
         * OUTDATED SYNTAX FOR DTO
            //GET /api/customers/1
                [HttpGet("{id}", Name = "GetCustomer")]
                public ActionResult<CustomerDto> GetCustomer(int id)
                {
                    var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);
                    if (customer == null)
                        return NotFound();
                        //throw new Exception("404 Http Request Not Found");   //NotFound();
                    //throw new HttpResponse(CustomersController.NotFound);

                    return Ok(Mapper.Map<Customer, CustomerDto>(customer)); //Mapper doesnt like this line
                    //return customer;
                }

            //POST /api/customers
                [HttpPost]
                public async Task<IActionResult> CreateCustomer(CustomerDto customerDto) //return CustomerDto
                {
                    if (!ModelState.IsValid)
                        return BadRequest();
                        //throw new Exception("404 Http Request Not Found");

                    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                    await _context.Customers.AddAsync(customer);
                    _context.SaveChanges();
                    customerDto.Id = customer.Id;
                    return CreatedAtAction(nameof(customerDto), new { id = customer.Id }, customer); //customerDto;
                }

                //PUT /api/customers/1
                [HttpPut]
                public void UpdateCustomer(int id, CustomerDto customerDto)
                {
                    if (!ModelState.IsValid)
                        throw new Exception("404 Http Request Not Found");
                    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                    //var model = _mapper.Map<CustomerDto>(customerInDb);

                    if(customerInDb == null)
                        throw new Exception("404 Http Request Not Found");


                    Mapper.Map(customerDto, customerInDb);//parameters Idenitify the types so we dont need <CustomerDto, Customer >

                    //Mapper elminates the need for the following commented lines
                    //customerInDb.Name = customerDto.Name;
                    //customerInDb.Birthdate = customerDto.Birthdate;
                    //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
                    //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

                    _context.SaveChanges();

                }

            //DELETE /api/customers/1
                [HttpDelete]
                public void DeleteCustomer(int id)
                {
                    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                    if (customerInDb == null)
                        throw new Exception("404 Http Request Not Found");
                    _context.Customers.Remove(customerInDb);
                    _context.SaveChanges();
                }
            */

    }
}