using Microsoft.AspNetCore.Mvc;
using TestApp.Entities;
using TestApp.Models;

namespace TestApp.Services;

public class WorkService
{
    private readonly ILogger<WorkService> _logger;

    public WorkService(ILogger<WorkService> logger)
    {
        _logger = logger;
    }

    public async Task<User?> GetUserById(int id)
    {
        if (id > 30)
        {
            return await Task.FromResult(new User
            {
                Id = id,
                Displayname = $"Neil{id}",
            });
        }

        return null;
    }
}