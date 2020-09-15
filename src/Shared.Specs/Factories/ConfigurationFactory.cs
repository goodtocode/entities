using GoodToCode.Shared.Specs.Factories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GoodToCode.Shared.Specs
{
    public struct ConfigurationEnvironments
    {
        public static string Local = "Local";
        public static string Development = "Development";
        public static string Staging = "Staging";
        public static string Production = "Production";
    }

    public class ConfigurationFactory
    {
        public string CurrentEnvironment { get { return new EnvironmentVariableFactory().CreateASPNETCORE_ENVIRONMENT(); } }
        public IConfiguration Configuration { get; }
        public string DefaultPath { get; set; }
        public string BaseConfigFile { get { return "appsettings.json"; } }
        public string EnvironmentConfigFile { get { return $"appsettings.{CurrentEnvironment}.json"; } }
        public List<string> ConfigFiles { get; } = new List<string>();

        public string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public ConfigurationFactory()
        {
            DefaultPath = AssemblyDirectory;
        }

        public ConfigurationFactory(List<string> configFiles) : this()
        {
            ConfigFiles = configFiles;
        }

        public ConfigurationFactory(string defaultPath) : this()
        {
            DefaultPath = defaultPath;
        }

        public ConfigurationFactory(string defaultPath, List<string> configFiles) : this(defaultPath)
        {
            ConfigFiles = configFiles;
        }

        public IConfiguration Create()
        {            
            DefaultPath = FindConfiguration(DefaultPath);
            if (!ConfigFiles.Any()) ConfigFiles.AddRange(new string[] { BaseConfigFile, EnvironmentConfigFile });
            var returnValue = new ConfigurationBuilder().SetBasePath(DefaultPath);            
            foreach (var item in ConfigFiles)
            {
                returnValue.AddJsonFile(item);
            }

            return returnValue.Build();
        }

        private string FindConfiguration(string configDirectory)
        {
            var returnValue = configDirectory;
            if (SearchDirectoryAndParent(configDirectory).Length > 0)
                returnValue = configDirectory;
            else if (SearchDirectoryAndParent(AssemblyDirectory).Length > 0)
                returnValue = SearchDirectoryAndParent(AssemblyDirectory);
            else if (SearchDirectoryAndParent(Directory.GetCurrentDirectory()).Length > 0)
                returnValue = SearchDirectoryAndParent(Directory.GetCurrentDirectory());

            return returnValue;
        }

        private string SearchDirectoryAndParent(string configDirectory)
        {
            var returnValue = string.Empty;
            if (Directory.GetFiles(configDirectory, BaseConfigFile).Length > 0)
                returnValue = configDirectory;
            else if (Directory.GetParent(configDirectory).GetFiles(BaseConfigFile).Length > 0)
                returnValue = Directory.GetParent(configDirectory).FullName;

            return returnValue;
        }
    }
}
