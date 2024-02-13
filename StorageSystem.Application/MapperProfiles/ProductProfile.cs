using AutoMapper;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<CreateProductInsDto, Product>();
            CreateMap<UpdateProductInsDto, Product>().ReverseMap();
            CreateMap<Product, GetProductForView>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<Product, ProductList>().ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        }
    }
}
