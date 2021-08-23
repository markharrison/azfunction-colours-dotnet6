using System;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace FunctionAPI1
{
    public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = "v0.1",
            Title = "Mark Harrison - Colours",
            Description = "Azure Functions .NET 6.0",
            TermsOfService = new Uri("https://github.com/markharrison/azfunc-openapi-dotnet6"),
            Contact = new OpenApiContact()
            {
                Name = "Mark Harrison",
                Email = "mark@nospam.markharrison.org",
                Url = new Uri("https://github.com/markharrison/azfunc-openapi-dotnet6/issues"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
    }
}