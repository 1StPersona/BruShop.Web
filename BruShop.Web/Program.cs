using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;



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
    new CultureInfo("kz-KZ")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "ru-RU", uiCulture: "ru-RU");
    options.SupportedCultures = culture;
    options.SupportedUICultures = culture;
});

builder.Services.AddLocalization(option => option.ResourcesPath = "Resourses");







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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
