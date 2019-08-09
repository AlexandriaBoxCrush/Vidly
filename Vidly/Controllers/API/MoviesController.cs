using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.BLL;
using Vidly.BLL.Dtos;
using Vidly.DAL.Objects;
using Vidly.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly RentalsContext _context;
        public MoviesController(RentalsContext context)
        {
            _context = context;
        }


    //GET /api/movies
        [HttpGet]
        public async Task<ActionResult<IQueryable<CustomerDto>>> GetMovies()
        {
            var movies = _context.Movies.Select(c =>
            new MovieDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return Ok(movies);
        }


    //GET /api/movies/1
        [HttpGet("{id}", Name = "GetMovie")]
        [ProducesResponseType(typeof(MovieDto), 201)]
        public async Task<ActionResult<IQueryable<MovieDto>>> GetMovies(int id)
        {
            var movies = _context.Movies.Select(c =>
            new MovieDto()
            {
                Id = c.Id,
                Name = c.Name
            }).SingleOrDefault(c => c.Id == id);

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

    //POST /api/movies
        [HttpPost]
        [ProducesResponseType(typeof(MovieDto), 201)]
        [ProducesResponseType(typeof(MovieDto), 400)]
        public async Task<ActionResult<Movie>> CreateCustomer(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            _context.Entry(movie).Property(c => c.Name);
            var dto = new MovieDto()
            {
                Id = movie.Id,
                Name = movie.Name
            };
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, dto);
        }


        //PUT /api/movies/1
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MovieDto), 201)]
        [ProducesResponseType(typeof(MovieDto), 400)]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var dto = new CustomerDto()
            {
                Id = movie.Id,
                Name = movie.Name
            };

            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, dto);
        }

        //DELETE /api/customers/1

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movies = await _context.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}