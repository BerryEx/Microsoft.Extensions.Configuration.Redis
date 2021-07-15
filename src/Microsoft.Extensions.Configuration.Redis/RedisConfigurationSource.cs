using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Redis
{
    /// <summary>
    /// 功能描述    ：RedisConfigurationSource
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 08:53 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 08:53 
    /// </summary>
    public class RedisConfigurationSource : IConfigurationSource
    {
        private readonly IRedisConfigurationLoader _redisConfigurationLoader;

        public RedisConfigurationSource(IRedisConfigurationLoader loader)
        {
            this._redisConfigurationLoader = loader;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new RedisConfigurationProvider(this._redisConfigurationLoader);
        }
    }
}