using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            // Alışveriş sepeti işlemleri
            return View();
        }
    }
}
