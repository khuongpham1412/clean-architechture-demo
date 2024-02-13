using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using OneOf;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Category.Ins;
using StorageSystem.Application.Models.Category.Outs;
using StorageSystem.Application.Models.Product.Base;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Features.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(ILogger<CategoryService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateCategory(CreateCategoryInsDto categoryDto)
        {
            _logger.LogInformation($"Start create category");
            Category category = _mapper.Map<Category>(categoryDto);
            try
            {
                await _unitOfWork.CategoryDataAccess.CreateCategoryAsync(category);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create category {ex.Message}, {ex.InnerException}!");
                return false;
            }
            return true;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteCategory(Guid id)
        {
            var category = await _unitOfWork.CategoryDataAccess.FindCategoryById(id);
            if (category != null)
            {
                try
                {
                    _logger.LogInformation($"Start delete category");
                    _unitOfWork.CategoryDataAccess.DeleteCategory(category);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when delete category {ex.Message}, {ex.InnerException}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists category!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetCategoryForView, LocalizationErrorMessageOutDto, ValidationResult>> FindCategoryById(Guid id)
        {
            var result = await _unitOfWork.CategoryDataAccess.FindCategoryById(id);
            if (result != null)
            {
                return _mapper.Map<GetCategoryForView>(result);
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists category!", "400000")
                       }
                   );
        }

        public async Task<OneOf<IEnumerable<GetCategoryForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllCategories(Paging filter)
        {
            IEnumerable<Category> categories = await _unitOfWork.CategoryDataAccess.GetAllCategories(true);
            IEnumerable<GetCategoryForView> data = _mapper.Map<IEnumerable<GetCategoryForView>>(categories);
            return data.ToList();
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateCategory(Guid categoryId, UpdateCategoryInsDto categoryDto)
        {
            Category category = await _unitOfWork.CategoryDataAccess.FindCategoryById(categoryId);
            if (category != null)
            {
                _logger.LogInformation($"Start update category");
                //category.Name = categoryDto.Name;

                try
                {
                    _unitOfWork.CategoryDataAccess.UpdateCategory(category);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when update category {ex.Message}, {ex.InnerException}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists category!", "400000")
                       }
                   );
        }
    }
}
