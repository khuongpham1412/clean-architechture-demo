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
    public class BillProfile : Profile
    {
        public BillProfile() 
        {
            CreateMap<CreateBillInsDto, Bill>();
            //CreateMap<UpdateBillInsDto, BillDetail>();
        }
    }
}
