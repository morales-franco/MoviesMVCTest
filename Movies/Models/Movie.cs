using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }


        public Genre Genre { get; set; }
    }
}