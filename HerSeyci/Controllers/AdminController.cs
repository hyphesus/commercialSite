using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class AdminController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }


        // GET: Admin
        [HttpGet]
        public ActionResult Urun_Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Urun_Ekle(products pds)
        {

            // Kullanıcı kayıt işlemleri

            com.Parameters.AddWithValue("@Product_id", pds.product_id);
            com.Parameters.AddWithValue("@Name", pds.name);
            com.Parameters.AddWithValue("@Description", pds.description);
            com.Parameters.AddWithValue("@Price", pds.price);
            com.Parameters.AddWithValue("@Stock", pds.stock);
            com.Parameters.AddWithValue("@Img_url", pds.img_url);

            char ilkKarakter = pds.category[0];
            int sayisalDeger = (int)Char.GetNumericValue(ilkKarakter);
            com.Parameters.AddWithValue("@Category_id", sayisalDeger);



            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "insert into products(name,description,price,stock,category_id,img_url) values (@Name,@Description,@Price,@Stock,@Category_id,@Img_url)";
            dr = com.ExecuteReader();
            if (dr.RecordsAffected == 1)
            {

                con.Close();
                return View("~/Views/Anasayfa/Anasayfa.cshtml");
            }
            else
            {
                Console.Write(dr.ToString());
                con.Close();
                return View("~/Views/Account/error.cshtml");

            }

        }



        [HttpGet]
        public ActionResult Urun_Guncelle( products pds)
        {
            // Kullanıcı kayıt işlemleri

            return View();
        }

        [HttpPost]
        public ActionResult Urun_Guncelle_Post(products pds)
        {
            // Kullanıcı kayıt işlemleri
            com.Parameters.AddWithValue("@Product_id", pds.product_id);
            com.Parameters.AddWithValue("@Stock", pds.stock);



            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "update products set stock= @Stock where product_id=@Product_id ";
            dr = com.ExecuteReader();
            if (dr.RecordsAffected == 1)
            {

                con.Close();
                return View("~/Views/Anasayfa/Anasayfa.cshtml");
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