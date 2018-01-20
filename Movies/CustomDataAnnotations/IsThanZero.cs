using Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.CustomDataAnnotations
{
    public class IsThanZero : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (MovieCrudVM)validationContext.ObjectInstance;

            if (movie.NumberInStock > 0)
                return ValidationResult.Success;

            return new ValidationResult("The number in stock must be than zero");

        }

    }
}