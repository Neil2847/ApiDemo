using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace TestApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ApiBaseController : ControllerBase, IDisposable
{
    private readonly IDisposable? _loggerScope;

    public ApiBaseController(ILogger logger)
    {
        _loggerScope = logger.BeginScope(new[]
            { new KeyValuePair<string, object>("ScopeId", $"{Guid.NewGuid():N}"[..4]) });
    }

    public void Dispose()
    {
        _loggerScope?.Dispose();
    }
}