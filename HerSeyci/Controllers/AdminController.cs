using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

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
                return RedirectToAction("Anasayfa", "Anasayfa");
            }
            else
            {
                Console.Write(dr.ToString());
                con.Close();
                return RedirectToAction("error", "Account");


            }

        }



        [HttpGet]
        public ActionResult Urun_Guncelle( products pds)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Urun_Guncelle_Post(products pds)
        {
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
                return RedirectToAction("Anasayfa", "Anasayfa");
            }
            else
            {
                Console.Write(dr.ToString());
                con.Close();
                return RedirectToAction("error", "Account");


            }

        }



        [HttpGet]
        public ActionResult Kupon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kupon_Ekle(coupon coupon, account acc)
        {

            com.Parameters.AddWithValue("@User_id", acc.user_id);
            com.Parameters.AddWithValue("@Kupon_name", coupon.coupon_name);
            com.Parameters.AddWithValue("@Kupon_value", coupon.coupon_value);
            string tarih = coupon.coupon_date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);





            com.Parameters.AddWithValue("@Kupon_Tarihi", tarih);


            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO coupons (user_id, coupon_code,coupon_value, expiry_date) VALUES (@User_id, @Kupon_name, @Kupon_value, @Kupon_Tarihi); ";
            dr = com.ExecuteReader();
            if (dr.RecordsAffected == 1)
            {

                con.Close();
                return RedirectToAction("Kupon", "Admin");
            }
            else
            {
                Console.Write(dr.ToString());
                con.Close();
                return RedirectToAction("Kupon", "Admin");


            }

        }


    }
}