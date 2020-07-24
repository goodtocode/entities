using GoodToCode.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            var defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            var options = new DbContextOptionsBuilder<EntityDataContext>();
                options.UseSqlServer(defaultConnection);
            var context = new EntityDataContext(options.Options);
            var businesses = await context.Business.ToListAsync();

            return businesses?.Count == 0 ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(businesses));
        }
    }
}
