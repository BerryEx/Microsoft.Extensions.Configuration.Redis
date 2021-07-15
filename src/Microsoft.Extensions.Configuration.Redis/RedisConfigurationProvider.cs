using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Redis
{
    /// <summary>
    /// 功能描述    ：RedisConfigurationProvider
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 08:54 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 08:54 
    /// </summary>
    public class RedisConfigurationProvider : ConfigurationProvider
    {
        private IRedisConfigurationLoader RedisConfigurationLoader { get; }

        public RedisConfigurationProvider(IRedisConfigurationLoader loader)
        {
            this.RedisConfigurationLoader = loader;
        }

        public override void Load()
        {
            this.LoadData4Redis();
        }

        private void LoadData4Redis()
        {
            string json = this.RedisConfigurationLoader.LoadJsonString();
            if (!string.IsNullOrEmpty(json))
            {
                this.Data = JsonConfigurationStringParser.Parse(json);
            }
        }
    }
}