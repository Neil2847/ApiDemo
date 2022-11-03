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
    /// 取得自己的資料 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public User GetUser(User user)
    {
        return user;
    }

    [HttpGet]
    public async Task<List<User>?> GetUsers()
    {
        return await _user.GetUsers();
    }
}