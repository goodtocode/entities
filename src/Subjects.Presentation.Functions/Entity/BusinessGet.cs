using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessGet
    {
        [FunctionName("BusinessGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {           
            log.LogInformation($"Subjects.BusinessGet({req.Query["key"]})");
            var businessKey = req.Query["key"].ToString().ToGuid();
            if (businessKey == Guid.Empty)
                return new BadRequestResult();
            var defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            var dbContextOptionsBuilder = options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);
            var business = await context.Business.FirstAsync(x => x.BusinessKey == businessKey);

            return business == null ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(business));
        }
    }
}
