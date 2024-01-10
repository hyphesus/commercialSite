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
    public class SepetController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }
        List<products> sepet = new List<products>();
        // GET: Sepet
        [HttpGet]
        public ActionResult Sepet()
        {



            if (Session["User_id"] != null)
            {
                com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["User_id"]));

                int toplam = 0;


                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT products.product_id,products.name,products.description,products.price,products.stock,products.category_id,products.img_url FROM Cart INNER JOIN Users ON cart.user_id = users.user_id INNER JOIN Products ON cart.product_id = products.product_id  WHERE  users.user_id = @User_id; ";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var productx = new products()
                    {
                        product_id = Convert.ToInt32(dr["product_id"]),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        price = Convert.ToInt32(dr["price"]),
                        stock = dr["stock"].ToString() == "True" ? "Var" : "Yok",
                        category_id = Convert.ToInt32(dr["category_id"]),
                        img_url = dr["img_url"].ToString()
                    };
                    toplam += productx.price;
                    sepet.Add(productx);


                }

                Session["Total_Price"] = toplam;
                con.Close();
                return View(sepet);
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }




        }

        [HttpPost]
        public ActionResult Sepete_Ekle(int ProductId, int categoryId)
        {


            if (Session["User_id"] != null)
            {
                com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["User_id"]));
                com.Parameters.AddWithValue("@Product_id", ProductId);

                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO cart (user_id, product_id) VALUES (@User_id, @Product_id)";
                dr = com.ExecuteReader();
                con.Close();
                if (categoryId == 1)
                {
                    return RedirectToAction("Giyisi", "KartOlusturma");

                }
                if (categoryId == 2)
                {
                    return RedirectToAction("Elektronik", "KartOlusturma");

                }
                else
                {
                    return RedirectToAction("Kozmetik", "KartOlusturma");

                }
            }
            else
                return RedirectToAction("Login", "Account");


        }


        [HttpPost]
        public ActionResult Sepetden_Sil(int ProductId)
        {
            if (Session["User_id"] != null)
            {
                com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["User_id"]));
                com.Parameters.AddWithValue("@Product_id", ProductId);

                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "DELETE TOP (1) FROM cart WHERE product_id = @Product_id AND user_id = @User_id";
                dr = com.ExecuteReader();
                con.Close();

                return RedirectToAction("sepet", "sepet");
            }
            else
                return RedirectToAction("Login", "Account");

        }


        [HttpPost]
        public ActionResult Kupon_Ekle(coupon cpn)
        {
            com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["User_id"]));
            com.Parameters.AddWithValue("@Kupon", cpn.coupon_name);


            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * from coupons where (user_id=@User_id AND coupon_code = @Kupon) or (user_id=1 AND coupon_code = @Kupon)";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                Session["Kupon"] = dr["coupon_value"].ToString();
            }
            con.Close();
            return RedirectToAction("sepet", "sepet");
        }


        [HttpGet]
        public ActionResult Fatura()
        {
            int sonuc = Convert.ToInt32(Session["Total_price"]) - Convert.ToInt32(Session["Kupon"]);


            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Sepeti_Sonlandir()
        {

            return RedirectToAction("fatura", "sepet");

        }
    }
}

