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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET api/customers/1
        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;

        }

        //POST api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer entity = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            entity.Name = customer.Name;
            entity.BirthDate = customer.BirthDate;
            entity.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            entity.MembershipTypeID = customer.MembershipTypeID;


            _context.SaveChanges();

        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer entity = _context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }


    }
}
