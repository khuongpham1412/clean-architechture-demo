using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface ISupplierDataAccess : IGenericDataAccess<Supplier>
    {
        Task CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);

        Task CreateSupplierRangeAsync(List<Supplier> suppliers, CancellationToken cancellationToken = default);

        void UpdateSupplier(Supplier supplier);

        void UpdateSupplierRange(List<Supplier> suppliers);

        void DeleteSupplier(Supplier supplier);

        void DeleteSupplierRange(List<Supplier> suppliers);

        Task<IEnumerable<Supplier>> GetAllSuppliers(CancellationToken cancellationToken = default);

        Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackingReference, CancellationToken cancellationToken = default);

        Task<Supplier> FindSupplierById(Guid Id);
    }
}