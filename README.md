# Microsoft.Extensions.Configuration.Redis

- 简介

  ​	Microsoft.Extensions.Configuration.Redis是基于微软官方包Microsoft.Extensions.Configuration的Redis扩展实现，快速将你需要把配置信息存在Redis中的需求进行集成。

  

- 快速开始

  1、在你的Nuget包管理器安装Berry.Extensions.Configuration.Redis：

  > Install-Package Berry.Extensions.Configuration.Redis -Version 1.0.0

  

  2、在Program中引入AddRedisConfiguration

  ```c#
  internal static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
      			.AddRedisConfiguration(option =>
                  {
                      option.ConnectionString = "localhost:6379";
                      option.ConfigurationKey = "appsettings.json";
                  })
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<Startup>();
                  });
  ```

  然后在需要使用配置的地方，注入IConfiguration即可：

  ```c#
  private readonly IConfiguration _configuration;
  
          public BookController(IConfiguration configuration)
          {
              this._configuration = configuration;
          }
  
          public void DoSomething()
          {
              string host = this._configuration["ApiHost"];
          }
  ```

  

- 自定义数据加载者

  ​	Berry.Extensions.Configuration.Redis默认使用CSRedis包作为从Redis中加载数据的第三方包，你也可以自定义其他第三方包。新建类继承自IRedisConfigurationLoader然后实现LoadJsonString()方法即可：

  ```c#
  public class CustomRedisConfigurationLoader : IRedisConfigurationLoader
      {
          public string LoadJsonString()
          {
              //使用你自己喜欢的工具包获取数据
              
              return "{}";
          }
      }
  ```

  然后修改Program：

  ```c#
  internal static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
      			.AddRedisConfiguration(new CustomRedisConfigurationLoader())
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<Startup>();
                  });
  ```

  