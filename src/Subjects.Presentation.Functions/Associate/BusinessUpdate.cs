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
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessUpdate
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessUpdate()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationDefault();
            Configuration = builder.Build();
        }

        [FunctionName("BusinessUpdate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessPost({req.Query["key"]})");
            string defaultConnection = Configuration["Stack:Shared:SqlConnection"];
            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var entity = JsonConvert.DeserializeObject<Business>(requestBody);
            var recordsAffected = await new AssociateAggregate(context).BusinessUpdateAsync(entity);            

            return recordsAffected == 0 ? new NotFoundResult() : (IActionResult)new JsonResult(entity);
        }
    }
}
