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
        private readonly ILogger<ArticleController> _logger;




        
        public ArticleController(BruShopContext db,ILogger<ArticleController>_logs)
        {
            _db = db;
            _logger=_logs;
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var articles = _db.Articles;
            _logger.LogInformation("LogInfo");
            _logger.LogError("LogError");
            _logger.LogWarning("LogWarning");
            return articles;
        }
    }
}
