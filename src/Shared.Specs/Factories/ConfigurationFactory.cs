using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace GoodToCode.Shared.Specs
{
    public class ConfigurationFactory
    {
        private readonly string _projectFolderName = string.Empty;
        public string ConfigDirectory { get{ return Directory.GetCurrentDirectory().Replace("TestResults", _projectFolderName); } }
        public ConfigurationFactory(string projectFolder)
        {
            _projectFolderName = projectFolder;
        }
        public IConfiguration Create()
        {
            return new ConfigurationBuilder().SetBasePath(ConfigDirectory)
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}
