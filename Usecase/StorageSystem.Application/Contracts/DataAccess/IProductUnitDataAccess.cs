using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface IProductUnitDataAccess : IGenericDataAccess<ProductUnit>
    {
        Task CreateProductOfUnitAsync(ProductUnit productUnit, CancellationToken cancellationToken = default);

        Task CreateProductOfUnitRangeAsync(List<ProductUnit> productUnits, CancellationToken cancellationToken = default);

        void UpdateProductOfUnit(ProductUnit productUnit);

        void UpdateProductOfUnitRange(List<ProductUnit> productUnits);

        void DeleteProductOfUnit(ProductUnit productUnit);

        void DeleteProductOfUnitRange(List<ProductUnit> productUnits);

        Task<IEnumerable<ProductUnit>> GetAllProductUnit(CancellationToken cancellationToken = default);

        Task<IEnumerable<ProductUnit>> GetAllProductUnit(bool trackingReference, CancellationToken cancellationToken = default);

        Task<ProductUnit> FindProductUnitById(Guid Id);

        Task<bool> UpdateProductQuantity(List<UpdateQuantityProductDto> list);

        Task<IEnumerable<ProductUnit>> GetProductsByProductIdsAndUnitIds(List<UpdateQuantityProductDto> list);
    }
}
