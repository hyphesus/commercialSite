using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
        public ActionResult Kullanici(account acc)
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
                acc.Name = dr["name"].ToString();
                acc.user_id = Convert.ToInt32(dr["user_id"]);
                acc.User_name = dr["username"].ToString();
                acc.Surename = dr["surename"].ToString();
                acc.Adress1 = dr["adress1"].ToString();
                acc.Adress2 = dr["adress2"].ToString();
                acc.E_posta = dr["email"].ToString();
                acc.Phone = dr["phone"].ToString();
                acc.Password = dr["password"].ToString();


                Session["Ad"] = acc.Name;
                Session["User_id"] = acc.user_id;
                Session["Soyad"] = acc.Surename;
                Session["User_name"] = acc.User_name;
                Session["Adress1"] = acc.Adress1;
                Session["Adress2"] = acc.Adress2;
                Session["Eposta"] = acc.E_posta;
                Session["Phone"] = acc.Phone;
                Session["Password"] = acc.Password;

                Session["Total_price"] = 0;

                if (x=="True")
                {
                    con.Close();
                    return RedirectToAction("Urun_Ekle", "Admin");
                }
                else
                {
                    con.Close();
                    return RedirectToAction("Kullanici", "Kullanici");

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