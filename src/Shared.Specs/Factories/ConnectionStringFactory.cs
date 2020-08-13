using Microsoft.Extensions.Configuration;

namespace GoodToCode.Shared.Specs
{
    public class ConnectionStringFactory
    {
        public IConfiguration Configuration { get; }

        public ConnectionStringFactory(string projectFolder)
        {
            Configuration = new ConfigurationFactory(projectFolder).Create();
        }

        public ConnectionStringFactory(IConfiguration config)
        {
            Configuration = config;
        }

        public string Create(string connectionName = "DefaultConnection")
        {
            return Configuration.GetConnectionString(connectionName);
        }
    }
}
