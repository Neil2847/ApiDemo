namespace TestApp.Services;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly AccountService _account;
    
    public UserService(ILogger<UserService> logger, AccountService account)
    {
        _logger = logger;
        _account = account;
    }

    /// <summary>
    /// 取得使用者名稱
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> GetUserName(int userId)
    {
        return (await _account.GetUser(userId)).Name;
    }
}