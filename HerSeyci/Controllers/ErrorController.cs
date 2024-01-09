using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        // 404 Hata sayfası
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;  //HTTP 404
            return View("NotFound");
        }
    }
}