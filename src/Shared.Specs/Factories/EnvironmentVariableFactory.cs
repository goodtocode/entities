using System;

namespace GoodToCode.Shared.Specs.Factories
{
    public class EnvironmentVariableFactory
    {
        public string DefaultASPNETCORE_ENVIRONMENT { get; set; } = "Development";
        public string ASPNETCORE_ENVIRONMENT { get; }

        public EnvironmentVariableFactory()
        {
            ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? DefaultASPNETCORE_ENVIRONMENT;
#if DEBUG
            ASPNETCORE_ENVIRONMENT = "Local";
#endif
        }

        public string CreateASPNETCORE_ENVIRONMENT()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        public string Create(string envKey)
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        public void SetASPNETCORE_ENVIRONMENT(string envValue)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", envValue);
        }

        public void Set(string envKey, string envValue)
        {
            Environment.SetEnvironmentVariable(envKey, envValue);
        }
    }
}