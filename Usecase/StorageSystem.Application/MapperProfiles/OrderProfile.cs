using AutoMapper;
using StorageSystem.Application.Models.Order.Ins;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<CreateOrderInsDto, Order>();
            CreateMap<CreateOrderItemInsDto, Order>();
            CreateMap<UpdateOrderInsDto, Order>();
            CreateMap<UpdateOrderItemInsDto, Order>();
        }
    }
}
