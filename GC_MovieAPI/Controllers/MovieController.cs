using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_MovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GC_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieLabContext _context;

        public MovieController(MovieLabContext context)
        {
            _context = context;
        }

        #region Read
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return movie;
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                await _context.Movies.AddAsync(newMovie);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);
            }
            else
                return BadRequest();
        }

        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, Movie updatedMovie)
        {
            if (!ModelState.IsValid || id != updatedMovie.Id)
            {
                return BadRequest();
            }
            else
            {
                var foundMovie = _context.Movies.Find(id);
                foundMovie.Title = updatedMovie.Title;
                foundMovie.Genre = updatedMovie.Genre;
                foundMovie.Runtime = updatedMovie.Runtime;

                _context.Entry(foundMovie).State = EntityState.Modified;
                _context.Update(foundMovie);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        #endregion

    }
}
