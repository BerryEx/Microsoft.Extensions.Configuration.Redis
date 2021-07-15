using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Redis
{
    /// <summary>
    /// 功能描述    ：RedisConfigurationOptions
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 15:25 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 15:25 
    /// </summary>
    public class RedisConfigurationOptions
    {
        public string ConnectionString { get; set; } = "localhost:6379";

        public string ConfigurationKey { get; set; } = "appsettings.json";
    }
}