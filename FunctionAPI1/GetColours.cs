using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace FunctionAPI1
{
    public static class GetColours
    {
        [FunctionName("GetColours")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Colours" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<ColoursItem>), Description = "OK")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "colours" )] HttpRequest req,
            ILogger log)
        {
            log.LogInformation(">>> GetColours");

            await Task.Run(() => { });

            var response = new List<ColoursItem>
            {
                new ColoursItem { Id = 1, Name = "Yellow", Data = null },
                new ColoursItem { Id = 2, Name = "Black", Data = null },
                new ColoursItem { Id = 3, Name = "Red", Data = null }
            };

            return new OkObjectResult(response);
        }
    }
}

