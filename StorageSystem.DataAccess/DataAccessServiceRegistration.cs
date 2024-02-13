using Microsoft.Extensions.DependencyInjection;
using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Features.Services;
using StorageSystem.DataAccess.UOW;
using StorageSystem.DataAccess.UOW.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServiceRegistration(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IProductDataAccess, ProductDataAccess>()
            .AddScoped<ICategoryDataAccess, CategoryDataAccess>()
            .AddScoped<IBillDataAccess, BillDataAccess>()
            .AddScoped<IOrderDataAccess, OrderDataAccess>()
            .AddScoped<ISupplierDataAccess, SupplierDataAccess>()
            .AddScoped<IUnitDataAccess, UnitDataAccess>()
            .AddScoped<IProductUnitDataAccess, ProductUnitDataAccess>()
            .AddScoped<ICustomerDataAccess, CustomerDataAccess>();
    }
}