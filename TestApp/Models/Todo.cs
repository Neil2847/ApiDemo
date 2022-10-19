namespace TestApp;

public class Todo
{
    public Todo()
    {
    }

    public Todo(int id, bool isComplete, string? name)
    {
        Id = id;
        IsComplete = isComplete;
        Name = name;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}