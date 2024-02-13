using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface IUnitDataAccess : IGenericDataAccess<Unit>
    {
        Task CreateUnitAsync(Unit unit, CancellationToken cancellationToken = default);

        Task CreateUnitRangeAsync(List<Unit> units, CancellationToken cancellationToken = default);

        void UpdateUnit(Unit unit);

        void UpdateUnitRange(List<Unit> units);

        void DeleteUnit(Unit unit);

        void DeleteUnitRange(List<Unit> units);

        Task<IEnumerable<Unit>> GetAllUnits(CancellationToken cancellationToken = default);

        Task<IEnumerable<Unit>> GetAllUnits(bool trackingReference, CancellationToken cancellationToken = default);

        Task<Unit> FindUnitById(Guid Id);
    }
}