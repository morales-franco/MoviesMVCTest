using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Dtos
{
    public class MembershipTypeDto
    {
        public byte MembershipTypeID { get; set; }
        public string Name { get; set; }

        public byte DiscountRate { get; set; }
    }
}