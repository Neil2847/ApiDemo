using TestApp.Context;
using TestApp.Entities;
using TestApp.Models;

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
        return (await _account.GetUser(userId)).DisplayName;
    }

    /// <summary>
    /// 加入使用者
    /// </summary>
    /// <param name="user"></param>
    public async Task<MyError?> SaveUser(User user)
    {
        // _context.Entry(user).State = EntityState.Added;
        try
        {
            var isFind = _context.Users.Any(u => u.Email == user.Email);
            if (!isFind)
            {
                user.Id = new Random().Next(int.MinValue, int.MaxValue);
                _context.Users.Add(user);
            }
            else
            {
                return new MyError("找到重複的資料");
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return new MyError(e.ToString());
        }

        return null;
    }


    /// <summary>
    /// 取得所有使用者
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await Task.FromResult(_context.Users.ToList());
    }
}