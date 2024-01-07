using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        [HttpGet]
        public ActionResult Kullanici(account acc, FormCollection Nesneler)
        {
            Nesneler["Ad"] = acc.Name;

            return View();
        }
    }
}