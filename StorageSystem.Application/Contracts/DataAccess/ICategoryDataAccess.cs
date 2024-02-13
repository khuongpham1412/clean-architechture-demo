using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface ICategoryDataAccess : IGenericDataAccess<Category>
    {
        Task CreateCategoryAsync(Category category, CancellationToken cancellationToken = default);

        Task CreateCategoryRangeAsync(List<Category> categories, CancellationToken cancellationToken = default);

        void UpdateCategory(Category category);

        void UpdateCategoryRange(List<Category> categories);

        void DeleteCategory(Category category);

        void DeleteCategoryRange(List<Category> categories);

        Task<IEnumerable<Category>> GetAllCategories(CancellationToken cancellationToken = default);

        Task<IEnumerable<Category>> GetAllCategories(bool trackingReference, CancellationToken cancellationToken = default);

        Task<Category> FindCategoryById(Guid Id);
    }
}
