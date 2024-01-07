using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult verify(account acc)
        {
            // Kullanıcı kayıt işlemleri
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM users WHERE username ='" + acc.User_name + "' AND password ='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                string x = dr["isAdmin"].ToString();
                if (x=="True")
                {
                    con.Close();
                    return View("admin");
                }
                else
                {
                    con.Close();
                    return View("~/Views/AnaSayfa/AnaSayfa.cshtml");
                }
            }
            else
            {
                con.Close();
                return View("error");
            }




        }
    }
}