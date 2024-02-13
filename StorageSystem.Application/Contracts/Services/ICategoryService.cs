using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using StorageSystem.Application.Models.Category.Ins;
using StorageSystem.Application.Models.Category.Outs;

namespace StorageSystem.Application.Contracts.Services
{
    public interface ICategoryService
    {
        Task<OneOf<IEnumerable<GetCategoryForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllCategories(Paging filter);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateCategory(CreateCategoryInsDto categoryDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateCategory(Guid categoryId, UpdateCategoryInsDto categoryDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteCategory(Guid id);

        Task<OneOf<GetCategoryForView, LocalizationErrorMessageOutDto, ValidationResult>> FindCategoryById(Guid id);
    }
}
