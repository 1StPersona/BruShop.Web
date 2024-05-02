using BruShop.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BruShop.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
	{
		private BruShopContext _db;
		public ProductController(BruShopContext db)
		{
			_db = db;
		}

		[HttpGet]
		public IEnumerable<Product> Get()
		{
			var products = _db.Products;
			return products;
		}


	}
}
