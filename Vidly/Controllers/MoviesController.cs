﻿using System;
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


        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        //GET: Movies/Random
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


        [Route("movies/details")]
        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {

            return View();
        }

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