using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Persistence;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;

    public IProductDataAccess ProductDataAccess { get; }

    public ICategoryDataAccess CategoryDataAccess { get; }

    public IBillDataAccess BillDataAccess { get; }

    public ICustomerDataAccess CustomerDataAccess { get; }

    public IOrderDataAccess OrderDataAccess { get; }

    public IUnitDataAccess UnitDataAccess {get;}

    public ISupplierDataAccess SupplierDataAccess {get;}

    public IProductUnitDataAccess ProductUnitDataAccess {get; }

    public UnitOfWork(
        IApplicationDbContext context,
        IProductDataAccess productDataAccess,
        ICategoryDataAccess categoryDataAccess,
        IBillDataAccess billDataAccess,
        ICustomerDataAccess customerDataAccess,
        IOrderDataAccess orderDataAccess,
        IUnitDataAccess unitDataAccess,
        ISupplierDataAccess supplierDataAccess,
        IProductUnitDataAccess productUnitDataAccess)
    {
        _context = context;
        ProductDataAccess = productDataAccess;
        CategoryDataAccess = categoryDataAccess;
        BillDataAccess = billDataAccess;
        CustomerDataAccess = customerDataAccess;
        OrderDataAccess = orderDataAccess;
        UnitDataAccess = unitDataAccess;
        SupplierDataAccess = supplierDataAccess;
        ProductUnitDataAccess = productUnitDataAccess;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void BeginTransaction()
    {
        //_context
    }

    public void TransactionCommit()
    {
        throw new NotImplementedException();
    }

    public void TransactionRollBack()
    {
        throw new NotImplementedException();
    }
}
