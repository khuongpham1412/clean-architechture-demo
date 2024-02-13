using Microsoft.EntityFrameworkCore.ChangeTracking;
using OneOf;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface IProductDataAccess : IGenericDataAccess<Product>
    {
        Task<Product> FirstOrDefaultAsync(Guid Id, CancellationToken cancellationToken = default);

        Task<Product> FirstAsync(Guid Id);

        Task CreateProductAsync(Product product, CancellationToken cancellationToken = default);

        Task CreateProductRangeAsync(List<Product> products, CancellationToken cancellationToken = default);

        void UpdateProduct(Product product, CancellationToken cancellationToken = default);

        void UpdateProductRange(List<Product> products, CancellationToken cancellationToken = default);

        void DeleteProduct(Product product, CancellationToken cancellationToken = default);

        void DeleteProductRange(List<Product> products, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>> GetAllProducts(Models.Bases.FilterProduct filter, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>> GetAllProducts(Models.Bases.FilterProduct filter, bool trackingReference, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>> GetProductsByCategoryId(Guid CategoryId, CancellationToken cancellationToken = default);

        Task<Product> FindProductById(Guid Id);

        int GetTotalProducts(string keyword = null, Guid? categoryId = null);

        Task<IEnumerable<Product>> GetAllProductsFromIds(List<Guid> ids);

        //Task<bool> UpdateQuantityProductsFromIds(List<UpdateQuantityProductDto> orders);
    }
}
