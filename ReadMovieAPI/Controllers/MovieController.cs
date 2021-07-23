using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadMovieAPI.Models;

namespace ReadMovieAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDAL _movies = new MovieDAL();

        public async Task<IActionResult> Index()
        {
            var movies = await _movies.GetMovies();
            return View(movies);
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movies.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MovieForm(int id)
        {
            if (id == 0)
            {
                return View(new Movie());
            }
            else
            {
                var movie = await _movies.GetMovie(id);
                return View(movie);
            }
        }

       
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movies.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View("MovieForm", movie);
        }

        
        public async Task<IActionResult> EditMovie(int id, Movie editedMovie)
        {
            if (ModelState.IsValid)
            {
                await _movies.EditMovie(editedMovie, id);
            }
            return RedirectToAction("Index");
        }
    }
}