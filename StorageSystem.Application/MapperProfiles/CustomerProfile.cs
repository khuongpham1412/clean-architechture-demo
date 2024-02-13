using AutoMapper;
using StorageSystem.Application.Models.Customer.Ins;
using StorageSystem.Application.Models.Customer.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CreateCustomerInsDto, Customer>();
            CreateMap<UpdateCustomerInsDto, Customer>().ReverseMap();
            CreateMap<Customer, GetCustomerForView>().ReverseMap();
            CreateMap<Customer, CustomerList>().ReverseMap();
        }
    }
}
