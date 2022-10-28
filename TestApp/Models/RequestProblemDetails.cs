using Microsoft.AspNetCore.Mvc;

namespace TestApp.Models;

public class RequestProblemDetails : ProblemDetails
{
    public string? TraceId { get; set; }
    public dynamic? Error { get; set; }
}