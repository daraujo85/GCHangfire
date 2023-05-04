using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace GCHangfire.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController : ControllerBase
{
    private readonly ILogger<JobsController> _logger;

    public JobsController(ILogger<JobsController> logger)
    {
        _logger = logger;
    }

    [HttpPost("TaferaSobDemanda")]
    
    public void TaferaSobDemanda()
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
    }
    [HttpPost("TaferaComAtrasoNaExecucao")]
    public void TaferaComAtrasoNaExecucao()
    {
        BackgroundJob.Schedule(() => Console.WriteLine("Delayed!"), TimeSpan.FromDays(7));
    }
}
