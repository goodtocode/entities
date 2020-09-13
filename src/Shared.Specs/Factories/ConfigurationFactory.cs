using GoodToCode.Shared.Specs.Factories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Shared.Specs
{
    public class ConfigurationFactory
    {
        public struct Environments
        {
            public static string Local = "Local";
            public static string Development = "Development";
            public static string Staging = "Staging";
            public static string Production = "Production";
        }

        private string _environment = string.Empty;
        private List<string> _configFiles = new List<string>();

        public IConfiguration Configuration { get; }
        public string ConfigDirectory { get; set; }
        public string BaseConfigFile { get { return "appsettings.json"; } }
        public string EnvironmentConfigFile { get { return $"appsettings.{CurrentEnvironment}.json"; } }
        public List<string> ConfigFiles
        {
            get
            {
                if (_configFiles?.Count == 0)
                {
                    _configFiles.Add(BaseConfigFile);
                    _configFiles.Add(EnvironmentConfigFile);
                }
                return _configFiles;
            }
            set { _configFiles = value; }
        }

        public string CurrentEnvironment
        {
            get
            {
                if (_environment.IsNullOrWhiteSpace()) _environment = new EnvironmentVariableFactory().CreateASPNETCORE_ENVIRONMENT();
                return _environment;
            }
            set { _environment = value; }
        }

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
            ConfigDirectory = FindConfiguration(AssemblyDirectory);
        }

        public ConfigurationFactory(List<string> configFiles)
        {
            _configFiles = configFiles;
            ConfigDirectory = FindConfiguration(AssemblyDirectory);
        }

        public ConfigurationFactory(string configDirectory)
        {
            ConfigDirectory = FindConfiguration(configDirectory);
        }

        public ConfigurationFactory(string configDirectory, List<string> configFiles)
        {
            _configFiles = configFiles;
            ConfigDirectory = FindConfiguration(configDirectory);
        }

        public string FindConfiguration(string configDirectory)
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

        public string SearchDirectoryAndParent(string configDirectory)
        {
            var returnValue = string.Empty;
            if (Directory.GetFiles(configDirectory, BaseConfigFile).Length > 0)
                returnValue = configDirectory;
            else if (Directory.GetParent(configDirectory).GetFiles(BaseConfigFile).Length > 0)
                returnValue = Directory.GetParent(configDirectory).FullName;

            return returnValue;
        }

        public IConfiguration Create()
        {
            var returnValue = new ConfigurationBuilder().SetBasePath(ConfigDirectory);
            foreach (var item in ConfigFiles)
            {
                returnValue.AddJsonFile(item);
            }

            return returnValue.Build();
        }
    }
}
