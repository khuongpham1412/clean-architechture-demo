using Microsoft.Extensions.Logging;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StorageSystem.Application.Contracts.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Providers
{
    public class CacheConnection : ICacheConnection
    {
        private readonly ILogger<CacheConnection> _logger;
        private readonly IRedisClient _redisClient;
        private IRedisDatabase _redisDatabase;

        public CacheConnection(IRedisClient redisClient, ILogger<CacheConnection> logger)
        {
            _redisClient = redisClient;
            _logger = logger;
        }
        public IRedisDatabase CreateInstance()
        {
            if( _redisDatabase == null )
            {
                _redisDatabase = _redisClient.GetDefaultDatabase();
            }
            
            return _redisDatabase;
        }
    }
}
