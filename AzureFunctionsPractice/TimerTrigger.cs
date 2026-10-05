using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsPractice;

public class TimerTrigger
{
    private readonly ILogger _logger;

    public TimerTrigger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<TimerTrigger>();
    }

    [Function("AzureTimerTrigger")]
    public void TimerTriggerRun([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation("Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
        }
    }
}