using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsPractice;

public class QueueTrigger
{
    private readonly ILogger<QueueTrigger> _logger;

    public QueueTrigger(ILogger<QueueTrigger> logger)
    {
        _logger = logger;
    }

    [Function("AzureQueueTrigger")]
    public void Run([QueueTrigger("orders", Connection = "AzureQueueSetting")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}