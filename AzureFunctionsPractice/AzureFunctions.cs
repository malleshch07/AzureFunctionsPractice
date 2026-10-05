using Azure.Storage.Queues.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AzureFunctionsPractice;

public class AzureFunctions
{
    private readonly ILogger<AzureFunctions> _logger;

    public AzureFunctions(ILogger<AzureFunctions> logger)
    {
        _logger = logger;
    }

    //[Function("AzureFunctions")]
    //public IActionResult GetBasicData([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    //{
    //    _logger.LogInformation("C# HTTP trigger function processed a request.");
    //    return new OkObjectResult("Welcome to Azure Functions!");
    //}

    //[Function("AzureFunctionsWithName")]
    //public async Task<IActionResult> SampleRun([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Azure/Functions/WithName")] HttpRequest httpRequest)
    //{
       
    //    string sname = httpRequest.Query["name"];
    //    string name = await new StreamReader(httpRequest.Body).ReadToEndAsync();


    //    var dull = JsonSerializer.Deserialize<sap>(name);
    //    _logger.LogInformation("C# new sample Run azure function call" + httpRequest.Body);
    //    return new OkObjectResult("Welcome to Azure Functions with name!" + dull?.name);

    //}

    //[Function("AzureTimerTRigger")]
    //public void RunTimer([TimerTrigger("0 */1 * * * *")] TimerInfo timer)
    //{

    //    //for (int i = 0; i < 10; i++)
    //    //{
    //    //    _logger.LogInformation($" {i + 1} * {counter} = {(i + 1) * counter} "); ;
    //    //}

    //_logger.LogInformation(  $"Timer function executed at: {DateTime.Now}");
    //    counter++;
    //}

    //[Function("AzureOrdersQueueTrigger")]
    //public void AzureOrdersQueue([QueueTrigger("orders", Connection = "OrderMessageQueue")] QueueMessage message)
    //{

    //    _logger.LogInformation($"  messaage details as below /n + { message.MessageText}");

    //}

    //[Function("AzurePaymentsQueueTrigger")]
    //public void AzurePaymentQueue([QueueTrigger("payments", Connection = "OrderMessageQueue")] QueueMessage message)
    //{
    //    _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    //}





    public static int counter = 0;
    public class sap
    {

        public string name { get; set; }
    }

}