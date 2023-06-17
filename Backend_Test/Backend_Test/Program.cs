using Microsoft.EntityFrameworkCore;
using System;
using Backend_Test.Context;
using Backend_Test.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    });

// configure database settings object
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsLocal"));

// configure dependency injection for application services
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

