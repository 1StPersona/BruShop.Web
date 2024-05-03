using BruShop.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace BruShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string culture)
        {
            HomeData hd = new HomeData();
            string jwt = GenerateJSONWebToken();

            if (!string.IsNullOrWhiteSpace(culture)) 
            {
                CultureInfo.CurrentCulture = new CultureInfo(culture);
                CultureInfo.CurrentUICulture = new CultureInfo(culture);
            }

            _logger.LogInformation("LogInfo");
            _logger.LogError("LogError");
            _logger.LogWarning("LogWarning");

            using(var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                using (var response = await httpClient.GetAsync("http://localhost:5111/api/Product"))
                {
                    string apiRequest = await response.Content.ReadAsStringAsync();
                    hd.products = JsonConvert.DeserializeObject<List<Product>>(apiRequest);
                }
                using (var response = await httpClient.GetAsync("http://localhost:5111/api/Review"))
                {
                    string apiRequest = await response.Content.ReadAsStringAsync();
                    hd.reviews = JsonConvert.DeserializeObject<List<Review>>(apiRequest);
                }
                using (var response = await httpClient.GetAsync("http://localhost:5111/api/Article"))
                {
                    string apiRequest = await response.Content.ReadAsStringAsync();
                    hd.articles = JsonConvert.DeserializeObject<List<Article>>(apiRequest);
                }
            }

            return View(hd);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4c53ce9de0ab7c9ce2f72f2b1447aa73"));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "John Doe",
                audience: "1516239022",
                expires: DateTime.Now.AddSeconds(12),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}