using BruShop.Web.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();


// Add services to the container.

string connectionString = "data source=178.89.186.221, 1434;initial catalog=aprelev_db;user id=aprelev_user;password=hH583z3i^;MultipleActiveResultSets=True;application name=EntityFramework;TrustServerCertificate=True";


Log.Logger = new LoggerConfiguration()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" })
        .CreateLogger();

builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);


builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

builder.Services.AddDbContext<BruShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "",
        ValidIssuer = "",
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4c53ce9de0ab7c9ce2f72f2b1447aa73"))
    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
