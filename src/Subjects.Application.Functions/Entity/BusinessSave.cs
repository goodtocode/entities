using GoodToCode.Shared.Extensions;
using GoodToCode.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Functions
{
    public static class BusinessSave
    {
        [FunctionName("BusinessSave")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessSave({req.Query["key"]})");
            var returnData = new Business();
            var businessKey = req.Query["key"].ToString().ToGuid();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic itemToSave = JsonConvert.DeserializeObject(requestBody);
            string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            var options = new DbContextOptionsBuilder<EntityDataContext>();
                options.UseSqlServer(defaultConnection);
            var context = new EntityDataContext(options.Options);
            var business = new Caster().Cast<Business>(itemToSave);
            if (businessKey == Guid.Empty)
                context.Entry(business).State = EntityState.Modified;
            else
                context.Add(business);
            var recordsAffected = await context.SaveChangesAsync();

            return business.BusinessKey == Guid.Empty ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(business));
        }
    }
}
