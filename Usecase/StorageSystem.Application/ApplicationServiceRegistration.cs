using Microsoft.Extensions.DependencyInjection;
using StorageSystem.Application.Contracts.Features.Auths;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Features.Auths;
using StorageSystem.Application.Features.Services;
using StorageSystem.Application.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
        {
            //services.AddAutoMapper(c => c.AddProfile<AutoMapper>(), typeof(Program));
            //services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Program));
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            services.AddAutoMapper(typeof(CategoryProfile).Assembly);
            services.AddAutoMapper(typeof(BillDetailProfile).Assembly);
            services.AddAutoMapper(typeof(BillProfile).Assembly);
            services.AddAutoMapper(typeof(CustomerProfile).Assembly);
            services.AddAutoMapper(typeof(UnitProfile).Assembly);
            services.AddAutoMapper(typeof(OrderProfile).Assembly);
            services.AddAutoMapper(typeof(SupplierProfile).Assembly);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IUnitService, UnitService>();
            //services.AddScoped<IProductImageService, ProductImageService>();
            //services.AddTransient<Irepository<Product>, ProductRepository>();

            return services;
        }
    }
}
