using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            // Ürün listesini görüntüleme işlemleri
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            // Belirli bir ürünün detaylarını görüntüleme işlemleri
            // id parametresi, görüntülenecek ürünün kimliğini temsil eder
            return View();
        }
    }
}
