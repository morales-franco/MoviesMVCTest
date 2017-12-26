using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
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
            return new List<Movie>{
                new Movie() { MovieID = 1, Name = "Movie 1"},
                new Movie() { MovieID = 2, Name = "Movie 2" },
                new Movie() { MovieID = 3, Name = "Movie 3" }
            };
        }

    }
}