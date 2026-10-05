using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AzureFunctionsPractice;

public class HttpTrigger
{
    private readonly ILogger<HttpTrigger> _logger;

    public HttpTrigger(ILogger<HttpTrigger> logger)
    {
        _logger = logger;
    }


    [Function("AzureHttpTrigger")]
    public async Task<IActionResult> GetHttpTrigger([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Sample/get")] HttpRequest req)
    {
        _logger.LogInformation("C# sample Httptrigger with no request parameters");


        var sample = await new StreamReader(req.Body).ReadToEndAsync();

        bool data = !string.IsNullOrEmpty(sample);

        return new OkObjectResult($"Processed Http Trigger success and data availble {data}");
    
    }
    [Function("AzureHttpTriggerWithInputs")]

    public IActionResult GetHttpTriggerWithInout([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sample/Get/WithInputs")] HttpRequest req)
    {
        var name = req.Query["name"];
        return new OkObjectResult($"Processed values are {name}");
    
    }

    [Function("AzurehttpTriggerwithModel")]

    public async Task<IActionResult> GetHttpTriggerWithModel([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "sample/get/withModel")] HttpRequest req)
    { 
    
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        var userModel = JsonSerializer.Deserialize<UserModel>(requestBody);

        return new OkObjectResult($"Processed and received values are {userModel?.id} and {userModel?.name} and {userModel?.address}");
    }

    class UserModel
    {
        public Guid id { get; set; } = new Guid();
        public string name { get; set; }
        public string address { get; set; }= string.Empty;


    }

}