namespace TestApp.Models;

public class MyStatus
{
    public MyStatus(string? message)
    {
        Message = message;
    }

    public string? Message { get; set; }
}