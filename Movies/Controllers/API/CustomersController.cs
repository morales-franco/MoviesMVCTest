using AutoMapper;
using Movies.Dtos;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movies.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        // GET api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList()
                                     .Select(Mapper.Map<Customer, CustomerDto>));
        }

        // GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = Mapper.Map<CustomerDto, Customer> (customer);

            _context.Customers.Add(entity);
            _context.SaveChanges();

            customer.CustomerID = entity.CustomerID;

            //Convencion REST retorna en el header la nueva ubicación del recurso
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerID), customer);

        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer entity = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (entity == null)
                return NotFound();

            Mapper.Map(customer, entity);

            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer entity = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (entity == null)
                return NotFound();

            _context.Customers.Remove(entity);
            _context.SaveChanges();

            return Ok();
        }


    }
}
