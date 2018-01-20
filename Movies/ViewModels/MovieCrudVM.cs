using Movies.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class MovieCrudVM
    {
        public int MovieID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate  { get; set; }

        [Required]
        public int GenreID { get; set; }

        [Required]
        [IsThanZero]
        public int NumberInStock { get; set; }
    }
}