using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using StorageSystem.Application.Contracts.Caches;
using StorageSystem.Application.Providers;
using StorageSystem.Cache.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Cache
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection AddStackExchangeRedisExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = configuration.GetSection("Redis").Get<RedisConfiguration>();
            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

            services.AddSingleton<ICacheConnection, CacheConnection>()
                .AddScoped<IProductCaching, ProductCaching>();

            return services;
        }
    }
}
