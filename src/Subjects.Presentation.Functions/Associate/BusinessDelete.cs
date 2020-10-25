using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessDelete
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessDelete()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationWithSentinel(Environment.GetEnvironmentVariable("AppSettingsConnection"), "Stack:Shared:Sentinel");
            Configuration = builder.Build();
        }

        [FunctionName("BusinessDelete")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessDelete({req.Query["key"]})");
            string defaultConnection = Configuration["Stack:Shared:SqlConnection"];
            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var bodyContent = JsonConvert.DeserializeObject<Business>(requestBody);
            var recordsAffected = await new AssociateAggregate(context).BusinessSaveAsync(bodyContent);
            return recordsAffected == 0 ? new NotFoundResult() : (IActionResult)new OkResult();
        }
    }
}
