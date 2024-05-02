using Microsoft.AspNetCore.Mvc;

namespace BruShop.Web.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
