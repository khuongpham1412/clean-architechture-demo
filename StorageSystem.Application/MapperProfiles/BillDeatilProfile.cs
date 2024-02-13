using AutoMapper;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    public class BillDetailProfile : Profile
    {
        public BillDetailProfile() 
        {
            CreateMap<CreateBillInsItemDto, BillDetail>();
            CreateMap<UpdateBillInsItemDto, BillDetail>();
            //.ForPath(dest => dest.BillId, opt => opt.MapFrom(src => src.Id))
            //.ForPath(dest => dest, opt => opt.MapFrom(src => src.Orders));

            //CreateMap<UpdateBillInsDto, BillDetail>()
            //    .ForMember(dest => dest.BillId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest, opt => opt.MapFrom(src => src.Items));
        }
    }
}
