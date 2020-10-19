using Microsoft.Extensions.Configuration;

namespace GoodToCode.Shared.Specs
{
    public class ConnectionStringFactory
    {
        public IConfiguration Configuration { get; }

        public ConnectionStringFactory()
        {
            Configuration = new ConfigurationFactory().CreateFromAzureSettings();
        }

        public ConnectionStringFactory(string projectFolder)
        {
            Configuration = new ConfigurationFactory(projectFolder).CreateFromJsonSettings();
        }

        public ConnectionStringFactory(IConfiguration config)
        {
            Configuration = config;
        }

        public string CreateFromAzureSettings(string key)
        {   
            return Configuration[key];
        }

        public string CreateFromConnectionString(string connectionName)
        {
            return Configuration.GetConnectionString(connectionName);
        }
    }
}
