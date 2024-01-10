using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        // GET: Sepet
        [HttpGet]
        public ActionResult Sepet()
        {



            if(Session["User_id"]!=null)
            { 
                com.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["User_id"]));
                List<products> sepet = new List<products>();


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

                    sepet.Add(productx);


                }

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


            if(Session["User_id"]!=null)
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


    }
}