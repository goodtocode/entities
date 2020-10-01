using GoodToCode.Extensions;
using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessGet
    {
        private static IConfiguration Configuration { set; get; }

        static BusinessGet()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationDefault();
            Configuration = builder.Build();
        }

        [FunctionName("BusinessGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {           
            log.LogInformation($"Subjects.BusinessGet({req.Query["key"]})");
            var businessKey = req.Query["key"].ToString().ToGuid();
            if (businessKey == Guid.Empty)
                return new BadRequestResult();
            var defaultConnection = Configuration["Stack:Shared:SqlConnection"];            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            var dbContextOptionsBuilder = options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);
            var entity = await context.Business.FirstAsync(x => x.BusinessKey == businessKey);

            return entity == null ? new NotFoundResult() : (IActionResult)new JsonResult(entity);
        }
    }
}
