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

        // 已經可以不用繼承 ProblemDetails 來承接錯誤訊息，可以直接透過自定義的Models來定義
        var problemDetails = new RequestProblemDetails
        {
            Status = statusCode,
            Instance = feature?.Path,
            Title = _isDev ? $"{ex?.GetType().FullName}:{ex?.Message}" : "An error occurred.",
            Detail = _isDev ? ex?.StackTrace : null,
            TraceId = traceId,
            Error = ex
        };

        return StatusCode(statusCode, new MyError
        {
            Action = 0,
            Code = statusCode,
            Message = feature?.Error.Message
        });
        // 直接呼叫Problem的方式吐出錯誤訊息，這個錯誤格式是原本的，上方是自定義的格式
        return Problem(
            detail: feature?.Error.StackTrace,
            title: feature?.Error.Message
        );
    }
}