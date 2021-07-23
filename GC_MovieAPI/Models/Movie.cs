using System;
using System.Collections.Generic;

#nullable disable

namespace GC_MovieAPI.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double? Runtime { get; set; }
    }
}
