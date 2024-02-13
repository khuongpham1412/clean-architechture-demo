using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.Caches
{
    public interface IProductCaching
    {
        Task<(string, bool)> CachingProducts();

        Task<(string, bool)> GetCachingProducts();
    }
}
