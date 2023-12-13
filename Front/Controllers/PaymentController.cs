using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            // Ödeme sitesine yönlendirme
            return View();
        }
        public IActionResult Index()
        {
            // Ödeme işlemleri için gerekli işlemler
            return View();
        }

        // Ödeme işlemini tamamlama
        [HttpPost]
        public IActionResult CompletePayment()
        {
            // Ödeme tamamlandıktan sonra yapılacak işlemler
            return RedirectToAction("Index", "Home"); // Ödeme tamamlandıktan sonra ana sayfaya yönlendirme
        }
    }
}
