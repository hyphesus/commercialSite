using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class ProductsController : Controller
    {
        // GET: AnaSayfa
        [HttpGet]
        public ActionResult Elektronik()
        {

            return View();
        }

        public ActionResult Giyim()
        {

            return View();
        }

        public ActionResult Kozmetik()
        {

            return View();
        }
    }
}