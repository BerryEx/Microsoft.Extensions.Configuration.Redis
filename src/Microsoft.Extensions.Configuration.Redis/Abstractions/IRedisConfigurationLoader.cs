namespace Microsoft.Extensions.Configuration.Redis
{
    public interface IRedisConfigurationLoader
    {
        string LoadJsonString();
    }
}