using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.Caches
{
    public interface ICacheConnection
    {
        IRedisDatabase CreateInstance();
    }
}
