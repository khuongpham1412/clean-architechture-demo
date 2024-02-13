using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using OneOf;
using StorageSystem.Application.Contracts.Caches;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;

namespace StorageSystem.Application.Features.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductCaching _productCaching;
        public ProductService(ILogger<ProductService> logger, IUnitOfWork unitOfWork, IMapper mapper, IProductCaching productCaching) 
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productCaching = productCaching;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateProduct(CreateProductInsDto productDto)
        {
            _logger.LogInformation($"Start create product");
            Product product = _mapper.Map<Product>(productDto);
            try
            {
                await _unitOfWork.ProductDataAccess.CreateProductAsync(product);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create product {ex.Message}!");
                return false;
            }
            return true;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteProduct(Guid id)
        {
            var product = await _unitOfWork.ProductDataAccess.FindProductById(id);
            if (product != null)
            {
                try
                {
                    _logger.LogInformation($"Start delete product");
                    _unitOfWork.ProductDataAccess.DeleteProduct(product);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when delete product {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists product!", "400000")
                       }
                   );
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateProduct(Guid productId, UpdateProductInsDto productDto)
        {
            Product product = await _unitOfWork.ProductDataAccess.FindProductById(productId);
            if (product != null)
            {
                _logger.LogInformation($"Start update product");
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Description = productDto.Description;
                product.CategoryId = productDto.CategoryId;
                product.ThumbnailImage = productDto.ThumbnailImage;
                product.ProductImages = productDto.ProductImages;

                try
                {
                    _unitOfWork.ProductDataAccess.UpdateProduct(product);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when update product {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists product!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetProductForView, LocalizationErrorMessageOutDto, ValidationResult>> GetAllProducts(FilterProduct filter)
        {
            //await _productCaching.CachingProducts();
            //var a = _productCaching.GetCachingProducts();
            _logger.LogInformation("Start get all products!");
            IEnumerable<Product> products = await _unitOfWork.ProductDataAccess.GetAllProducts(filter,true);
            GetProductForView data = new GetProductForView();
            data.ProductLists = _mapper.Map<List<ProductList>>(products);
            data.Total = _unitOfWork.ProductDataAccess.GetTotalProducts(filter.Keyword, filter.CategoryId);
            return data;
        }

        public async Task<OneOf<GetProductForView, LocalizationErrorMessageOutDto, ValidationResult>> FindProductById(Guid id)
        {
            var result = await _unitOfWork.ProductDataAccess.FindProductById(id);
            if(result != null)
            {
                return _mapper.Map<GetProductForView>(result);
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists product!", "400000")
                       }
                   );
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteRangeProduct(List<Guid> ids)
        {
            var res = _unitOfWork.ProductDataAccess.GetAllProductsFromIds(ids);
            if(res.Result.Any())
            {
                if(ids.Count == res.Result.Count())
                {
                    try
                    {
                        _unitOfWork.ProductDataAccess.DeleteProductRange(res.Result.ToList());
                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error when delete product {ex.Message}!");
                        return false;
                    }
                    return true;
                }
                return new ValidationResult(
                           new List<ValidationFailure>
                           {
                                new ValidationFailure ("Have wrong when delete range product!", "400000")
                           }
                       );
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not product delete!", "400000")
                       }
                   );
        } 
    }
}
