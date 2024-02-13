using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface IBillDataAccess : IGenericDataAccess<Bill>
    {
        Task CreateBillAsync(Bill bill, CancellationToken cancellationToken = default);

        Task CreateBillRangeAsync(List<Bill> bills, CancellationToken cancellationToken = default);

        void UpdateBill(Bill bill);

        void UpdateBillRange(List<Bill> bills);

        void DeleteBill(Bill bill);

        void DeleteBillRange(List<Bill> bills);

        Task<IEnumerable<Bill>> GetAllBills(CancellationToken cancellationToken = default);

        Task<IEnumerable<Bill>> GetAllBills(bool trackingReference, CancellationToken cancellationToken = default);

        Task<Bill> FindBillById(Guid Id);

        Task<Bill> FindBillById(Guid Id, bool trackingReference);
    }
}
