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
            List<string> couponList = new List<string>();
            if (Session["User_id"]!=null)
            {


                connectionString();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["user_id"]));
                com.CommandText = "select * from coupons where user_id = @User_id OR user_id=1";
                dr = com.ExecuteReader();

                while(dr.Read())
                {
                    couponList.Add(dr["coupon_code"].ToString());
                }
                con.Close();
                return View(couponList);
            }
            else
                return RedirectToAction("AnaSayfa", "AnaSayfa");


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
                    return RedirectToAction("Kullanici", "Kullanici");

                }
                else
                {
                    con.Close();
                    return RedirectToAction("Kullanici", "Kullanici");

                }
            }
            else
            {
                return RedirectToAction("Kullanici", "Kullanici");
            }






        }
    }
}