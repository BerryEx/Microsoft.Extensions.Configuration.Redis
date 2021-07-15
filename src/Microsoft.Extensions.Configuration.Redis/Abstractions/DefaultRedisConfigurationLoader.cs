using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Redis
{
    /// <summary>
    /// 功能描述    ：DefaultRedisConfigurationLoader
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 09:14 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 09:14 
    /// </summary>
    public class DefaultRedisConfigurationLoader : IRedisConfigurationLoader
    {
        private RedisConfigurationOptions Options { get; }

        public DefaultRedisConfigurationLoader(RedisConfigurationOptions options)
        {
            this.Options = options;

            var rds = new CSRedis.CSRedisClient(this.Options.ConnectionString);
            RedisHelper.Initialization(rds);
        }

        public string LoadJsonString()
        {
            string json = RedisHelper.Get(this.Options.ConfigurationKey);

            return json;
        }
    }
}