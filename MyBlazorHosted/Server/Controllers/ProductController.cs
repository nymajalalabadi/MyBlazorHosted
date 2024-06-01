using Microsoft.AspNetCore.Mvc;

namespace MyBlazorHosted.Server.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
