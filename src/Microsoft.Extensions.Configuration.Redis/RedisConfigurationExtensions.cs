using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration.Redis;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// 功能描述    ：RedisConfigurationExtensions
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 08:56 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 08:56 
    /// </summary>
    public static class RedisConfigurationExtensions
    {
        public static IConfigurationBuilder AddRedisConfiguration(this IConfigurationBuilder builder,
            Action<RedisConfigurationOptions> action = null)
        {
            RedisConfigurationOptions options = new RedisConfigurationOptions();
            action?.Invoke(options);

            return builder.Add(new RedisConfigurationSource(new DefaultRedisConfigurationLoader(options)));
        }

        public static IConfigurationBuilder AddRedisConfiguration(this IConfigurationBuilder builder,
            IRedisConfigurationLoader loader)
        {
            return builder.Add(new RedisConfigurationSource(loader));
        }
    }
}