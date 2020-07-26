using GoodToCode.Shared.Extensions;
using GoodToCode.Shared.Models;
using GoodToCode.Subjects.Aggregates;
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
            Business business = new Caster().Cast<Business>(itemToSave);
            if(business.BusinessKey == Guid.Empty && businessKey != Guid.Empty) business.BusinessKey = businessKey;
            business = await new EntityAggregate().BusinessSaveAsync(business);
            return business.BusinessKey == Guid.Empty ? new NotFoundResult() : (IActionResult)new OkObjectResult(JsonConvert.SerializeObject(business));
        }
    }
}
