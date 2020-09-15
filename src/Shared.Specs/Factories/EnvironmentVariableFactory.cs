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
        }

        public EnvironmentVariableFactory(string environment)
        {
            ASPNETCORE_ENVIRONMENT = environment;
        }

        public string CreateASPNETCORE_ENVIRONMENT()
        {
            return ASPNETCORE_ENVIRONMENT;
        }
    }
}