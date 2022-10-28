using System.ComponentModel;

namespace TestApp.Models;

public class MyError
{
    [DefaultValue(400)]
    public long Code { get; set; }
    public string? Message { get; set; }
    public int Action { get; set; } = 0;
}