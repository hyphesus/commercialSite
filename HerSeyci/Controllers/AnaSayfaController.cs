using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        [HttpGet]
        public ActionResult AnaSayfa()
        {

            return View();
        }

    }
}