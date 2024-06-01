using Microsoft.AspNetCore.Mvc;

namespace MyBlazorHosted.Server.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
