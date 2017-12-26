using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var model = this.GetCustomers();
            return View(model);
        }


        public ViewResult Details(int id)
        {
            var model = this.GetCustomers().FirstOrDefault(x => x.CustomerID == id);
            return View(model);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>{
                new Customer() { CustomerID = 1, Name="Customer 1"},
                new Customer() { CustomerID = 2, Name = "Customer 2" },
                new Customer() { CustomerID = 3, Name = "Customer 3" }
            };
        }
    }
}