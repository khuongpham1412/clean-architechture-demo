using AutoMapper;
using StorageSystem.Application.Models.Category.Ins;
using StorageSystem.Application.Models.Category.Outs;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateCategoryMapper();
        }

        private void CreateCategoryMapper()
        {
            CreateMap<CreateCategoryInsDto, Category>();
            CreateMap<UpdateCategoryInsDto, Category>();
            CreateMap<Category, GetCategoryForView>().ReverseMap();
        }
    }
}
