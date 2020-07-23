using GoodToCode.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Application.Functions.Functions
{
    public static class BusinessesGet
    {
        [FunctionName("BusinessesGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessesGet()");

            string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection");
            var options = new DbContextOptionsBuilder<EntityDataContext>();
                options.UseSqlServer(defaultConnection);
            var context = new EntityDataContext(options.Options);
            var businesses = await context.Business.ToListAsync();

            return businesses?.Count > 0 ? new NotFoundResult() : (IActionResult)new OkObjectResult(businesses);
        }
    }
}
