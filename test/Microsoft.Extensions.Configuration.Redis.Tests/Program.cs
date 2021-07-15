using System;

namespace Microsoft.Extensions.Configuration.Redis.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddRedisConfiguration(option =>
                {
                    option.ConnectionString = "localhost:6379";
                    option.ConfigurationKey = "appsettings.json";
                })
                .Build();

            Useroptions optinos = configuration.GetSection("UserOptions").Get<Useroptions>();
            Console.WriteLine(optinos.Name);

            Console.ReadKey();
        }
    }
}