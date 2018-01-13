using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movies.ViewModels;

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

        public ViewResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerCrudVM()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var model = this.GetCustomers().FirstOrDefault(x => x.CustomerID == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerCrudVM()
            {
                MembershipTypes = membershipTypes,
                Customer = model
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerDB = _context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);

            //First Approach
            //Enfoque recomendado por Tutoriales Oficiales de Microsoft
            //Muchos issues
            //Actualiza todos los datos siempre (por ahi hay campos que no queres actualizar)
            //TryUpdateModel(customerDB);

            //Second Approach --> No recomendado por magic strings
            //Mapeamos con automapper solo las properties a actualizar entre customerDB y customer recibido de la vista
            //Solo actualizar los campos que necesitas
            //TryUpdateModel(customerDB, "", new string[] { "Name", "BirthDate" });

            //Third Approach--> Enfoque Recomendado
            //Mapeamos con automapper solo las properties a actualizar entre customerDB y customer recibido de la vista
            //Mapper.Map(customer, customerInDb)
            //SaveChanges()

            customerDB.Name = customer.Name;
            customerDB.BirthDate = customer.BirthDate;
            customerDB.MembershipTypeID = customer.MembershipTypeID;
            customerDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();

            return RedirectToAction("Index");
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