using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
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
    public static class BusinessCreate
    {
        [FunctionName("BusinessCreate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Subjects.BusinessPut()");
            string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(defaultConnection);            
            var context = new SubjectsDbContext(options.Options);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic itemToSave = JsonConvert.DeserializeObject(requestBody);
            Business business = new Caster().Cast<Business>(itemToSave);           
            var recordsAffected = await new AssociateAggregate(context).BusinessSaveAsync(business);
            return recordsAffected == 0 ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(business));
        }
    }
}
