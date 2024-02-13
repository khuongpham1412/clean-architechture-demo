using Microsoft.EntityFrameworkCore;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Persistence.Contracts;

public interface IApplicationDbContext : IDisposable
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<BillDetail> BillDetails { get; set; }
    
    public DbSet<Coupon> Coupons { get; set; }
    
    public DbSet<CouponDetail> CouponDetails { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Supplier> Suppliers { get; set; }
    
    public DbSet<ProductSupplier> ProductSuppliers { get; set; }
    
    public DbSet<Unit> Units { get; set; }

    public DbSet<ProductUnit> ProductUnits { get; set; }

    public DbSet<T> Set<T>() where T : class;

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
