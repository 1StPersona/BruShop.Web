using BruShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BruShop.Web.Controllers
{
    public class ArticleController : Controller
    {
        private List<Article> articles;
        public async Task<IActionResult> Index()
        {
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("http://localhost:5111/api/Article"))
                {
                    string apiRequest = await response.Content.ReadAsStringAsync();
                    articles = JsonConvert.DeserializeObject<List<Article>>(apiRequest);
                }
            }
            return View(articles);
        }
    }
}
