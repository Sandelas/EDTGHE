using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

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

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            List<Repos> RepoList = JsonConvert.DeserializeObject<List<Repos>>(requestBody);
            Console.WriteLine("\n Total Repo Count : " + RepoList.Count.ToString());
            foreach (var item in RepoList)
            {
                Console.WriteLine("\n Repo ID : " + item.id.ToString());
                Console.WriteLine("\n Node : " + item.node_id);
                Console.WriteLine("\n Repo Name : " + item.name);
                Console.WriteLine("\n Full Name : " + item.full_name);
                Console.WriteLine("\n Visiblity : " + item.Visiblity);
                Console.WriteLine("\n URL : " + item.Url);
                Console.WriteLine("\n ----------------------------");

                /*
                // Createe Code that can add these details into the Database tables. 
                */
            }

            log.LogInformation(requestBody);
            
            //return new OkResult();
            
            string responseMessage = string.IsNullOrEmpty(name)
              ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            : $"Hello, {name}. This HTTP triggered function executed successfully.";

             return new OkObjectResult(responseMessage);
        }
    }
}

