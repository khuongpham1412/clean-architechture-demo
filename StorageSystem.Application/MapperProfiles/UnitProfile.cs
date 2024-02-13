using AutoMapper;
using StorageSystem.Application.Models.Unit.Ins;
using StorageSystem.Application.Models.Unit.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    internal class UnitProfile : Profile
    {
        public UnitProfile()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateUnitMapper();
        }

        private void CreateUnitMapper()
        {
            CreateMap<CreateUnitInsDto, Unit>();
            CreateMap<UpdateUnitInsDto, Unit>();
            CreateMap<Unit, GetUnitForView>().ReverseMap();
        }
    }
}