using BruShop.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BruShop.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private BruShopContext _db;
        public ReviewController(BruShopContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Review> Get()
        {
            var reviews = _db.Reviews;
            return reviews;
        }
    }
}
