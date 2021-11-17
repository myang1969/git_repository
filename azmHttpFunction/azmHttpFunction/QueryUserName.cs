using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace azmHttpFunction
{
    public static class QueryUserName
    {
        [FunctionName("QueryUserNameList")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = "Unknown name";

           if (name == "pekd")
            {
                responseMessage = "michael;myang;yangmich;chenelin;changwew;austin;luaus;wewechang";
            }
            else if (name == "ntkd")
            {
                responseMessage = "michael;myang;yangmich;chenelin;changwew;austin;luaus;wewechang";
            }
            else
            {
                responseMessage = "Unknown name";
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
