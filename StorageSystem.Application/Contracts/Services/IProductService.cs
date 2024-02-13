using OneOf;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Domain.Entities;
using StorageSystem.Application.Models.Bases;
using FluentValidation.Results;

namespace StorageSystem.Application.Contracts.Services
{
    public interface IProductService
    {
        Task<OneOf<GetProductForView, LocalizationErrorMessageOutDto, ValidationResult>> GetAllProducts(FilterProduct filter);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateProduct(CreateProductInsDto productDto);
        
        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateProduct(Guid productId, UpdateProductInsDto productDto);
        
        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteProduct(Guid id);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteRangeProduct(List<Guid> ids);

        Task<OneOf<GetProductForView, LocalizationErrorMessageOutDto, ValidationResult>> FindProductById(Guid id);
    }
}
