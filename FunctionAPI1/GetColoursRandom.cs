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
    public static class GetColoursRandom
    {
        [FunctionName("GetColoursRandom")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Colours" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ColoursItem), Description = "OK")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "colours/random" )] HttpRequest req,
            ILogger log)
        {
            log.LogInformation(">>> GetColoursRandom");

            await Task.Run(() => { });

            var colourItems = new List<ColoursItem>
            {
                new ColoursItem { Id = 1, Name = "Yellow", Data = null },
                new ColoursItem { Id = 2, Name = "Black", Data = null },
                new ColoursItem { Id = 3, Name = "Red", Data = null }
            };

            Random r = new();
            int ridx = r.Next(colourItems.Count);

            return new OkObjectResult(colourItems[ridx]);
        }
    }

}

