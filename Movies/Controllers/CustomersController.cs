using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Movies.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
            base.Dispose(disposing);
        }

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
            return this._context.Customers.Include(c => c.MembershipType).ToList();
        }
    }
}