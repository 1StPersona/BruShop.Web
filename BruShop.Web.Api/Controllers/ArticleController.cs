using BruShop.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BruShop.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private BruShopContext _db;
        public ArticleController(BruShopContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var articles = _db.Articles;
            return articles;
        }
    }
}
