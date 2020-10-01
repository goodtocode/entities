using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GoodToCode.Application.Functions.Functions
{
    public static class BusinessesGet
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessesGet()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationDefault();
            Configuration = builder.Build();
        }

        [FunctionName("BusinessesGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessesGet()");
            var defaultConnection = Configuration["Stack:Shared:SqlConnection"];
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);
            var context = new SubjectsDbContext(options.Options);
            var entities = await context.Business.ToListAsync();

            return entities?.Count == 0 ? new NotFoundResult() : (IActionResult)new JsonResult(entities);
        }
    }
}
