using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.DAL.Objects;
using Vidly.ViewModels;
using Vidly.BLL;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly RentalsContext _context;
        public MoviesController(RentalsContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }


    //ACTIONS

    //SAVE
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0){
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    //EDIT
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return View();

            var viewModel = new MovieFormViewModel(movie)
            {
            };

            return View("MovieForm", viewModel);
        }

    //CREATE
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
            };

            return View("MovieForm", viewModel);
        }

    //DETAILS
        [Route("movies/details")]
        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return View();

            return View(movie);
        }




        //GET: Movies/Random
        /*
    public IActionResult Random()
    {
        var movie = new Movie() { Name = "Shrek!" };
        var customers = new List<Customer>
        {
            new Customer { Name = "Sarah Jane", Id = 1},
            new Customer { Name = "Tom Mick", Id = 2},
            new Customer { Name = "J.K. Rowling", Id = 3},
            new Customer { Name = "Jane Doe", Id = 4},
            new Customer { Name = "John Smith", Id = 5}

        };

    var viewModel = new RandomMovieViewModel
    {
        Movie = movie,
        Customers = customers
    };

        //ViewData["Movie"] = movie;
        //ViewBag.Movie = movie;
        //var viewResult = new ViewResult();
        //viewResult.ViewData.Model;

        return View(viewModel);

        //return Content("Hello World");
        //return new EmptyResult();
        //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
    }

    //Edit

    [Route("movies/edit")]
    [Route("movies/edit/{id}")]
    public ActionResult Edit(int id)
    {
        return Content("id=" + id);
    }



    [Route("movies/released")] //work 0/0
    [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")] //no work 404
    public ActionResult ByReleaseDate(int year, int month)
    {
        return Content(year + "/" + month);
    }
    */

        //movies
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        /*
        public ViewResult Index()
        {
            var movies = GetMovies();

             if (!pageIndex.HasValue)
             {
                 pageIndex = 1;
             }
             if (String.IsNullOrWhiteSpace(sortBy))
             {
                 sortBy = "Name";
             }
             return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy)); 
             
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Wall- e", Id = 1},
                new Movie { Name = "Shrek", Id = 2 },
                new Movie { Name = "Hot Fuzz", Id = 3 }
            };
        } */

    }
}