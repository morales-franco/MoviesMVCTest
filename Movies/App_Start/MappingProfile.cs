using AutoMapper;
using Movies.Dtos;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.App_Start
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(m => m.CustomerID, opt => opt.Ignore());


        }


    }
}