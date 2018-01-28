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
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto >();


            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.CustomerID, opt => opt.Ignore());

            Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(m => m.MembershipTypeID, opt => opt.Ignore());

        }


    }
}