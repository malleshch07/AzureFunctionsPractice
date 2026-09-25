using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsPractice;

public class AzureFunctions
{
    private readonly ILogger<AzureFunctions> _logger;

    public AzureFunctions(ILogger<AzureFunctions> logger)
    {
        _logger = logger;
    }

    [Function("AzureFunctions")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}