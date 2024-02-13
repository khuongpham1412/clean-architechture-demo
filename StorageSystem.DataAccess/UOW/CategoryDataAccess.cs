using Microsoft.EntityFrameworkCore;
using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.DataAccess.UOW.Base;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW;

public class CategoryDataAccess : GenericDataAccess<Category>, ICategoryDataAccess
{
    public CategoryDataAccess(IApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateCategoryAsync(Category category, CancellationToken cancellationToken = default)
    {
        await InsertAsync(category, cancellationToken);
    }

    public async Task CreateCategoryRangeAsync(List<Category> categories, CancellationToken cancellationToken = default)
    {
        await _context.Categories.AddRangeAsync(categories, cancellationToken);
    }

    public void DeleteCategory(Category category)
    {
        //_context.Categories.Remove(category);
        category.IsDeleted = true;
        _context.Categories.Update(category);
    }

    public void DeleteCategoryRange(List<Category> categories)
    {
        _context.Categories.RemoveRange(categories);
    }

    public async Task<Category> FindCategoryById(Guid Id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<IEnumerable<Category>> GetAllCategories(CancellationToken cancellationToken = default)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllCategories(bool trackingReference, CancellationToken cancellationToken = default)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }

    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
    }

    public void UpdateCategoryRange(List<Category> categories)
    {
        _context.Categories.UpdateRange(categories);
    }
}
