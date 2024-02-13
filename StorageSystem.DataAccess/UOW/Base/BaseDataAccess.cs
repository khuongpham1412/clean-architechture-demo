using Microsoft.EntityFrameworkCore;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW.Base;

public abstract class BaseDataAccess : IBaseDataAccess
{
    protected ApplicationDbContext _context { get; }

    protected BaseDataAccess(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        var dbSet = _context.Set<TEntity>();
        var entityEntry = await dbSet.AddAsync(entity);

        return entityEntry.Entity;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        var result = _context.Set<TEntity>().AsNoTracking();

        if (predicate != null)
        {
            result = result.Where(predicate);
        }

        return await result.FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetsAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        var result = _context.Set<TEntity>().AsTracking();
        if (predicate != null)
        {
            result = result.Where(predicate);
        }
        return await result.ToListAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}