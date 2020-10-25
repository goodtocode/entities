using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GoodToCode.Chronology.Infrastructure
{
    public partial class ChronologyDbContextDeploy : ChronologyDbContext
    {
        public ChronologyDbContextDeploy() 
            : base(new DbContextOptionsBuilder<ChronologyDbContext>().Options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionFromAzureSettings("Stack:Shared:SqlConnection"));
                //optionsBuilder.UseCosmos(GetConnectionFromAzureSettings("Stack:Shared:CosmosConnection"));
            }
        }

        public string GetConnectionFromAzureSettings(string configKey)
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationWithSentinel(Environment.GetEnvironmentVariable("AppSettingsConnection"), "Stack:Shared:Sentinel");
            var config = builder.Build();

            return config[configKey];
        }
    }
}
