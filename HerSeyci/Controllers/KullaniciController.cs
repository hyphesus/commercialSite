using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using System.Xml.Linq;

namespace HerSeyci.Controllers
{
    public class KullaniciController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }
        // GET: Kullanici

        [HttpGet]
        public ActionResult Kullanici()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Sifre_degistir(account acc)
        {
            string sifre = Session["Password"].ToString();
            sifre = String.Concat(sifre.Split());

            string kullanici = Session["User_name"].ToString();
            kullanici = String.Concat(kullanici.Split());

            if (sifre == acc.Password)
            {
                connectionString();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("@Sifre", acc.Password2);
                com.Parameters.AddWithValue("@User_name", kullanici);
                com.CommandText = "update users set password=@Sifre where username =@User_name";
                dr = com.ExecuteReader();


                if (dr.RecordsAffected==1)
                {
                    Session["Password"] = acc.Password2;
                    con.Close();
                    return View("~/Views/Kullanici/Kullanici.cshtml");
                }
                else
                {
                    con.Close();
                    return View("~/Views/Kullanici/Kullanici.cshtml");
                }
            }
            else
            {
                return View("~/Views/Kullanici/Kullanici.cshtml");
            }


   



        }
    }
}