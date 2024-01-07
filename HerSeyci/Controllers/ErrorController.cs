using System.Web.Mvc;

public class ErrorController : Controller
{
    // Genel hata sayfas�
    public ActionResult Index()
    {
        return View("Error");
    }

    // 404 Hata sayfas�
    public ActionResult NotFound()
    {
        Response.StatusCode = 404;  //HTTP 404
        return View("NotFound");
    }

    
}