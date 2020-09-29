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
    public static class BusinessSave
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessSave()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AppSettingsConnection"));
            Configuration = builder.Build();
        }

        [FunctionName("BusinessSave")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessSave({req.Query["key"]})");
            string defaultConnection = Configuration["Stack:Shared:SqlConnection"];
            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);
            var context = new SubjectsDbContext(options.Options);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var entity = JsonConvert.DeserializeObject<Business>(requestBody);
            var recordsAffected = await new AssociateAggregate(context).BusinessSaveAsync(entity);

            return recordsAffected == 0 ? new NotFoundResult() : (IActionResult)new JsonResult(entity);
        }
    }
}
