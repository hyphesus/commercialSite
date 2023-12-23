using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Ana sayfa işlemleri
            return View();
        }

        public IActionResult contactUs()
        {
            // Ana sayfa işlemleri
            return View();
        }

        public IActionResult about()
        {
            // Ana sayfa işlemleri
            return View();
        }


        public IActionResult Error()
        {
            // Hata sayfasına yönlendirme işlemleri
            return View();
        }

        // Diğer genel işlemler buraya eklenebilir
    }
}
