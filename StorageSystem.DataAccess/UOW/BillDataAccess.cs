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

public class BillDataAccess : GenericDataAccess<Bill>, IBillDataAccess
{
    public BillDataAccess(IApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateBillAsync(Bill bill, CancellationToken cancellationToken = default)
    {
        await InsertAsync(bill, cancellationToken);
    }

    public async Task CreateBillRangeAsync(List<Bill> bills, CancellationToken cancellationToken = default)
    {
        await _context.Bills.AddRangeAsync(bills, cancellationToken);
    }

    public void DeleteBill(Bill bill)
    {
        bill.IsDeleted = true;
        _context.Bills.Update(bill);
    }

    public void DeleteBillRange(List<Bill> bills)
    {
        _context.Bills.RemoveRange(bills);
    }

    public async Task<Bill> FindBillById(Guid Id)
    {
        return await _context.Bills.FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<Bill> FindBillById(Guid Id, bool trackingReference)
    {
        return await _context.Bills.Include(b => b.BillDetails).FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<IEnumerable<Bill>> GetAllBills(CancellationToken cancellationToken = default)
    {
        return await _context.Bills.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Bill>> GetAllBills(bool trackingReference, CancellationToken cancellationToken = default)
    {
        return await _context.Bills.ToListAsync(cancellationToken);
    }

    public void UpdateBill(Bill bill)
    {
        _context.Bills.Update(bill);
    }

    public void UpdateBillRange(List<Bill> bills)
    {
        _context.Bills.UpdateRange(bills);
    }
}
