using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess.Base;

public interface IBaseDataAccess : IDisposable
{
    Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class;

    Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class;

    Task<List<TEntity>> GetsAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class;

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}