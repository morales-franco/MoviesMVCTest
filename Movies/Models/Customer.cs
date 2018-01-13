using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Agrego navigation property
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        //Especifico FK - EF automaticamente reconoce que es la FK Relación

        public byte MembershipTypeID { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        /*
         * Una vez hecho los cambios en PK Manager
         * add-migration NAME
         * update-database
         */
    }
}