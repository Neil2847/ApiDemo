using Microsoft.AspNetCore.Mvc;
using TestApp.Services;

namespace TestApp.Controllers;

public class UserController:ApiBaseController
{
    private readonly UserService _user;
    private readonly AccountService _account;

    public UserController(UserService user, AccountService account)
    {
        _user = user;
        _account = account;
    }

    /// <summary>
    /// 取得使用者名稱
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Name/{id:int}")]
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
}