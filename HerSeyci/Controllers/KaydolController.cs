using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class KaydolController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }
        // GET: Kaydol
        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sql_kayit(account acc)
        {
            // Kullanıcı kayıt işlemleri

            com.Parameters.AddWithValue("@Name", acc.Name);
            com.Parameters.AddWithValue("@Surename", acc.Surename);
            com.Parameters.AddWithValue("@User_name", acc.User_name);
            com.Parameters.AddWithValue("@Password", acc.Password);
            com.Parameters.AddWithValue("@E_posta", acc.E_posta);
            com.Parameters.AddWithValue("@Adress1", acc.Adress1);

            Console.WriteLine(com.ToString());

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "insert into users(username,name,surename,adress1,email,password) values (@User_name,@Name,@Surename,@Adress1,@E_posta,@Password)";
            dr = com.ExecuteReader();
            if (dr.RecordsAffected==1)
            {

                con.Close();
                return View("~/Views/Kullanici/Kullanici.cshtml");
            }
            else
            {
                Console.Write(dr.ToString());
                con.Close();
                return View("~/Views/Account/error.cshtml");

            }

        }
    }
}