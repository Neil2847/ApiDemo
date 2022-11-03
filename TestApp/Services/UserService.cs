using TestApp.Context;
using TestApp.Entities;

namespace TestApp.Services;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly AccountService _account;
    private readonly MyDbContext _context;

    public UserService(ILogger<UserService> logger, AccountService account, MyDbContext context)
    {
        _logger = logger;
        _account = account;
        _context = context;
    }

    /// <summary>
    /// 取得使用者名稱
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> GetUserName(int userId)
    {
        return (await _account.GetUser(userId)).Displayname;
    }


    public async Task<List<User>?> GetUsers()
    {
        return await Task.FromResult(_context.Users.ToList().Where(user => user.Email.Contains("yahoo.com")).ToList());
    }
}