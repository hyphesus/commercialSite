using System;
using HerSeyci.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace HerSeyci.Controllers
{
    public class shoppingController : Controller
    {
        // GET: shopping
        public ActionResult Index()
        {
            return View();
        }
    }
}