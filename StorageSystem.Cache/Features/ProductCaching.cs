using StackExchange.Redis.Extensions.Core.Abstractions;
using StorageSystem.Application.Contracts.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NPOI.HSSF.Util.HSSFColor;

namespace StorageSystem.Cache.Features
{
    public class ProductCaching : IProductCaching
    {
        private readonly ICacheConnection _connection;
        private readonly IRedisDatabase _database;
        public ProductCaching(ICacheConnection connection, IRedisDatabase database)
        {
            _connection = connection;
            _database = database;
        }
        public async Task<(string, bool)> CachingProducts()
        {
            var a = await _database.SetAddAsync<string>("hello", "xin chao");
            return ("", true);
        }

        public async Task<(string, bool)> GetCachingProducts()
        {
            var a = await _database.GetAsync<string>("hello");
            return ("", true);
        }
    }
}
