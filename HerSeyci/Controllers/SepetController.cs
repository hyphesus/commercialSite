using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet

        [HttpGet]
        public ActionResult Sepet()
        {

            return View();
        }
    }
}