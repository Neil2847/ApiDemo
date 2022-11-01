using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;
using TestApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add NSwag
builder.Services.AddOpenApiDocument();

// 注入服務
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<AccountService>();
builder.Services.AddScoped<WorkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Add ErrorHandler
    app.UseExceptionHandler("/ErrorDev");
    // Add NSwag
    app.UseOpenApi();
    app.UseSwaggerUi3();
    // 使用錯誤偵測頁面
    // app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();