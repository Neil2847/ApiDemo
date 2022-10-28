using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;

namespace TestApp.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ApiBaseController
{
    private readonly bool _isDev;

    public ErrorController(ILogger<ErrorController> logger, IHostEnvironment hostEnvironment) : base(logger)
    {
        _isDev = hostEnvironment.IsDevelopment();
    }

    /// <summary>
    /// 沒有攔截到的例外處理
    /// </summary>
    /// <returns></returns>
    [Route("/Error")]
    public IActionResult ErrorHandler()
    {
        const int statusCode = (int)HttpStatusCode.InternalServerError;
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var ex = feature?.Error;
        var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        var problemDetails = new RequestProblemDetails
        {
            Status = statusCode,
            Instance = feature?.Path,
            Title = _isDev ? $"{ex?.GetType().FullName}:{ex?.Message}" : "An error occurred.",
            Detail = _isDev ? ex?.StackTrace : null,
            TraceId = traceId,
            Error = ex
        };

        // return StatusCode(statusCode, problemDetails);
        // 這邊已經有回應 error handler 的功能，目前還沒有找到自定義錯誤Model
        return Problem(
            detail: feature?.Error.StackTrace,
            title: feature?.Error.Message
        );
    }
}