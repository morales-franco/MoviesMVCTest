using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var model = this.GetMovies();
            return View(model);
        }

        public ContentResult ByReleaseDate(int month, int year)
        {
            string result = string.Format("By Month {0} / Year {1}", month, year);
            return Content(result);
        }

        //http://localhost:52616/movies/Released2/13/2 ERROR
        //http://localhost:52616/movies/Released2/12/2 VALID
        [Route("movies/released2/{month:regex(\\d{2}):range(1,12)}/{year}")]
        public ContentResult ByReleaseDate2(int month, int year)
        {
            string result = string.Format("By Month {0} / Year {1} (2)", month, year);
            return Content(result);
        }

        // GET: Customers
        public ViewResult Details(int id)
        {
            var model = this.GetMovies().FirstOrDefault(x => x.MovieID == id);
            return View(model);
        }

        private List<Movie> GetMovies()
        {
            return this._context.Movies.Include(c => c.Genre).ToList();
        }

    }
}