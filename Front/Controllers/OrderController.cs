using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderHistory()
        {
            // Sipariş geçmişi işlemleri
            return View();
        }
    }
}
