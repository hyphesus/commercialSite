using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class AccountController : Controller
    {
         public IActionResult Login()
        {
            
            // Kullanıcı girişi sayfası
             return View();
        }

        public IActionResult Profile()
        {
            // Kullanıcı profili işlemleri
            return View();
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            // Kullanıcı kayıt işlemleri
            return View();
        }

        public IActionResult ChangePassword()
        {
            // Şifre değiştirme işlemleri
            return View();
        }


        public IActionResult wishlist()
        {
            // Şifre değiştirme işlemleri
            return View();
        }

        // Diğer hesap işlemleri (kayıt, giriş, çıkış vb.) buraya eklenebilir
    }
}
