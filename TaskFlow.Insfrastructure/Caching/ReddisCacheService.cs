using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Common.Interface;

namespace TaskFlow.Insfrastructure.Caching
{
    public class ReddisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public ReddisCacheService(IDistributedCache Cache)
        {
            this._cache = Cache;       
        }
        public async Task SetData(string key,string value)
        {
            await _cache.SetStringAsync(key, value);
        }
        public async Task<string?> GetData(string key)
        {
            return await _cache.GetStringAsync(key);
        }
    }
}
