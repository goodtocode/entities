using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using GoodToCode.Subjects.Infrastructure;

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
            var defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);
            var context = new SubjectsDbContext(options.Options);
            var businesses = await context.Business.ToListAsync();

            return businesses?.Count == 0 ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(businesses));
        }
    }
}
