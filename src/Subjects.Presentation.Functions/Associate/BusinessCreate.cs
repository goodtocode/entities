using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessCreate
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessCreate()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options =>
                            options
                                .Connect(Environment.GetEnvironmentVariable("AppSettingsConnection"))
                                // Load configuration values with no label
                                .Select(KeyFilter.Any, LabelFilter.Null)
                                // Override with any configuration values specific to current hosting env
                                .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                        );
            Configuration = builder.Build();
        }

        [FunctionName("BusinessCreate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessCreate()");
            string defaultConnection = Configuration["Stack:Shared:SqlConnection"];
            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);

            string entityJson = await new StreamReader(req.Body).ReadToEndAsync();
            var entity = JsonConvert.DeserializeObject<Business>(entityJson); 
            var recordsAffected = await new AssociateAggregate(context).BusinessCreateAsync(entity);

            return recordsAffected == 0 ? new NotFoundResult() : (IActionResult)new JsonResult(entity);
        }
    }
}
