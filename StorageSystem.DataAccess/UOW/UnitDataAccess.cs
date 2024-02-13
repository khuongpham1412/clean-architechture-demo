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

public class UnitDataAccess : GenericDataAccess<Unit>, IUnitDataAccess
{
    public UnitDataAccess(IApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateUnitAsync(Unit unit, CancellationToken cancellationToken = default)
    {
        await InsertAsync(unit, cancellationToken);
    }

    public async Task CreateUnitRangeAsync(List<Unit> units, CancellationToken cancellationToken = default)
    {
        await _context.Units.AddRangeAsync(units, cancellationToken);
    }

    public void DeleteUnit(Unit unit)
    {
        unit.IsDeleted = true;
        _context.Units.Update(unit);
    }

    public void DeleteUnitRange(List<Unit> units)
    {
        _context.Units.RemoveRange(units);
    }

    public async Task<Unit> FindUnitById(Guid Id)
    {
        return await _context.Units.FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<IEnumerable<Unit>> GetAllUnits(CancellationToken cancellationToken = default)
    {
        return await _context.Units.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Unit>> GetAllUnits(bool trackingReference, CancellationToken cancellationToken = default)
    {
        return await _context.Units.ToListAsync(cancellationToken);
    }

    public void UpdateUnit(Unit unit)
    {
        _context.Units.Update(unit);
    }

    public void UpdateUnitRange(List<Unit> units)
    {
        _context.Units.UpdateRange(units);
    }
}
