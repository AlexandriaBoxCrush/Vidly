using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vidly.BLL.Dtos;
using Vidly.DAL.Objects;

namespace Vidly.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            //Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            //var mapper = config.CreateMapper();
        }
    }
}
