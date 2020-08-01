using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace GoodToCode.Subjects.Specs
{
    public class ConfigurationFactory
    {
        public IConfiguration Create()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}
