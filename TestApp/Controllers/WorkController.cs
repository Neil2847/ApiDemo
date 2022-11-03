using Microsoft.AspNetCore.Mvc;
using TestApp.Entities;
using TestApp.Models;
using TestApp.Services;


namespace TestApp.Controllers;

public class WorkController : ApiBaseController
{
    private readonly WorkService _service;

    public WorkController(ILogger<WorkController> logger, WorkService service) : base(logger)
    {
        _service = service;
    }

    /// <summary>
    /// 取得使用者資料
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = nameof(GetById))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MyError))]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetUserById(id);

        return id switch
        {
            < 0 => throw new Exception(),
            > 0 and < 100 => Ok(user),
            _ => NotFound(new MyError { Code = 404, Message = "Not found user", Action = 3 })
        };
    }

    /// <summary>
    /// 新增一筆工作清單
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="401">權限不足</response>
    [HttpPost("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MyError))]
    public IActionResult Post(int id)
    {
        if (id > 100)
        {
            return Unauthorized(new MyError());
        }

        return Created("", new User
        {
            Id = id,
            Displayname = $"Neil:{id}"
        });
    }
}