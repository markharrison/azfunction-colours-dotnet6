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
    public static class GetColoursById
    {
        [FunctionName("GetColoursById")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Colours" })]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(Int32), Description = "{colourId}")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ColoursItem), Description = "OK")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.UnprocessableEntity, contentType: "application/json", bodyType: typeof(ProblemDetails), Description = "UnprocessableEntity")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(ProblemDetails), Description = "UnprocessableEntity")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "colours/{id:int?}")] HttpRequest req,
            ILogger log, int id)
        {
            log.LogInformation(">>> GetColoursById: " + id);

            await Task.Run(() => { });


            if (id < 1 || id > 1000)
            {
                return new UnprocessableEntityObjectResult(new ProblemDetails { Status = 422, Title = "{colourId} must be between 1 and 1000" });
            }

            if (id < 1 || id > 3)
            {
                return new NotFoundObjectResult(new ProblemDetails { Status = 404, Title = "{colourId} must be between 1 and 3" });
            }


            var colourItems = new List<ColoursItem>
            {
                null,
                new ColoursItem { Id = 1, Name = "Yellow", Data = null },
                new ColoursItem { Id = 2, Name = "Black", Data = null },
                new ColoursItem { Id = 3, Name = "Red", Data = null }
            };

            return new OkObjectResult(colourItems[id]);
        }
    }
}

