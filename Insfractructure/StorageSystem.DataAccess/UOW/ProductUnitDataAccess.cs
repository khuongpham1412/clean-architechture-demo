using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.DataAccess.UOW.Base;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW
{
    public class ProductUnitDataAccess : GenericDataAccess<ProductUnit>, IProductUnitDataAccess
    {
        public ProductUnitDataAccess(IApplicationDbContext context) : base(context)
        {
        }

        public Task CreateProductOfUnitAsync(ProductUnit productUnit, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CreateProductOfUnitRangeAsync(List<ProductUnit> productUnits, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductOfUnit(ProductUnit productUnit)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductOfUnitRange(List<ProductUnit> productUnits)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUnit> FindProductUnitById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductUnit>> GetAllProductUnit(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductUnit>> GetAllProductUnit(bool trackingReference, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductUnit>> GetProductsByProductIdsAndUnitIds(List<UpdateQuantityProductDto> list)
        {
            List<ProductUnit> a = _context.ProductUnits
                .Where(p => list.Select(a => a.ProductId).Contains(p.ProductId))
                .ToList();
            List<ProductUnit> b = a.Where(p => list.Select(a => a.UnitId).Contains(p.UnitId)).ToList();
            return b;
        }

        public void UpdateProductOfUnit(ProductUnit productUnit)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductOfUnitRange(List<ProductUnit> productUnits)
        {
            _context.ProductUnits.UpdateRange(productUnits);
        }

        public async Task<bool> UpdateProductQuantity(List<UpdateQuantityProductDto> list)
        {
            List<ProductUnit> a = _context.ProductUnits
                .Where(p => list.Select(a => a.ProductId).Contains(p.ProductId))
                .ToList();
            List<ProductUnit> b = a.Where(p => list.Select(a => a.UnitId).Contains(p.UnitId)).ToList();

            if (b.Any() && b.Count() != list.Count()) return false;

            foreach(var i in b)
            {
                foreach(var j in list)
                {
                    if(j.ProductId == i.ProductId && j.UnitId == i.UnitId)
                    {
                        i.Quantity = i.Quantity - j.Quantity;
                        if(i.Quantity < 0)
                        {
                            return false;
                        }
                    }
                }
            }

            UpdateProductOfUnitRange(b);
            return true;
        }
    }
}
