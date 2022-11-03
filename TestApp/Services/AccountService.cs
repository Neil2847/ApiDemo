using TestApp.Entities;
using TestApp.Models;

namespace TestApp.Services;

public class AccountService
{
    private readonly ILogger<AccountService> _logger;

    public AccountService(ILogger<AccountService> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// 取得使用者資訊
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<User> GetUser(int userId)
    {
        return await Task.FromResult(new User
        {
            Displayname = "Neil",
            Id = userId,
            Email = "33"
        });
    }
}