using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers;

public class WorkController:ApiBaseController
{

    /// <summary>
    /// 取得列表
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetTodoList")]
    public List<Todo> GetTodoList()
    {
        return new List<Todo>
        {
            new Todo(id: 33, isComplete: false, name: "Neil"),
            new Todo(id: 42, isComplete: true, name: "Winner")
        };
    }
}