using GoodToCode.Extensions;
using GoodToCode.Subjects.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
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
            var defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            var dbContextOptionsBuilder = options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);
            var entity = await context.Business.FirstAsync(x => x.BusinessKey == businessKey);

            return entity == null ? new NotFoundResult() : (IActionResult)new JsonResult(entity);
        }
    }
}
