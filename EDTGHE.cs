using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EDTGHE
{
    public static class EDTGHE
    {
        [FunctionName("EDTGHE")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Checking for Events from GitHub. ");

            //string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            var data = JsonConvert.DeserializeObject<Rootobject>(requestBody);
            //name = name ?? data?.name;
            log.LogInformation(requestBody);
            return new OkResult();
            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //  : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

            //string responseMessage = string.IsNullOrEmpty(name)
            //  ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //: $"Hello, {name}. This HTTP triggered function executed successfully.";

            // return new OkObjectResult(responseMessage);
        }
    }
}

