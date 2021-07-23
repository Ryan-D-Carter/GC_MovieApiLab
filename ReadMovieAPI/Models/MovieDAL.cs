using ReadMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReadMovieAPI.Controllers
{
    public class MovieDAL
    {
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44312/");
            return client;
        }


         #region Read
        public async Task<List<Movie>> GetMovies()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("/api/movie");
            var movies = await response.Content.ReadAsAsync<List<Movie>>();
            return movies;
        }
        #endregion


        #region Create
        public async Task AddMovie(Movie movie)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("/api/movie", movie);
        }
        #endregion

       


        public async Task<Movie> GetMovie(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"api/movie/{id}");
            var movie = await response.Content.ReadAsAsync<Movie>();
            return movie;
        }

        public async Task EditMovie(Movie editedMovie, int id)
        {
            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync($"/api/movie/{id}", editedMovie);
        }

        #region Delete
        public async Task DeleteMovie(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"/api/movie/{id}");
        }
        #endregion
    }
}