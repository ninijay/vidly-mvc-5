using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public ViewResult Index()
        {
            var movies = GetMovies().ToList();

            return View(movies);    
        }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(g => g.Genre);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
           
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}