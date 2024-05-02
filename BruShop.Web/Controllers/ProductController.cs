using BruShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;


namespace BruShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products;
        public async Task<IActionResult> Index()
        {
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5111/api/Product"))
                {
                    string apiRequest = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiRequest);
                }
            }
            return View(products);
        }
    }
}
