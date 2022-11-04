using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestApp.Entities;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.Controllers;

public class UserController : ApiBaseController
{
    private readonly UserService _user;
    private readonly AccountService _account;

    public UserController(UserService user, AccountService account, ILogger<UserController> logger) : base(logger)
    {
        _user = user;
        _account = account;
    }

    /// <summary>
    /// 取得使用者名稱
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <remarks>
    /// GET /Name/443
    /// {
    ///     "id": 1,
    ///     "name": "Neil",
    ///     "age": 20
    /// }
    /// </remarks>
    /// <response code="401">找不到使用者</response>
    [HttpGet("Name/{id:int}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<string> GetUserName(int id)
    {
        return await _user.GetUserName(id);
    }

    /// <summary>
    /// 取得帳號資訊
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetInfo/{id:int}")]
    public async Task<User> GetInfo(int id)
    {
        return await _account.GetUser(id);
    }

    /// <summary>
    /// 新增使用者
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <response code="401">資料已存在</response>
    /// <response code="201">存入成功</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MyError))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MyStatus))]
    public async Task<IActionResult> AddUser(User user)
    {
        var error = await _user.SaveUser(user);
        if (error != null)
        {
            return Unauthorized(error);
        }

        return CreatedAtAction("GetUsers", "", user);
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _user.GetUsers();
    }
}