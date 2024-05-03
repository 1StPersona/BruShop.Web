using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;


string connectionString = "data source=178.89.186.221, 1434;initial catalog=aprelev_db;user id=aprelev_user;password=hH583z3i^;MultipleActiveResultSets=True;application name=EntityFramework;TrustServerCertificate=True";


var builder = WebApplication.CreateBuilder(args);
///<summary>
///Localization meethood 
///</summary>
builder.Services.AddMvc().AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix);

    
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var culture = new[]
    {
        new CultureInfo("ru-RU"),
        new CultureInfo("en-US"),
        new CultureInfo("kk-KZ")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "ru-RU", uiCulture: "ru-RU");
    options.SupportedCultures = culture;
    options.SupportedUICultures = culture;
});

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");


builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" })
        .CreateLogger();
builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

var localOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localOptions.Value);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
