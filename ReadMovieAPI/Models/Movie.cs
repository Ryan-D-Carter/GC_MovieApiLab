using System;

namespace ReadMovieAPI.Models
{
    public class Movie
    {
        public class MovieRootObject
        {
            public Movie[] Movies { get; set; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double? Runtime { get; set; }
    }
}